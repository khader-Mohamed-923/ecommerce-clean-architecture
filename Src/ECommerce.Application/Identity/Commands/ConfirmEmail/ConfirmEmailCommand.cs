using ECommerce.Domain.Shared;
using ECommerce.Application.Messaging;

namespace ECommerce.Application.Identity.Commands.ConfirmEmail;

public sealed record ConfirmEmailCommand(
    string Email,
    string Code) : ICommand<Result>;
