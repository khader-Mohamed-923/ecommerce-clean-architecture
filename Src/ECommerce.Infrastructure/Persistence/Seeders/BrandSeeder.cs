using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Persistence.DbContexts;
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
        var existingBrands = await _context.ProductBrands.Select(b => b.Name).ToListAsync(cancellationToken);

        var predefinedBrands = new List<ProductBrand>
        {
            ProductBrand.Create(Guid.NewGuid(), "Nike").Value,
            ProductBrand.Create(Guid.NewGuid(), "Zara").Value,
            ProductBrand.Create(Guid.NewGuid(), "H&M").Value,
            ProductBrand.Create(Guid.NewGuid(), "Levi's").Value,
            ProductBrand.Create(Guid.NewGuid(), "Gucci").Value,
            ProductBrand.Create(Guid.NewGuid(), "Ralph Lauren").Value,
            ProductBrand.Create(Guid.NewGuid(), "Calvin Klein").Value,
            ProductBrand.Create(Guid.NewGuid(), "Tommy Hilfiger").Value,
        };

        var brandsToInsert = predefinedBrands.Where(b => !existingBrands.Contains(b.Name)).ToList();

        if (brandsToInsert.Count == 0)
        {
            _logger.LogInformation("Skipping BrandSeeder because all predefined brands already exist.");
            return;
        }

        await _context.ProductBrands.AddRangeAsync(brandsToInsert, cancellationToken);
        _logger.LogInformation("Seeded {Count} missing brands.", brandsToInsert.Count);
    }
}