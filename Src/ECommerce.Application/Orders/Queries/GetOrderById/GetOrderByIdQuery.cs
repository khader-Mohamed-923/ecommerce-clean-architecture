using ECommerce.Domain.Shared;
using ECommerce.Application.Messaging;
using ECommerce.Application.Orders.Dtos;

namespace ECommerce.Application.Orders.Queries.GetOrderById;

public sealed record GetOrderByIdQuery(Guid OrderId) : IQuery<Result<OrderResponse>>;
