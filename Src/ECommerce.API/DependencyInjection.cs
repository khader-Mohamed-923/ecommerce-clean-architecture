
namespace ECommerce.API;

public static class DependencyInjection
{

    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();


        return services;
    }
}
