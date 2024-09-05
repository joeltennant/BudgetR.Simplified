using BudgetR.Simplified.Application.Handlers.Transactions;
using BudgetR.Simplified.Core;

namespace BudgetR.Simplified.Controllers;

public class TransactionsController : BaseController
{
    public TransactionsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    [Route("createTransaction")]
    [TranslateResultToActionResult]
    public async Task<Result<NoValue>> CreateTransactions([FromBody] CreateTransactions.TransactionDto transaction)
    {
        return await _mediator.Send(new CreateTransactions.Request(transaction));
    }
}
