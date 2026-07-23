using ECommerce.Domain.Entities;
using ECommerce.Domain.Repositories;
using ECommerce.Domain.Shared;
using ECommerce.Application.DeliveryMethods.Dtos;
using ECommerce.Application.DeliveryMethods.Specifications;
using ECommerce.Application.Messaging;

namespace ECommerce.Application.DeliveryMethods.Queries.GetDeliveryMethods;

public sealed class GetDeliveryMethodsQueryHandler(IReadRepository<DeliveryMethod> repository)
    : IRequestHandler<GetDeliveryMethodsQuery, Result<IReadOnlyList<DeliveryMethodResponse>>>
{
    public async Task<Result<IReadOnlyList<DeliveryMethodResponse>>> Handle(
        GetDeliveryMethodsQuery request,
        CancellationToken cancellationToken)
    {
        var items = await repository.ListAsync(
            new DeliveryMethodsListSpecification(request.AvailableOnly),
            cancellationToken);

        return Result<IReadOnlyList<DeliveryMethodResponse>>.Success(items);
    }
}
