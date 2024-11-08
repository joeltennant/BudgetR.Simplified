﻿using BudgetR.Simplified.Core;
using BudgetR.Simplified.Server.Application.Handlers.Transactions;

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
