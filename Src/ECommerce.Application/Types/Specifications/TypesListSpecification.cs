using ECommerce.Domain.Entities;
using ECommerce.Application.Specifications;
using ECommerce.Application.Types.Dtos;

namespace ECommerce.Application.Types.Specifications;

public sealed class TypesListSpecification : Specification<ProductType, GetAllTypesResponse>
{
    public TypesListSpecification()
    {
        Query
            .OrderBy(type => type.Name)
            .Select(type => new GetAllTypesResponse(type.Id, type.Name));
    }
}
