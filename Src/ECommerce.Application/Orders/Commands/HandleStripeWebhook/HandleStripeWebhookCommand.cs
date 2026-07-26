using ECommerce.Domain.Shared;
using ECommerce.Application.Messaging;

namespace ECommerce.Application.Orders.Commands.HandleStripeWebhook;

public sealed record HandleStripeWebhookCommand(
    string Payload,
    string Signature) : ICommand<Result>;
