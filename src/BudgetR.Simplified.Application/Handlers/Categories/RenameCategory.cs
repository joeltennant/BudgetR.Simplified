namespace BudgetR.Simplified.Server.Application.Handlers.Categories;
public class RenameCategory
{
    public record Request(long? CategoryId, string NewCategoryName) : IRequest<Result<NoValue>>;

    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.NewCategoryName)
                              .NotEmpty()
                              .NotNull()
                              .MinimumLength(2);
            RuleFor(x => x.CategoryId)
                              .NotEmpty()
                              .NotNull()
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

                bool doesCategoryExist = await _dbContext.TransactionCategories
                    .AnyAsync(x => x.TransactionCategoryId == request.CategoryId
                                   && x.UserId == _serverContext.UserId);

                if (!doesCategoryExist)
                {
                    return Result.NotFound("Category does not exist");
                }

                //update the category name
                var category = await _dbContext.TransactionCategories
                    .Where(x => x.TransactionCategoryId == request.CategoryId
                                && x.UserId == _serverContext.UserId)
                    .ExecuteUpdateAsync(setters => setters
                        .SetProperty(x => x.CategoryName, request.NewCategoryName)
                        .SetProperty(x => x.BusinessTransactionActivityId, btaId));

                await _dbContext.SaveChangesAsync();

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
