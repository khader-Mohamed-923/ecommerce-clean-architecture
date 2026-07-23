using ECommerce.Domain.Repositories;
using ECommerce.Infrastructure.Persistence.DbContexts;
using ECommerce.Infrastructure.Persistence.Interceptors;
using ECommerce.Infrastructure.Persistence.Seeders;
using ECommerce.Infrastructure.Repositories;
using ECommerce.Infrastructure.Caching;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IAuditInterceptor, AuditInterceptor>();
        services.AddSingleton<ISoftDeleteInterceptor, SoftDeleteInterceptor>();

        services.AddDbContext<StoreDbContext>(options => 
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));  
        
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped(typeof(IReadRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<ISeeder, BrandSeeder>();
        services.AddScoped<ISeeder, TypeSeeder>();
        services.AddScoped<ISeeder, ProductSeeder>();
        services.AddScoped<SeederCoordinator>();
        
        // Caching
        services.AddSingleton<CacheEntryPolicyValidator>();
#pragma warning disable EXTEXP0018 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
        services.AddHybridCache();
#pragma warning restore EXTEXP0018 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
        services.AddScoped(typeof(ICachedAggregateStore<>), typeof(HybridCacheAggregateStore<>));
        services.AddScoped<IBasketStore, HybridBasketStore>();

        services.Configure<ECommerce.Application.Common.Settings.CloudinarySettings>(configuration.GetSection("CloudinarySettings"));
        services.AddScoped<ECommerce.Application.Common.Interfaces.IAttachmentService, ECommerce.Infrastructure.Services.AttachmentService>();

        return services;
    }
}
