﻿using BudgetR.Simplified.Domain.Entities;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Http;

namespace BudgetR.Simplified.Application.PipelineBehaviors;

public class PreRequestBehavior<TRequest> : IRequestPreProcessor<TRequest>
{
    private ServerContext _serverContext;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly BudgetRDbContext _budgetRDbContext;

    public PreRequestBehavior(ServerContext serverContext, IHttpContextAccessor httpContextAccessor, BudgetRDbContext budgetRDbContext)
    {
        _serverContext = serverContext;
        _httpContextAccessor = httpContextAccessor;
        _budgetRDbContext = budgetRDbContext;
    }

    public async Task Process(TRequest request, CancellationToken cancellationToken)
    {
        _serverContext.ProcessName = GetHandlerName();
        _serverContext.BtaId = null;

        //string email = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Name).Value;
        var authenticationId = _httpContextAccessor.HttpContext?.User?.Identity?.Name;

        if (authenticationId != null)
        {
            var user = _budgetRDbContext.Users
                .Where(x => x.AuthenticationId == authenticationId)
                .Select(u => new User
                {
                    UserId = u.UserId,
                    UserType = u.UserType,
                    IsActive = u.IsActive,
                })
                .FirstOrDefault();

            if (user != null)
            {
                _serverContext.UserId = user.UserId;
                _serverContext.UserType = user.UserType;
                _serverContext.IsActive = user.IsActive;
            }
        }
    }

    protected string GetHandlerName()
    {
        string handlerName = typeof(TRequest).DeclaringType.Name;
        string folderName = typeof(TRequest).Namespace.Split(".").Last();

        return folderName + "." + handlerName;
    }
}
