using MediatR;
namespace ECommerce.API.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public abstract class BaseController : ControllerBase
{
    private IMediator? _mediator;

    protected IMediator Mediator=>_mediator ??=HttpContext
                                                   .RequestServices
                                                    .GetRequiredService<IMediator>();
}
