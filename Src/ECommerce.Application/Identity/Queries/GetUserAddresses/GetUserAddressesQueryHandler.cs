using ECommerce.Domain.Entities;
using ECommerce.Domain.Errors;
using ECommerce.Domain.Repositories;
using ECommerce.Domain.Shared;
using ECommerce.Application.Common.Interfaces;
using ECommerce.Application.Identity.Dtos;
using ECommerce.Application.Identity.Specifications;
using ECommerce.Application.Messaging;

namespace ECommerce.Application.Identity.Queries.GetUserAddresses;

public sealed class GetUserAddressesQueryHandler(
    ICurrentUserService currentUser,
    IReadRepository<UserAddress> addressRepository)
    : IRequestHandler<GetUserAddressesQuery, Result<IReadOnlyList<UserAddressResponse>>>
{
    public async Task<Result<IReadOnlyList<UserAddressResponse>>> Handle(
        GetUserAddressesQuery request,
        CancellationToken cancellationToken)
    {
        if (currentUser.UserId is null)
            return Result<IReadOnlyList<UserAddressResponse>>.Failure(IdentityErrors.InvalidCredentials);

        var addresses = await addressRepository.ListAsync(
            new UserAddressesByUserIdSpecification(currentUser.UserId.Value),
            cancellationToken);

        return Result<IReadOnlyList<UserAddressResponse>>.Success(addresses);
    }
}
