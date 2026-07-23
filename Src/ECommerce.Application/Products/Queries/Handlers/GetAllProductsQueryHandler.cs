using ECommerce.Domain.Entities;
using ECommerce.Domain.Repositories;
using ECommerce.Domain.Shared;
using ECommerce.Application.Messaging;
using ECommerce.Application.Products.Dtos;
using ECommerce.Application.Products.Specifications;

namespace ECommerce.Application.Products.Queries.Handlers;

public sealed class GetAllProductsQueryHandler(IReadRepository<Product> repository)
    : IRequestHandler<GetAllProductsQuery, Result<IReadOnlyList<GetAllProductsResponse>>>
{
    public async Task<Result<IReadOnlyList<GetAllProductsResponse>>> Handle(
        GetAllProductsQuery request,
        CancellationToken cancellationToken)
    {
        var products = await repository.ListAsync(new ProductsListSpecification(), cancellationToken);
        return Result<IReadOnlyList<GetAllProductsResponse>>.Success(products);
    }
}
