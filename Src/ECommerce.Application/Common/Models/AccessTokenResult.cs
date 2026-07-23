namespace ECommerce.Application.Common.Models;

public sealed record AccessTokenResult(string Token, DateTimeOffset ExpiresAtUtc);
