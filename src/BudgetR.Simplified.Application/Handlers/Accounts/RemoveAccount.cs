namespace BudgetR.Simplified.Server.Application.Handlers.Accounts;
public class RemoveAccount
{
    public record Request(long? AccountId) : IRequest<Result<long>>;

    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.AccountId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
        }
    }

    public class Handler : BaseHandler, IRequestHandler<Request, Result<long>>
    {
        private readonly Validator _validator = new();

        public Handler(BudgetRDbContext context, ServerContext serverContext)
            : base(context, serverContext)
        {
        }

        public async Task<Result<long>> Handle(Request request, CancellationToken cancellationToken)
        {
            var validation = await _validator.ValidateAsync(request);
            if (!validation.IsValid)
            {
                return Result.Invalid(validation.AsErrors());
            }

            try
            {
                transaction = await _dbContext.BeginTransactionContext();

                long btaId = await CreateBta();

                bool doesAccountExist = await _dbContext.Accounts
                    .AnyAsync(x => x.AccountId == request.AccountId
                                && x.UserId == _serverContext.UserId);

                if (!doesAccountExist)
                {
                    return Result.NotFound("Account does not exist");
                }

                await _dbContext.Accounts
                    .Where(x => x.AccountId == request.AccountId && x.UserId == _serverContext.UserId)
                    .ExecuteDeleteAsync();

                await _dbContext.CommitTransactionContext(transaction);

                return Result.Success();
            }
            catch (Exception ex)
            {
                transaction.Dispose();
                return Result.Error(ex.Message);
            }
        }
    }
}
