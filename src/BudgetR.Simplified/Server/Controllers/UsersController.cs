using BudgetR.Simplified.Core;
using BudgetR.Simplified.Server.Application.Handlers.Users;

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
    public async Task<Result<LoginUser.Response>> LoginUser()
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
