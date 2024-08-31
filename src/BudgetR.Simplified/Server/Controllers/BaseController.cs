﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetR.Simplified.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BaseController : ControllerBase
{
    protected readonly IMediator _mediator;
    public BaseController(IMediator mediator)
    {
        _mediator = mediator;
    }
}