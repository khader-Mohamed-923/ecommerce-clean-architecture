using ECommerce.Domain.Entities;
using ECommerce.Application.Products.Dtos;
using ECommerce.Application.Specifications;

namespace ECommerce.Application.Products.Specifications;

public sealed class ProductByIdSpecification : Specification<Product, GetByIdProductResponse>
{
    public ProductByIdSpecification(Guid id)
    {
        Query
            .Where(product => product.Id == id)
            .Select(product => new GetByIdProductResponse(
                product.Id,
                product.Name,
                product.Description,
                product.Price,
                product.PictureUrl,
                product.ProductType.Name,
                product.ProductBrand.Name));
    }
}
