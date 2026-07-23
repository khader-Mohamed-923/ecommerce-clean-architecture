using ECommerce.Domain.Shared;
using ECommerce.Application.Messaging;
using ECommerce.Application.Types.Dtos;

namespace ECommerce.Application.Types.Queries;

public sealed record GetAllTypesQuery : IQuery<Result<IReadOnlyList<GetAllTypesResponse>>>;
