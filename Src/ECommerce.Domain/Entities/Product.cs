using System.Collections;

namespace ECommerce.Domain.Entities;


public class Product : BaseEntity
{
    public string Name { get; private set; } = null!;    
    public string Description { get; private set; } = null!;
    public decimal Price { get; private set; }
    public string ImageUrl { get; private set; } = null!;
    public int StockQuantity { get; private set; }
    public Guid ProductTypeId { get; private set; }  
    public ProductType ProductType { get; private set; } = null!; 

    public Guid BrandId { get; private set; }  
    public ProductBrand Brand { get; private set; } = null!;   


    private Product() { }

    public static Product Create(
        string name,
        string descripation,
        decimal price,
        int stockQuantity,
        string imageUrl,
        Guid productTypeId,
        Guid brandId
        )

    {
        ArgumentException.ThrowIfNullOrWhiteSpace( name);
        ArgumentException.ThrowIfNullOrWhiteSpace(descripation);
        ArgumentException.ThrowIfNullOrWhiteSpace(imageUrl);

        if(price  <= 0)
            throw new ArgumentException("Price must be greater than zero.");

        if (stockQuantity < 0)
            throw new ArgumentException("Stock quantity cannot be negative.");

        return new Product
        {
            Name = name,
            Description = descripation,
            Price = price,
            StockQuantity= stockQuantity,
            ImageUrl = imageUrl,
            ProductTypeId = productTypeId,
            BrandId = brandId
        };
    }

    public void Update(
        string name,
        string descripation,
        decimal price,
        string imageUrl
       
    )
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(descripation);
        ArgumentException.ThrowIfNullOrWhiteSpace(imageUrl);
        if (price <= 0)
            throw new ArgumentException("Price must be greater than zero.");
        Name = name;
        Description = descripation;
        Price = price;
        ImageUrl = imageUrl;
    }

    public void AddStock(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.");
         StockQuantity += quantity;
    }

    public void RemoveStock(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.");
        if (quantity > StockQuantity)
            throw new InvalidOperationException("Not enough stock");
        StockQuantity -= quantity;

    }
}