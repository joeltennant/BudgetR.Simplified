namespace BudgetR.Simplified.Server.Application.Handlers.Accounts;
public class CreateAccount
{
    public record Request(string DisplayName, string LongName, decimal Balance, long AccountTypeId) : IRequest<Result<long>>;

    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.DisplayName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2);
            RuleFor(x => x.LongName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2);
            RuleFor(x => x.Balance)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.AccountTypeId)
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

                Account account = new()
                {
                    UserId = _serverContext.UserId.Value,
                    DisplayName = "New Account",
                    BusinessTransactionActivityId = btaId,
                    AccountTypeId = request.AccountTypeId,
                    Balance = request.Balance,
                    LongName = request.LongName,
                    CreatedAt = DateTime.UtcNow,
                };

                await _dbContext.Accounts.AddAsync(account);
                await _dbContext.SaveChangesAsync();

                await _dbContext.CommitTransactionContext(transaction);

                if (account.AccountId == 0)
                {
                    return Result.Error("Account creation failed");
                }

                return Result.Success(account.AccountId);
            }
            catch (Exception ex)
            {
                transaction.Dispose();
                return Result.Error(ex.Message);
            }
        }
    }
}
