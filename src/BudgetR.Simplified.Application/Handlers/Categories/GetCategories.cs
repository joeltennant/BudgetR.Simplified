﻿using Microsoft.EntityFrameworkCore;

namespace BudgetR.Simplified.Application.Handlers.Categories;
public class GetCategories
{
    public record Request() : IRequest<Result<List<CategoryItem>>>;

    public class CategoryItem
    {
        public long TransactionCategoryId { get; set; }
        public string CategoryName { get; set; }
    }

    public class Handler : BaseHandler, IRequestHandler<Request, Result<List<CategoryItem>>>
    {
        public Handler(BudgetRDbContext context, ServerContext serverContext)
            : base(context, serverContext)
        {
        }

        public async Task<Result<List<CategoryItem>>> Handle(Request request, CancellationToken cancellationToken)
        {
            try
            {
                long btaId = await CreateBta();

                var categories = await _dbContext.TransactionCategories
                                   .Where(x => x.UserId == _serverContext.UserId)
                                   .Select(x => new CategoryItem
                                   {
                                       TransactionCategoryId = x.TransactionCategoryId,
                                       CategoryName = x.CategoryName
                                   })
                                   .ToListAsync();

                return Result.Success(categories);
            }
            catch (Exception ex)
            {
                transaction.Dispose();
                return Result.Error(ex.Message);
            }
        }
    }
}