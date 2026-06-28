using ECommerce.API.Common.Responses;
using ECommerce.API.Extensions;
using ECommerce.Application.Features.Products.Dtos;
using ECommerce.Application.Features.Products.Queries;

using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers;

public class ProductsController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IReadOnlyList<ProductDto>>>> GetProducts(CancellationToken ct)

    {
        var result = await Mediator.Send(new GetProductsQuery(), ct);
        return result.ToActionResult();

    }

    [HttpGet ("{id:Guid}")]
    public async Task<ActionResult<ApiResponse<ProductDto>>> GetProductById(Guid id,CancellationToken ct)

    {
        var result = await Mediator.Send(new GetProductByIdQuery(id), ct);
        return result.ToActionResult();

    }

    [HttpGet("brands")]
    public async Task<ActionResult<ApiResponse<IReadOnlyList<BrandDto>>>> GetAllBrands(CancellationToken ct)
    {
        var result = await Mediator.Send(new GetAllBrandsQuery(), ct);
        return result.ToActionResult();
    }

    [HttpGet("types")]
    public async Task<ActionResult<ApiResponse<IReadOnlyList<TypeDto>>>> GetAllTypes(CancellationToken ct)
    {
        var result = await Mediator.Send(new GetAllTypesQuery(), ct);
        return result.ToActionResult();
    }



}
