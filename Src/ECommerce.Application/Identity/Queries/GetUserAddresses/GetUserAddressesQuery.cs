using ECommerce.Domain.Shared;
using ECommerce.Application.Identity.Dtos;
using ECommerce.Application.Messaging;

namespace ECommerce.Application.Identity.Queries.GetUserAddresses;

public sealed record GetUserAddressesQuery
    : IQuery<Result<IReadOnlyList<UserAddressResponse>>>;
