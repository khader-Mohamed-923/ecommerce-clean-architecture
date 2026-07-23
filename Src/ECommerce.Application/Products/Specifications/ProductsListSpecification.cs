using ECommerce.Domain.Entities;
using ECommerce.Application.Products.Dtos;
using ECommerce.Application.Specifications;

namespace ECommerce.Application.Products.Specifications;

public sealed class ProductsListSpecification : Specification<Product, GetAllProductsResponse>
{
    public ProductsListSpecification()
    {
        Query
            .OrderBy(product => product.Name)
            .Select(product => new GetAllProductsResponse(
                product.Id,
                product.Name,
                product.Description,
                product.Price,
                product.PictureUrl,
                product.ProductType.Name,
                product.ProductBrand.Name));
    }
}
