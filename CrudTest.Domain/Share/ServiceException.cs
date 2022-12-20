namespace CrudTest.Domain.Share;

public record ServiceException
{
    public string Type { get; init; }
    public string Message { get; init; }
    public string StackTrace { get; init; }
}