using ECommerce.Domain.Entities;
using ECommerce.Domain.Errors;
using ECommerce.Domain.Repositories;
using ECommerce.Domain.Shared;
using ECommerce.Application.DeliveryMethods.Dtos;
using ECommerce.Application.DeliveryMethods.Specifications;
using ECommerce.Application.Messaging;

namespace ECommerce.Application.DeliveryMethods.Queries.GetDeliveryMethodById;

public sealed class GetDeliveryMethodByIdQueryHandler(IReadRepository<DeliveryMethod> repository)
    : IRequestHandler<GetDeliveryMethodByIdQuery, Result<DeliveryMethodResponse>>
{
    public async Task<Result<DeliveryMethodResponse>> Handle(
        GetDeliveryMethodByIdQuery request,
        CancellationToken cancellationToken)
    {
        var item = await repository.FirstOrDefaultAsync(
            new DeliveryMethodByIdSpecification(request.Id),
            cancellationToken);

        if (item is null)
            return Result<DeliveryMethodResponse>.Failure(DeliveryMethodErrors.NotFound);

        return Result<DeliveryMethodResponse>.Success(item);
    }
}
