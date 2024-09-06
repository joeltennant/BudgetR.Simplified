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
    public async Task<Result<NoValue>> CreateTransactions([FromBody] CreateTransaction.TransactionDto transaction)
    {
        return await _mediator.Send(new CreateTransaction.Request(transaction));
    }

    [HttpGet("{id}")]
    //[Route("getTransactionsByMonth")]
    [TranslateResultToActionResult]
    public async Task<Result<List<TransactionsByMonth.TransactionDto>>> GetTransactionsByMonth(long id)
    {
        return await _mediator.Send(new TransactionsByMonth.Request(id));
    }
}
