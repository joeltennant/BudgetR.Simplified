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
    public string LoginUser(int id)
    {
        return "value";
    }
}
