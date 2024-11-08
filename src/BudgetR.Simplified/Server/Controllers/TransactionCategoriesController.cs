using BudgetR.Simplified.Core;
using BudgetR.Simplified.Server.Application.Handlers.Categories;

namespace BudgetR.Simplified.Controllers;

public class TransactionCategoriesController : BaseController
{
    public TransactionCategoriesController(IMediator mediator) : base(mediator)
    {
    }

    // GET api/TransactionCategories/getTransactionCategories
    [HttpGet]
    [Route("getTransactionCategories")]
    [TranslateResultToActionResult]
    public async Task<Result<List<GetCategories.CategoryItem>>> GetTransactionCategories()
    {
        return await _mediator.Send(new GetCategories.Request());
    }

    // POST api/TransactionCategories/createTransactionCategory
    [HttpPost]
    [Route("createTransactionCategory")]
    [TranslateResultToActionResult]
    public async Task<Result<long>> CreateTransactionCategory([FromBody] CreateCategory.Request request)
    {
        return await _mediator.Send(request);
    }

    // PUT api/TransactionCategories/updateTransactionCategory
    [HttpPut]
    [TranslateResultToActionResult]
    public async Task<Result<NoValue>> UpdateTransactionCategory([FromBody] RenameCategory.Request request)
    {
        return await _mediator.Send(request);
    }

    // DELETE api/TransactionCategories/deleteTransactionCategory/id
    [HttpDelete("{id}")]
    [TranslateResultToActionResult]
    public async Task<Result<NoValue>> DeleteTransactionCategory(long id)
    {
        return await _mediator.Send(new DeleteCategory.Request(id));
    }
}
