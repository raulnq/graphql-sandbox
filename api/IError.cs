namespace api;

public interface IError
{
    string Message { get; set; }
}

public class MaxLengthError : IError
{
    public string Message { get; set; } = null!;

    public MaxLengthError(string field, int maxLength)
    {
        Message = $"The max length for {field} is {maxLength}";
    }
}
public class NotEmptyError : IError
{
    public string Message { get; set; } = null!;

    public NotEmptyError(string field)
    {
        Message = $"The {field} is required";
    }
}
