namespace ECommerce.Domain.Entities;

 public class ProductType : BaseEntity
 {
    public string Name { get; private set; } = null!;

    public ICollection<Product> Products { get; private set; } = [];


    public ProductType() { }

    public static ProductType Create(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        return new ProductType
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