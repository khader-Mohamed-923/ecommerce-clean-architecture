using ECommerce.Domain.Shared;
using ECommerce.Application.DeliveryMethods.Dtos;
using ECommerce.Application.Messaging;

namespace ECommerce.Application.DeliveryMethods.Queries.GetDeliveryMethodById;

public sealed record GetDeliveryMethodByIdQuery(Guid Id)
    : IQuery<Result<DeliveryMethodResponse>>;
