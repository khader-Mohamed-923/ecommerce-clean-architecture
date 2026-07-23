using ECommerce.Domain.Entities;
using ECommerce.Domain.Repositories;
using ECommerce.Domain.Shared;
using ECommerce.Application.Messaging;
using ECommerce.Application.Products.Dtos;
using ECommerce.Application.Products.Specifications;

namespace ECommerce.Application.Products.Queries.Handlers;

public sealed class GetPagedProductsQueryHandler(IReadRepository<Product> repository)
    : IRequestHandler<GetPagedProductsQuery, Result<PagedResult<GetAllProductsResponse>>>
{
    public async Task<Result<PagedResult<GetAllProductsResponse>>> Handle(
            GetPagedProductsQuery request, CancellationToken cancellationToken)
    {
        var countSpec = new ProductsPagedSpecification(
            request.Search,
            request.BrandId,
            request.TypeId);

        var listSpecificatipn = new ProductsPagedSpecification(
             request.Search,
             request.BrandId,
             request.TypeId,
             request.SortBy,
             request.SortDescending,
             request.PageNumber,
             request.PageSize
            );


        var totalCount = await repository.CountAsync(countSpec, cancellationToken);

        var items = await repository.ListAsync(listSpecificatipn, cancellationToken);

        return Result<PagedResult<GetAllProductsResponse>>.Success(new PagedResult<GetAllProductsResponse>(items, totalCount));
    }
}
