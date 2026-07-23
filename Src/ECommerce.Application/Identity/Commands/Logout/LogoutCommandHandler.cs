using ECommerce.Domain.Errors;
using ECommerce.Domain.Shared;
using ECommerce.Application.Common.Interfaces;
using ECommerce.Application.Messaging;

namespace ECommerce.Application.Identity.Commands.Logout;

public sealed class LogoutCommandHandler
    : IRequestHandler<LogoutCommand, Result>
{
    private readonly IRefreshTokenService _refreshTokenService;

    public LogoutCommandHandler(IRefreshTokenService refreshTokenService)
    {
        _refreshTokenService = refreshTokenService;
    }

    public async Task<Result> Handle(
        LogoutCommand request,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.RefreshToken))
            return Result.Failure(IdentityErrors.InvalidRefreshToken);

        return await _refreshTokenService.RevokeAsync(
            request.RefreshToken.Trim(),
            cancellationToken);
    }
}
