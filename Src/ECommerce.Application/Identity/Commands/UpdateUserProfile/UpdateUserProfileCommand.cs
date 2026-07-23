using ECommerce.Domain.Shared;
using ECommerce.Application.Identity.Dtos;
using ECommerce.Application.Messaging;

namespace ECommerce.Application.Identity.Commands.UpdateUserProfile;

public sealed record UpdateUserProfileCommand(string? DisplayName)
    : ICommand<Result<UserProfileResponse>>;
