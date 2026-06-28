using ECommerce.API.Common.Responses;
using ECommerce.Application.Common.Results;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Extensions;

public static class ResultExtensions
{
    public static ActionResult<ApiResponse<T>> ToActionResult<T>(this Result<T> result)
    {
        var response=ApiResponse<T>.FromResult(result);

        if (response.Success)
            return new OkObjectResult(response);


        return new ObjectResult(response)
        {
            StatusCode = response.Error!.StatusCode
        };

    }
}
