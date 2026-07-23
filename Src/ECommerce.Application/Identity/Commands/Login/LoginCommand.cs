using ECommerce.Domain.Shared;
using ECommerce.Application.Identity.Dtos;
using ECommerce.Application.Messaging;

namespace ECommerce.Application.Identity.Commands.Login;

public sealed record LoginCommand(
    string Email,
    string Password) : ICommand<Result<AuthResponse>>;
