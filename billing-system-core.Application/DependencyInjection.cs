using System.Reflection;

using billing_system_core.Application.Common.Behavior;

using FluentValidation;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

namespace billing_system_core.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(DependencyInjection).Assembly);
     
        services.AddScoped(
            typeof(IPipelineBehavior<,>),
            typeof(ValidationBehavior<,>));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}