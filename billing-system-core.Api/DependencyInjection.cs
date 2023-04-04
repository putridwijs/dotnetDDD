using billing_system_core.Api.Common.Mapping;

using MediatR;

namespace billing_system_core.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddMappings();
        return services;
    }
}