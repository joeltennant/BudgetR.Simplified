using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using BudgetR.Simplified.Application.Handlers.Users;
using BudgetR.Simplified.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BudgetR.Simplified.Controllers;

public class UsersController : BaseController
{
    public UsersController(IMediator mediator) : base(mediator)
    {
    }

    // GET api/Users/loginUser
    [HttpGet]
    [Route("loginUser")]
    [TranslateResultToActionResult]
    public async Task<Result<(string? FirstName, bool IsActive)>> LoginUser()
    {
        return await _mediator.Send(new LoginUser.Request());
    }

    // POST api/Users/registerUser
    [HttpPost]
    [Route("registerUser")]
    [TranslateResultToActionResult]
    public async Task<Result<NoValue>> RegisterUser([FromBody] RegisterUser.Request register)
    {
        return await _mediator.Send(register);
    }
}
