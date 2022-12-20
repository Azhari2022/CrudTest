namespace CrudTest.Domain.Share;

public record ServiceSubStatus
{
    public string Subject { get; init; }
    public int StatusCode { get; init; }
    public string Message { get; init; }
    public ServiceException Exception { get; init; }
}