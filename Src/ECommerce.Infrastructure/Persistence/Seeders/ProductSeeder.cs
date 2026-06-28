using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Data.DbContexts;
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
        if (await _context.Products.AnyAsync(cancellationToken))
            return;

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
         Product.Create(
               "Casual Sneakers",
               "Lightweight and comfortable casual sneakers",
                49.99m, 100,
                "https://res.cloudinary.com/dhteh60i7/image/upload/v1782605485/CasualSneakers_f91jmw.jpg",
                 shoes.Id, nike.Id),

            Product.Create(
                "Classic Black Dress Pants",
                "Elegant slim-fit dress pants for formal occasions",
                79.99m, 60,
                "https://res.cloudinary.com/dhteh60i7/image/upload/v1782605485/ClassicBlackDressPants_hb3xcc.jpg",
                pants.Id, zara.Id),

            Product.Create(
                "Classic White T-Shirt",
                "Essential everyday cotton white t-shirt",
                19.99m, 200,
                "https://res.cloudinary.com/dhteh60i7/image/upload/v1782605486/ClassicWhiteTShirt_t3nm7m.jpg",
                tshirts.Id, hm.Id),

            Product.Create(
                "Cotton Hoodie",
                "Soft and warm everyday cotton hoodie",
                59.99m, 80,
                "https://res.cloudinary.com/dhteh60i7/image/upload/v1782605487/CottonHoodie_oxwnwd.jpg",
                tshirts.Id, ralph.Id),

            Product.Create(
                "Denim Jacket",
                "Classic blue denim jacket for all seasons",
                89.99m, 50,
                "https://res.cloudinary.com/dhteh60i7/image/upload/v1782605488/DenimJacket_xbgdhm.jpg",
                jackets.Id, levis.Id),

            Product.Create(
                "Formal Blazer",
                "Premium slim-fit formal blazer",
                199.99m, 30,
                "https://res.cloudinary.com/dhteh60i7/image/upload/v1782605489/FormalBlazer_mdp5i3.jpg",
                jackets.Id, gucci.Id),

           Product.Create(
                "Knitted Sweater",
                "Cozy cable-knit wool sweater",
                69.99m, 70,
                "https://res.cloudinary.com/dhteh60i7/image/upload/v1782605490/KnittedSweater_mbz0tc.jpg",
                jackets.Id, calvin.Id),

            Product.Create(
                "Men's Leather Jacket",
                "Premium genuine leather biker jacket",
                299.99m, 25,
                "https://res.cloudinary.com/dhteh60i7/image/upload/v1782605492/MensLeatherJacket_k527wf.jpg",
                jackets.Id, tommy.Id),

            Product.Create(
                "Men's Polo Shirt",
                "Classic navy polo shirt with embroidered logo",
                39.99m, 120,
                "https://res.cloudinary.com/dhteh60i7/image/upload/v1782605492/MensPoloShirt_njh1xh.jpg",
                tshirts.Id, ralph.Id),

            Product.Create(
                "Slim Fit Jeans",
                "Modern slim fit stretch denim jeans",
                69.99m, 90,
                "https://res.cloudinary.com/dhteh60i7/image/upload/v1782605492/SlimFitJeans_psrcfp.jpg",
                pants.Id, levis.Id),

            Product.Create(
                "Summer Floral Dress",
                "Light and beautiful floral summer dress",
                54.99m, 45,
                "https://res.cloudinary.com/dhteh60i7/image/upload/v1782605493/SummerFloralDress_a0z5f9.jpg",
                dresses.Id, zara.Id),

            Product.Create(
                "Women's Trench Coat",
                "Classic beige double-breasted trench coat",
                149.99m, 35,
                "https://res.cloudinary.com/dhteh60i7/image/upload/v1782605494/WomensTrenchCoat_epfvqu.jpg",
                jackets.Id, gucci.Id),

            Product.Create(
                "Wool Scarf",
                "Warm knitted wool scarf for winter",
                29.99m, 150,
                "https://res.cloudinary.com/dhteh60i7/image/upload/v1782605495/WoolScarf_bblcmz.jpg",
                accessories.Id, calvin.Id),
        };

        await _context.Products.AddRangeAsync(products, cancellationToken);
        _logger.LogInformation("Seeded {Count} products.", products.Count);
    }
}