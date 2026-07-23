using ECommerce.Domain.Entities;
using ECommerce.Application.Products.Dtos;
using ECommerce.Application.Specifications;

namespace ECommerce.Application.Products.Specifications;

public sealed class ProductForBasketSpecification : Specification<Product, ProductForBasketResponse>
{
    public ProductForBasketSpecification(Guid productId)
    {
        Query
            .Where(product => product.Id == productId)
            .Select(product => new ProductForBasketResponse(
                product.Id,
                product.Name,
                product.PictureUrl,
                product.Price));
    }
}
