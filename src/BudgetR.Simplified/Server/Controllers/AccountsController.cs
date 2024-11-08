﻿using BudgetR.Simplified.Core;
using BudgetR.Simplified.Server.Application.Handlers.Accounts;

namespace BudgetR.Simplified.Controllers;

public class AccountsController : BaseController
{
    public AccountsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [TranslateResultToActionResult]
    public async Task<Result<List<GetAllAccounts.Response>>> GetAccounts()
    {
        return await _mediator.Send(new GetAllAccounts.Request());
    }

    [HttpGet("AccountTypes")]
    [TranslateResultToActionResult]
    public async Task<Result<List<GetAccountTypes.Response>>> GetAccountTypes()
    {
        return await _mediator.Send(new GetAccountTypes.Request());
    }

    [HttpPost]
    [TranslateResultToActionResult]
    public async Task<Result<long>> CreateAccount([FromBody] CreateAccount.Request command)
    {
        return await _mediator.Send(command);
    }

    [HttpPut("rename")]
    [TranslateResultToActionResult]
    public async Task<Result<NoValue>> UpdateAccount([FromBody] UpdateAccount.Request request)
    {
        return await _mediator.Send(request);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAccount(long id)
    {
        await _mediator.Send(new RemoveAccount.Request(id));
        return NoContent();
    }
}
