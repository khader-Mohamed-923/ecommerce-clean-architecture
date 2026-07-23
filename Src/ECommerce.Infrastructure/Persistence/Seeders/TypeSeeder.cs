using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Persistence.DbContexts;
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
        var existingTypes = await _context.ProductTypes.Select(t => t.Name).ToListAsync(cancellationToken);

        var predefinedTypes = new List<ProductType>
        {
            ProductType.Create(Guid.NewGuid(), "T-Shirts").Value,
            ProductType.Create(Guid.NewGuid(), "Jackets").Value,
            ProductType.Create(Guid.NewGuid(), "Pants").Value,
            ProductType.Create(Guid.NewGuid(), "Shoes").Value,
            ProductType.Create(Guid.NewGuid(), "Dresses").Value,
            ProductType.Create(Guid.NewGuid(), "Accessories").Value,
        };

        var typesToInsert = predefinedTypes.Where(t => !existingTypes.Contains(t.Name)).ToList();

        if (typesToInsert.Count == 0)
        {
            _logger.LogInformation("Skipping TypeSeeder because all predefined types already exist.");
            return;
        }

        await _context.ProductTypes.AddRangeAsync(typesToInsert, cancellationToken);
        _logger.LogInformation("Seeded {Count} missing types.", typesToInsert.Count);
    }
}