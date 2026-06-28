using ECommerce.Application.Common.Results;
using ECommerce.Application.Features.Products.Dtos;
using ECommerce.Application.Features.Products.Queries;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Features.Products.Handlers;

public class GetAllBrandsQueryHandler : IRequestHandler<GetAllBrandsQuery, Result<IReadOnlyList<BrandDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllBrandsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<IReadOnlyList<BrandDto>>> Handle(GetAllBrandsQuery request, CancellationToken ct)
    {
        var brands = await _unitOfWork
                                     .Repository<ProductBrand>()
                                     .GetAllAsync(ct);
        var dtos = _mapper.Map<IReadOnlyList<BrandDto>>(brands);
        return Result<IReadOnlyList<BrandDto>>.Success(dtos);
    }
}
