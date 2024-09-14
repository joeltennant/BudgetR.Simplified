namespace BudgetR.Simplified.Application.Handlers.Categories;
public class CreateCategory
{
    public record Request(string CategoryName) : IRequest<Result<long>>;

    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.CategoryName)
                              .NotEmpty()
                              .NotNull()
                              .MinimumLength(2);
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

                var transactionCategory = new TransactionCategory
                {
                    CategoryName = request.CategoryName,
                    UserId = _serverContext.UserId,
                    CreatedAt = DateTime.UtcNow
                };

                await _dbContext.TransactionCategories.AddAsync(transactionCategory);
                await _dbContext.SaveChangesAsync();

                await _dbContext.CommitTransactionContext(transaction);

                return Result.Success(transactionCategory.TransactionCategoryId);
            }
            catch (Exception ex)
            {
                transaction.Dispose();
                return Result.Error(ex.Message);
            }
        }
    }
}
