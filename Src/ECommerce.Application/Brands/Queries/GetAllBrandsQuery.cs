using ECommerce.Domain.Shared;
using ECommerce.Application.Brands.Dtos;
using ECommerce.Application.Messaging;

namespace ECommerce.Application.Brands.Queries;

public sealed record GetAllBrandsQuery : IQuery<Result<IReadOnlyList<GetAllBrandsResponse>>>;
