using ECommerce.Domain.Interfaces;
using ECommerce.Infrastructure.Data.DbContexts;
using ECommerce.Infrastructure.Persistence.Interceptors;
using ECommerce.Infrastructure.Persistence.Seeders;
using ECommerce.Infrastructure.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Infrastructure;

public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddSingleton<AuditableEntityInterceptor>();
        services.AddDbContext<StoreDbContext>(options => 
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));  
        
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<ISeeder, BrandSeeder>();
        services.AddScoped<ISeeder, TypeSeeder>();
        services.AddScoped<ISeeder, ProductSeeder>();
        services.AddScoped<SeederCoordinator>();


        return services;
    }
}
