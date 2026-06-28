using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ECommerce.Infrastructure.Persistence.Seeders;

public class BrandSeeder : ISeeder
{
    private readonly StoreDbContext _context;
    private readonly ILogger<BrandSeeder> _logger;

    public BrandSeeder(StoreDbContext context, ILogger<BrandSeeder> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task SeedAsync(CancellationToken cancellationToken = default)
    {
        if (await _context.ProductBrands.AnyAsync(cancellationToken))
            return;

        var brands = new List<ProductBrand>
        {
            ProductBrand.Create("Nike"),
            ProductBrand.Create("Zara"),
            ProductBrand.Create("H&M"),
            ProductBrand.Create("Levi's"),
            ProductBrand.Create("Gucci"),
            ProductBrand.Create("Ralph Lauren"),
            ProductBrand.Create("Calvin Klein"),
            ProductBrand.Create("Tommy Hilfiger"),
        };

        await _context.ProductBrands.AddRangeAsync(brands, cancellationToken);
        _logger.LogInformation("Seeded {Count} brands.", brands.Count);
    }
}