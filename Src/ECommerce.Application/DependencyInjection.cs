using ECommerce.Application.Features.Products.Mappings;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Application;

public static class DependencyInjection
{

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

        var config=TypeAdapterConfig.GlobalSettings;

        config.Scan(typeof(DependencyInjection).Assembly);

        services.AddSingleton(config);

        services.AddScoped<IMapper, ServiceMapper>();


        return services;
    }
}
