

namespace ECommerce.Application.Common.Results;

public class Result<T>
{
    public bool IsSuccess { get; }
    public bool IsFailure=>!IsSuccess;

    private readonly T? _value;
    public T? Value =>
                  IsSuccess
                  ? _value! : throw new InvalidOperationException();
    public Error? Error { get; }

    private Result(T? value)
    {
        IsSuccess = true;
        _value = value;
       
    }
    private Result(Error error)
    {
        IsSuccess = false;
        Error = error;
       
    }

    public static Result<T> Success(T value)
    {
        ArgumentNullException.ThrowIfNull(value);
        return new(value);
    }

    public static Result<T> Failure(Error error)
    {
        ArgumentNullException.ThrowIfNull(error);
        return new(error);
    }

}
