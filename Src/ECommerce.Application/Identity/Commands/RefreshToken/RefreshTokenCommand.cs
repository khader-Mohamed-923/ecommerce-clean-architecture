using ECommerce.Domain.Shared;
using ECommerce.Application.Identity.Dtos;
using ECommerce.Application.Messaging;

namespace ECommerce.Application.Identity.Commands.RefreshToken;

public sealed record RefreshTokenCommand(
    string RefreshToken) : ICommand<Result<AuthResponse>>;
