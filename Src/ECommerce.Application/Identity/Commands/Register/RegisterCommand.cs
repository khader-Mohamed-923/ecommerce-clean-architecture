using ECommerce.Domain.Shared;
using ECommerce.Application.Identity.Dtos;
using ECommerce.Application.Messaging;

namespace ECommerce.Application.Identity.Commands.Register;

public sealed record RegisterCommand(
    string Email,
    string Password,
    string? DisplayName) : ICommand<Result<EmailSentResponse>>;
