﻿using BudgetR.Simplified.Server.Application.PipelineBehaviors;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BudgetR.Simplified.Server.Application;

public static class ConfigureServices
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddRequestPreProcessor<PreRequestBehavior<IRequest>>();
        });

        services.AddScoped(typeof(IRequestPreProcessor<>), typeof(PreRequestBehavior<>));
    }
}