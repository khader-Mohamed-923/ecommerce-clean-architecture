using ECommerce.Application.Common.Results;
using ECommerce.Application.Features.Products.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Features.Products.Queries;

public record GetProductByIdQuery(Guid Id) : IRequest<Result<ProductDto>>;
