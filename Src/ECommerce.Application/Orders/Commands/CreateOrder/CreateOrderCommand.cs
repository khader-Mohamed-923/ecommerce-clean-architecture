using ECommerce.Domain.Shared;
using ECommerce.Application.Messaging;
using ECommerce.Application.Orders.Dtos;

namespace ECommerce.Application.Orders.Commands.CreateOrder;

public sealed record CreateOrderCommand(
    Guid ShippingAddressId,
    Guid DeliveryMethodId) : ICommand<Result<OrderResponse>>;
