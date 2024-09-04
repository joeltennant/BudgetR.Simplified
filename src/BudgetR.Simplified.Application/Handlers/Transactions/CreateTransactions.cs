using BudgetR.Simplified.Services.Transactions;

namespace BudgetR.Simplified.Application.Handlers.Transactions;
public class CreateTransactions
{
    public record Request(List<TransactionDto> transactions) : IRequest<Result<NoValue>>;

    public class TransactionDto
    {
        public string? Description { get; set; }

        public string? AccountName { get; set; }

        public TransactionType? TransactionType { get; set; }

        public decimal Amount { get; set; }

        public DateOnly? TransactionDate { get; set; }

        public string? CategoryName { get; set; }
    }

    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleForEach(x => x.transactions).ChildRules(transaction =>
            {
                transaction.RuleFor(x => x.Description)
                    .NotEmpty()
                    .NotNull()
                    .MinimumLength(3);
                transaction.RuleFor(x => x.AccountName)
                    .NotNull()
                    .NotEmpty()
                    .MinimumLength(3);
                transaction.RuleFor(x => x.Amount)
                    .NotNull()
                    .NotEmpty()
                    .GreaterThan(0);
                transaction.RuleFor(x => x.TransactionDate)
                    .NotEmpty()
                    .NotNull();
                transaction.RuleFor(x => x.CategoryName)
                    .NotNull()
                    .NotEmpty()
                    .MinimumLength(2);
            });
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

                var transactions = request.transactions.Select(x => new Transaction
                {
                    Description = x.Description,
                    AccountName = x.AccountName,
                    TransactionType = x.TransactionType,
                    Amount = x.Amount,
                    TransactionDate = x.TransactionDate,
                    CategoryName = x.CategoryName
                }).ToList();

                var transactionService = new TransactionService(_dbContext, _serverContext).ProcessTransactions(transactions, btaId);

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
