using ECommerce.Application.Common.Results;

namespace ECommerce.API.Common.Responses;

public class ApiResponse<T>(bool success, T? data, ApiError? error)
{
    public bool Success { get; } = success;

    public T? Data { get; } = data;

    public ApiError? Error { get; } = error;



    public static ApiResponse<T> Ok(T data)
        => new(true,data,null);

    public static ApiResponse<T> Fail(ApiError error)
        => new(false,default,error);

    public static ApiResponse<T> FromResult (Result<T> result)
    {
        if(result.IsSuccess)
            return Ok(result.Value!);

        var apiError=ApiError.FromApplicationError(result.Error!);

        return Fail(apiError);
    }
}


