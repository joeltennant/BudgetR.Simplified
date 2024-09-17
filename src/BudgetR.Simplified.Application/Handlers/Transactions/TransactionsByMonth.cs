namespace BudgetR.Simplified.Server.Application.Handlers.Transactions;
public class TransactionsByMonth
{
    public record Request(long? budgetMonthId) : IRequest<Result<List<TransactionDto>>>;

    public class TransactionDto
    {
        public long TransactionId { get; set; }
        public string? Description { get; set; }

        public string? AccountName { get; set; }

        public string? TransactionType { get; set; }

        public int Month { get; set; }
        public int Year { get; set; }

        public decimal Amount { get; set; }

        public DateOnly? TransactionDate { get; set; }
        public long TransactionCategoryId { get; set; }
        public string? CategoryName { get; set; }
    }

    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.budgetMonthId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
        }
    }

    public class Handler : BaseHandler, IRequestHandler<Request, Result<List<TransactionDto>>>
    {
        private readonly Validator _validator = new();

        public Handler(BudgetRDbContext context, ServerContext serverContext)
            : base(context, serverContext)
        {
        }

        public async Task<Result<List<TransactionDto>>> Handle(Request request, CancellationToken cancellationToken)
        {
            var validation = await _validator.ValidateAsync(request);
            if (!validation.IsValid)
            {
                return Result.Invalid(validation.AsErrors());
            }

            try
            {
                var transactions = await _dbContext.Transactions
                    .Where(x => _serverContext.UserId == x.UserId
                                && x.BudgetMonthId == request.budgetMonthId)
                    .Select(x => new TransactionDto
                    {
                        TransactionId = x.TransactionId,
                        Description = x.Description,
                        AccountName = x.AccountName,
                        TransactionType = x.TransactionType.ToString(),
                        Amount = x.Amount,
                        TransactionDate = x.TransactionDate,
                        CategoryName = x.TransactionCategory.CategoryName,
                        TransactionCategoryId = x.TransactionCategory.TransactionCategoryId,
                        //Month = x.TransactionMonth,
                        //Year = x.TransactionYear
                    })
                    .ToListAsync();

                return Result.Success(transactions);
            }
            catch (Exception ex)
            {
                transaction.Dispose();
                return Result.Error(ex.Message);
            }
        }
    }
}
