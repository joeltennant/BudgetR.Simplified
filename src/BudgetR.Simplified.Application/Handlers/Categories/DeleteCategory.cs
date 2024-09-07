using Microsoft.EntityFrameworkCore;

namespace BudgetR.Simplified.Application.Handlers.Categories;
public class DeleteCategory
{
    public record Request(long? CategoryId) : IRequest<Result<NoValue>>;

    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
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

                await _dbContext.TransactionCategories
                .Where(x => x.TransactionCategoryId == request.CategoryId
                         && x.UserId == _serverContext.UserId)
                .ExecuteDeleteAsync();

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
