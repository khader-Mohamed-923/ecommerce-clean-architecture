using ECommerce.Application.Common.Results;
using ECommerce.Application.Features.Products.Dtos;
using ECommerce.Application.Features.Products.Queries;
using ECommerce.Application.Features.Products.Specifications;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MapsterMapper;
using MediatR;


namespace ECommerce.Application.Features.Products.Handlers;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Result<ProductDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;


    public GetProductByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<ProductDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var spec = new ProductByIdSpec(request.Id);
        var product = await _unitOfWork
                                      .Repository<Product>()
                                      .GetEntityWithSpecAsync(spec, cancellationToken);


        if (product is null)
            return Result<ProductDto>.Failure(Error.NotFound("Product",request.Id));

        var productDto = _mapper.Map<ProductDto>(product);


        return Result<ProductDto>.Success(productDto);
    }
}
