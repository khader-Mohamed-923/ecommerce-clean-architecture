using ECommerce.Domain.Shared;
using ECommerce.Application.Messaging;

namespace ECommerce.Application.DeliveryMethods.Commands.DeleteDeliveryMethod;

public sealed record DeleteDeliveryMethodCommand(Guid Id) : ICommand<Result>;
