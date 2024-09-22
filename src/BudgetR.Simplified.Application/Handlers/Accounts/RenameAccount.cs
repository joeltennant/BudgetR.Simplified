namespace BudgetR.Simplified.Server.Application.Handlers.Accounts;
public class RenameAccount
{
    public record Request(long? AccountId, string newName, string newLongName) : IRequest<Result<NoValue>>;

    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.AccountId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
            RuleFor(x => x.newName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2);
            RuleFor(x => x.newLongName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(5);
        }
    }

    public class Handler : BaseHandler, IRequestHandler<Request, Result<NoValue>>
    {
        private readonly Validator _validator = new();

        public Handler(BudgetRDbContext context, ServerContext serverContext)
            : base(context, serverContext)
        {
        }

        public async Task<Result<NoValue>> Handle(Request request, CancellationToken cancellationToken)
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
                    .ExecuteUpdateAsync(setters => setters
                        .SetProperty(x => x.DisplayName, request.newName)
                        .SetProperty(x => x.LongName, request.newLongName)
                        .SetProperty(x => x.BusinessTransactionActivityId, btaId));

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
