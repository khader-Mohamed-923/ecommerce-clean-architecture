using ECommerce.Application.Common.Results;
using ECommerce.Application.Features.Products.Dtos;
using MediatR;


namespace ECommerce.Application.Features.Products.Queries;

public record GetAllTypesQuery : IRequest<Result<IReadOnlyList<TypeDto>>>;
