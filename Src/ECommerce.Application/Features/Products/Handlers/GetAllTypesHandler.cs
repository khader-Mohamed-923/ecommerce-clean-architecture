using ECommerce.Application.Common.Results;
using ECommerce.Application.Features.Products.Dtos;
using ECommerce.Application.Features.Products.Queries;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MapsterMapper;
using MediatR;


namespace ECommerce.Application.Features.Products.Handlers;

public class GetAllTypesQueryHandler : IRequestHandler<GetAllTypesQuery, Result<IReadOnlyList<TypeDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllTypesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<IReadOnlyList<TypeDto>>> Handle(GetAllTypesQuery request, CancellationToken ct)
    {
        var types = await _unitOfWork
                                  .Repository<ProductType>()
                                  .GetAllAsync(ct);
        var dtos = _mapper.Map<IReadOnlyList<TypeDto>>(types);
        return Result<IReadOnlyList<TypeDto>>.Success(dtos);
    }
}