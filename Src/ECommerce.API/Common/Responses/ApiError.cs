using ECommerce.Application.Common.Results;

namespace ECommerce.API.Common.Responses;

public class ApiError(string code, string message, int statusCode)
{
    public string Code { get; set; }=code;
    public string Message { get; set; } = message;
    public int StatusCode { get; set; }=statusCode;
    public IReadOnlyList<ValidationError>? Details {  get; set; }

    public static ApiError FromApplicationError(Error error)
    {
        var statusCode = error.Code switch
        {
            var c when c.StartsWith("Auth.Unauthorized") => 401,
            var c when c.StartsWith("Auth.Forbidden") => 403,
            var c when c.StartsWith("Validation") => 400,
            var c when c.Contains("NotFound") => 404,
            var c when c.Contains("AlreadyExists") => 409,
            var c when c.StartsWith("Server") => 500,
            _ => 400
        };

        return new ApiError(error.Code, error.Message, statusCode);
    }

    public static ApiError Validation(string message, List<ValidationError>? details = null)
    {
        return new ApiError("Validation.Error", message, 400) { Details = details };
    }
}
