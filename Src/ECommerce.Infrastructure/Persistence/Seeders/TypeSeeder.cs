using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ECommerce.Infrastructure.Persistence.Seeders;

public class TypeSeeder : ISeeder
{
    private readonly StoreDbContext _context;
    private readonly ILogger<TypeSeeder> _logger;

    public TypeSeeder(StoreDbContext context, ILogger<TypeSeeder> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task SeedAsync(CancellationToken cancellationToken = default)
    {
        if (await _context.ProductTypes.AnyAsync(cancellationToken))
            return;

        var types = new List<ProductType>
        {
            ProductType.Create("T-Shirts"),
            ProductType.Create("Jackets"),
            ProductType.Create("Pants"),
            ProductType.Create("Shoes"),
            ProductType.Create("Dresses"),
            ProductType.Create("Accessories"),
        };

        await _context.ProductTypes.AddRangeAsync(types, cancellationToken);
        _logger.LogInformation("Seeded {Count} types.", types.Count);
    }
}