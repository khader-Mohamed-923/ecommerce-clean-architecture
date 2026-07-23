using ECommerce.Domain.Repositories;
using ECommerce.Domain.Shared;
using ECommerce.Application.Messaging;
using ECommerce.Application.Products.Dtos;
using ECommerce.Application.Products.Enums;

namespace ECommerce.Application.Products.Queries;

// usecase: 1. query/command 2. handler  3. spec
public sealed record GetPagedProductsQuery(
        int PageNumber = 1,
        int PageSize = 5,
        string? Search = null,
        Guid? BrandId = null,
        Guid? TypeId = null,
        ProductSortField? SortBy = ProductSortField.Name,
        bool SortDescending = false
    ) : IQuery<Result<PagedResult<GetAllProductsResponse>>>;
