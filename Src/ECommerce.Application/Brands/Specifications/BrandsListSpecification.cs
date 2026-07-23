using ECommerce.Domain.Entities;
using ECommerce.Application.Brands.Dtos;
using ECommerce.Application.Specifications;

namespace ECommerce.Application.Brands.Specifications;

public sealed class BrandsListSpecification : Specification<ProductBrand, GetAllBrandsResponse>
{
    public BrandsListSpecification()
    {
        Query
            .OrderBy(brand => brand.Name)
            .Select(brand => new GetAllBrandsResponse(brand.Id, brand.Name));
    }
}
