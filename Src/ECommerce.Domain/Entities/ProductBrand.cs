namespace ECommerce.Domain.Entities;

 public class ProductBrand : BaseEntity
 {
    public string Name { get; private set; } = null!;

    public ICollection<Product> Products { get; private set; } = [];

    private ProductBrand() { }

    public static ProductBrand Create(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        return new ProductBrand
        {
            Name = name
        };
    }

    public void Update(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        Name = name;
    }

}