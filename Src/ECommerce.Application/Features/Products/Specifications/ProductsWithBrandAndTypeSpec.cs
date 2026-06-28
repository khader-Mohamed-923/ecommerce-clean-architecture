using ECommerce.Application.Common.Specifications;
using ECommerce.Domain.Entities;


namespace ECommerce.Application.Features.Products.Specifications;

public class ProductsWithBrandAndTypeSpec : BaseSpecification<Product>
{
    public ProductsWithBrandAndTypeSpec()
    {
        AddInclude(p => p.Brand);
        AddInclude(p => p.ProductType);
        AddOrderBy(p => p.Name);
    }
}
