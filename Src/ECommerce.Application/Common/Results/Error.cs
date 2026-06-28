

namespace ECommerce.Application.Common.Results;

public sealed class Error(string code, string message)
{
    public string Code { get;} = code;
    public string Message { get;} = message;

    public static Error NotFound(string resource, Guid id)
        => new($"{resource}.NotFound",$"{resource} with id '{id}' was not found");

    public static Error Validation(string field, string message)
        => new($"Validation.{field}", message);
    public static Error Validation(string message)
        => new($"Validation.Error", message);

    public static Error Conflict(string resource,string identifier)
        => new($"{resource}.AlreadyExists", $"{resource} '{identifier}' already exists");


    public static Error Unauthorized(string message = "You are not authorized")
       => new("Auth.Unauthorized", message);


    public static Error Forbidden(string message = "Access denied")
    => new("Auth.Forbidden", message);





}
