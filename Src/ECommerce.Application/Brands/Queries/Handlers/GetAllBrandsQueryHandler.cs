using ECommerce.Domain.Entities;
using ECommerce.Domain.Repositories;
using ECommerce.Domain.Shared;
using ECommerce.Application.Brands.Dtos;
using ECommerce.Application.Brands.Queries;
using ECommerce.Application.Brands.Specifications;
using ECommerce.Application.Messaging;

namespace ECommerce.Application.Brands.Queries.Handlers;

public sealed class GetAllBrandsQueryHandler(IReadRepository<ProductBrand> repository)
    : IRequestHandler<GetAllBrandsQuery, Result<IReadOnlyList<GetAllBrandsResponse>>>
{
    public async Task<Result<IReadOnlyList<GetAllBrandsResponse>>> Handle(
        GetAllBrandsQuery request,
        CancellationToken cancellationToken)
    {
        var brands = await repository.ListAsync(new BrandsListSpecification(), cancellationToken);
        return Result<IReadOnlyList<GetAllBrandsResponse>>.Success(brands);
    }
}
