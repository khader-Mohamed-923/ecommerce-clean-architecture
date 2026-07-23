using ECommerce.Domain.Entities;
using ECommerce.Domain.Repositories;
using ECommerce.Domain.Shared;
using ECommerce.Application.Messaging;
using ECommerce.Application.Types.Dtos;
using ECommerce.Application.Types.Queries;
using ECommerce.Application.Types.Specifications;

namespace ECommerce.Application.Types.Queries.Handlers;

public sealed class GetAllTypesQueryHandler(IReadRepository<ProductType> repository)
    : IRequestHandler<GetAllTypesQuery, Result<IReadOnlyList<GetAllTypesResponse>>>
{
    public async Task<Result<IReadOnlyList<GetAllTypesResponse>>> Handle(
        GetAllTypesQuery request,
        CancellationToken cancellationToken)
    {
        var types = await repository.ListAsync(new TypesListSpecification(), cancellationToken);
        return Result<IReadOnlyList<GetAllTypesResponse>>.Success(types);
    }
}
