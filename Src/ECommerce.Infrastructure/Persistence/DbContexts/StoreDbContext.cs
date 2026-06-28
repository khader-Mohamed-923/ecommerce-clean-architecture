using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Data.DbContexts;

public class StoreDbContext : DbContext
{
    public readonly AuditableEntityInterceptor _auditableEntityInterceptor;
    public StoreDbContext(
        DbContextOptions<StoreDbContext> options,
        AuditableEntityInterceptor interceptor) : base(options)
    {
        _auditableEntityInterceptor = interceptor;
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductBrand> ProductBrands => Set<ProductBrand>();
    public DbSet<ProductType> ProductTypes => Set<ProductType>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableEntityInterceptor);
       
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreDbContext).Assembly);
    }

}

