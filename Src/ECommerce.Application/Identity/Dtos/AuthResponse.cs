namespace ECommerce.Application.Identity.Dtos;

public sealed record AuthResponse(
    Guid UserId,
    string Email,
    string? DisplayName,
    string AccessToken,
    DateTimeOffset ExpiresAtUtc,
    string RefreshToken,
    DateTimeOffset RefreshTokenExpiresAtUtc);
