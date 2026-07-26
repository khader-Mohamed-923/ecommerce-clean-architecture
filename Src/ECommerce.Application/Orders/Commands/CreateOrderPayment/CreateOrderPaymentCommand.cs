using ECommerce.Domain.Shared;
using ECommerce.Application.Messaging;
using ECommerce.Application.Orders.Dtos;

namespace ECommerce.Application.Orders.Commands.CreateOrderPayment;

public sealed record CreateOrderPaymentCommand(Guid OrderId)
    : ICommand<Result<PaymentClientSecretResponse>>;
