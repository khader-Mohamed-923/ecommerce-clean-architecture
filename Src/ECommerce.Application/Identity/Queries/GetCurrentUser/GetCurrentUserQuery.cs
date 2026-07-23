using ECommerce.Domain.Shared;
using ECommerce.Application.Identity.Dtos;
using ECommerce.Application.Messaging;

namespace ECommerce.Application.Identity.Queries.GetCurrentUser;

public sealed record GetCurrentUserQuery : IQuery<Result<UserProfileResponse>>;
