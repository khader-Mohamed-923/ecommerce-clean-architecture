using ECommerce.Domain.Entities;
using ECommerce.Application.Specifications;

namespace ECommerce.Application.Products.Specifications;

public sealed class ProductByNameSpecification : Specification<Product>
{
    public ProductByNameSpecification(string name) =>
        Query.Where(p => p.Name == name);
}
