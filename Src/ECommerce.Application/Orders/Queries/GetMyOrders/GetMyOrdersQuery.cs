using ECommerce.Domain.Repositories;
using ECommerce.Domain.Shared;
using ECommerce.Application.Messaging;
using ECommerce.Application.Orders.Dtos;

namespace ECommerce.Application.Orders.Queries.GetMyOrders;

public sealed record GetMyOrdersQuery(
    int PageNumber = 1,
    int PageSize = 10) : IQuery<Result<PagedResult<OrderResponse>>>;
