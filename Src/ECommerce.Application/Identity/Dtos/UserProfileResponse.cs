namespace ECommerce.Application.Identity.Dtos;

public sealed record UserProfileResponse(
    Guid UserId,
    string Email,
    string? DisplayName);
