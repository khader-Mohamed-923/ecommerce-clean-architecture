using ECommerce.Domain.Shared;
using ECommerce.Application.Messaging;
using ECommerce.Application.Products.Dtos;

namespace ECommerce.Application.Products.Queries;

public sealed record GetAllProductsQuery : IQuery<Result<IReadOnlyList<GetAllProductsResponse>>>;
