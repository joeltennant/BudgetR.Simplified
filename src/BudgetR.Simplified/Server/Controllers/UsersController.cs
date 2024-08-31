using BudgetR.Simplified.Application.Handlers.Users;
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
    public async Task<(string? FirstName, bool IsActive)> LoginUser()
    {
        return await _mediator.Send(new LoginUser.Request());
    }
}
