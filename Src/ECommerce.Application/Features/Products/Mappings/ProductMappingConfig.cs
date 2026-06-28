using ECommerce.Application.Features.Products.Dtos;
using ECommerce.Domain.Entities;
using Mapster;

namespace ECommerce.Application.Features.Products.Mappings;

public class ProductMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Product, ProductDto>()
            .Map(dest => dest.Brand, src => src.Brand.Name)
            .Map(dest => dest.Type, src => src.ProductType.Name);

    }
}