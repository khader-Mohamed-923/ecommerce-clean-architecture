using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ECommerce.Infrastructure.Persistence.Seeders;

public class ProductSeeder : ISeeder
{
    private readonly StoreDbContext _context;
    private readonly ILogger<ProductSeeder> _logger;

    public ProductSeeder(StoreDbContext context, ILogger<ProductSeeder> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task SeedAsync(CancellationToken cancellationToken = default)
    {
        var existingProductNames = await _context.Products.Select(p => p.Name).ToListAsync(cancellationToken);

        var brands = await _context.ProductBrands.ToListAsync(cancellationToken);
        var types = await _context.ProductTypes.ToListAsync(cancellationToken);

        var nike = brands.First(b => b.Name == "Nike");
        var zara = brands.First(b => b.Name == "Zara");
        var hm = brands.First(b => b.Name == "H&M");
        var levis = brands.First(b => b.Name == "Levi's");
        var gucci = brands.First(b => b.Name == "Gucci");
        var ralph = brands.First(b => b.Name == "Ralph Lauren");
        var calvin = brands.First(b => b.Name == "Calvin Klein");
        var tommy = brands.First(b => b.Name == "Tommy Hilfiger");

        var tshirts = types.First(t => t.Name == "T-Shirts");
        var jackets = types.First(t => t.Name == "Jackets");
        var pants = types.First(t => t.Name == "Pants");
        var shoes = types.First(t => t.Name == "Shoes");
        var dresses = types.First(t => t.Name == "Dresses");
        var accessories = types.First(t => t.Name == "Accessories");

        var products = new List<Product>
        {
            Product.Create(Guid.NewGuid(), "Casual Sneakers", "Lightweight and comfortable casual sneakers", "https://res.cloudinary.com/dhteh60i7/image/upload/v1782605485/CasualSneakers_f91jmw.jpg", 49.99m, nike.Id, shoes.Id).Value,
            Product.Create(Guid.NewGuid(), "Classic Black Dress Pants", "Elegant slim-fit dress pants for formal occasions", "https://res.cloudinary.com/dhteh60i7/image/upload/v1782605485/ClassicBlackDressPants_hb3xcc.jpg", 79.99m, zara.Id, pants.Id).Value,
            Product.Create(Guid.NewGuid(), "Classic White T-Shirt", "Essential everyday cotton white t-shirt", "https://res.cloudinary.com/dhteh60i7/image/upload/v1782605486/ClassicWhiteTShirt_t3nm7m.jpg", 19.99m, hm.Id, tshirts.Id).Value,
            Product.Create(Guid.NewGuid(), "Cotton Hoodie", "Soft and warm everyday cotton hoodie", "https://res.cloudinary.com/dhteh60i7/image/upload/v1782605487/CottonHoodie_oxwnwd.jpg", 59.99m, ralph.Id, tshirts.Id).Value,
            Product.Create(Guid.NewGuid(), "Denim Jacket", "Classic blue denim jacket for all seasons", "https://res.cloudinary.com/dhteh60i7/image/upload/v1782605488/DenimJacket_xbgdhm.jpg", 89.99m, levis.Id, jackets.Id).Value,
            Product.Create(Guid.NewGuid(), "Formal Blazer", "Premium slim-fit formal blazer", "https://res.cloudinary.com/dhteh60i7/image/upload/v1782605489/FormalBlazer_mdp5i3.jpg", 199.99m, gucci.Id, jackets.Id).Value,
            Product.Create(Guid.NewGuid(), "Knitted Sweater", "Cozy cable-knit wool sweater", "https://res.cloudinary.com/dhteh60i7/image/upload/v1782605490/KnittedSweater_mbz0tc.jpg", 69.99m, calvin.Id, jackets.Id).Value,
            Product.Create(Guid.NewGuid(), "Men's Leather Jacket", "Premium genuine leather biker jacket", "https://res.cloudinary.com/dhteh60i7/image/upload/v1782605492/MensLeatherJacket_k527wf.jpg", 299.99m, tommy.Id, jackets.Id).Value,
            Product.Create(Guid.NewGuid(), "Men's Polo Shirt", "Classic navy polo shirt with embroidered logo", "https://res.cloudinary.com/dhteh60i7/image/upload/v1782605492/MensPoloShirt_njh1xh.jpg", 39.99m, ralph.Id, tshirts.Id).Value,
            Product.Create(Guid.NewGuid(), "Slim Fit Jeans", "Modern slim fit stretch denim jeans", "https://res.cloudinary.com/dhteh60i7/image/upload/v1782605492/SlimFitJeans_psrcfp.jpg", 69.99m, levis.Id, pants.Id).Value,
            Product.Create(Guid.NewGuid(), "Summer Floral Dress", "Light and beautiful floral summer dress", "https://res.cloudinary.com/dhteh60i7/image/upload/v1782605493/SummerFloralDress_a0z5f9.jpg", 54.99m, zara.Id, dresses.Id).Value,
            Product.Create(Guid.NewGuid(), "Women's Trench Coat", "Classic beige double-breasted trench coat", "https://res.cloudinary.com/dhteh60i7/image/upload/v1782605494/WomensTrenchCoat_epfvqu.jpg", 149.99m, gucci.Id, jackets.Id).Value,
            Product.Create(Guid.NewGuid(), "Wool Scarf", "Warm knitted wool scarf for winter", "https://res.cloudinary.com/dhteh60i7/image/upload/v1782605495/WoolScarf_bblcmz.jpg", 29.99m, calvin.Id, accessories.Id).Value
        };

        var productsToInsert = products.Where(p => !existingProductNames.Contains(p.Name)).ToList();

        if (productsToInsert.Count == 0)
        {
            _logger.LogInformation("Skipping ProductSeeder because all predefined products already exist.");
            return;
        }

        await _context.Products.AddRangeAsync(productsToInsert, cancellationToken);
        _logger.LogInformation("Seeded {Count} missing products.", productsToInsert.Count);
    }
}