using System.Reflection;

using Mapster;

using MapsterMapper;

using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace billing_system_core.Api.Common.Mapping;

public static class DependencyInjection
{
    public static IServiceCollection AddMappings(this IServiceCollection service)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());

        service.AddSingleton(config);
        service.AddSingleton<IMapper, ServiceMapper>();
        return service;
    }
}