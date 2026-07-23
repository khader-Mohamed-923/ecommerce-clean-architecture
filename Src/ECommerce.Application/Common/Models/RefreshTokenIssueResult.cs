namespace ECommerce.Application.Common.Models;

public sealed record RefreshTokenIssueResult(
    Guid UserId,
    string Token,
    DateTimeOffset ExpiresAtUtc);
