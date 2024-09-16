using BudgetR.Simplified.Server.Services.Transactions;

namespace BudgetR.Simplified.Server.Application.Handlers.Transactions;
public class CreateTransaction
{
    public record Request(TransactionDto transaction) : IRequest<Result<NoValue>>;

    public class TransactionDto
    {
        public string? Description { get; set; }

        public string? AccountName { get; set; }

        //public TransactionType? TransactionType { get; set; }

        public decimal Amount { get; set; }

        public DateTime? TransactionDate { get; set; }

        public long TransactionCategoryId { get; set; }
    }

    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.transaction.Description)
                              .NotEmpty()
                              .NotNull()
                              .MinimumLength(3);
            RuleFor(x => x.transaction.AccountName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3);
            RuleFor(x => x.transaction.Amount)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.transaction.TransactionDate)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.transaction.TransactionCategoryId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
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

                var transactionEntity = new Transaction
                {
                    Description = request.transaction.Description,
                    AccountName = request.transaction.AccountName,
                    Amount = request.transaction.Amount,
                    TransactionDate = DateOnly.FromDateTime(request.transaction.TransactionDate.Value),
                    TransactionCategoryId = request.transaction.TransactionCategoryId
                };

                var transactions = new List<Transaction> { transactionEntity };

                var transactionService = new TransactionService(_dbContext, _serverContext);
                await transactionService.ProcessTransactions(transactions, btaId);

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
