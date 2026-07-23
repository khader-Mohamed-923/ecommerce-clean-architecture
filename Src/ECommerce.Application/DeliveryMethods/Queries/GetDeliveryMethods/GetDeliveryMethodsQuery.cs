using ECommerce.Domain.Shared;
using ECommerce.Application.DeliveryMethods.Dtos;
using ECommerce.Application.Messaging;

namespace ECommerce.Application.DeliveryMethods.Queries.GetDeliveryMethods;

public sealed record GetDeliveryMethodsQuery(
    bool AvailableOnly = true) : IQuery<Result<IReadOnlyList<DeliveryMethodResponse>>>;
