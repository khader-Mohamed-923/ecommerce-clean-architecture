
using ECommerce.Application.Common.Specifications;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Features.Products.Specifications;

public class ProductByIdSpec : BaseSpecification<Product>
{
    public ProductByIdSpec(Guid id)
        : base(p => p.Id == id)
    {
        AddInclude(p => p.Brand);
        AddInclude(p => p.ProductType);
    }

}
