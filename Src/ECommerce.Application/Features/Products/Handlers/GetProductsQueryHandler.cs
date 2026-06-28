using ECommerce.Application.Common.Results;
using ECommerce.Application.Features.Products.Dtos;
using ECommerce.Application.Features.Products.Queries;
using ECommerce.Application.Features.Products.Specifications;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MapsterMapper;
using MediatR;

namespace ECommerce.Application.Features.Products.Handlers;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, Result<IReadOnlyList<ProductDto>>>
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly IMapper _mapper;


    public GetProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<IReadOnlyList<ProductDto>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var spec = new ProductsWithBrandAndTypeSpec();
        var products = await _unitOfWork
                           .Repository<Product>()
                           .GetAllWithSpecAsync(spec);


        var productDtos = _mapper.Map<IReadOnlyList<ProductDto>>(products);

        return Result<IReadOnlyList<ProductDto>>.Success(productDtos);
    }
}
