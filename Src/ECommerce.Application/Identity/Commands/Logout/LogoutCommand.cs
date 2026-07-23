using ECommerce.Domain.Shared;
using ECommerce.Application.Messaging;

namespace ECommerce.Application.Identity.Commands.Logout;

public sealed record LogoutCommand(
    string RefreshToken) : ICommand<Result>;
