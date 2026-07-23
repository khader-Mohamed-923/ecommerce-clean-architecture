using ECommerce.Domain.Shared;
using ECommerce.Application.DeliveryMethods.Dtos;
using ECommerce.Application.Messaging;

namespace ECommerce.Application.DeliveryMethods.Commands.CreateDeliveryMethod;

public sealed record CreateDeliveryMethodCommand(
    string Name,
    decimal Price,
    string EstimatedDeliveryTime,
    string? Description = null,
    bool IsAvailable = true,
    int DisplayOrder = 0) : ICommand<Result<DeliveryMethodResponse>>;
