using ECommerce.Domain.Shared;
using ECommerce.Application.Messaging;
using ECommerce.Application.Orders.Dtos;

namespace ECommerce.Application.Orders.Commands.CancelOrder;

public sealed record CancelOrderCommand(Guid OrderId) : ICommand<Result<OrderResponse>>;
