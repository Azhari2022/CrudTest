using CrudTest.Domain.Share;

namespace CrudTest.Domain.Commands;

public class Response
{
    public int StatusCode { get; set; } = 200;
    public string Message { get; set; } = "OK";
    public Guid? RequestId { get; set; }
    public ServiceException Exception { get; set; }
    public List<ServiceSubStatus> SubStatuses { get; set; }

    public Response()
    {

    }
    public Response(int statusCode, string message, Guid? requestId = null, ServiceException exception = null, List<ServiceSubStatus> subStatuses = null)
    {
        StatusCode = statusCode;
        Message = message;
        RequestId = requestId;
        Exception = exception;
        SubStatuses = subStatuses;
    }

}

public class Response<T> : Response
{
    public T Data { get; set; }
    public Response(T data, int statusCode, string message, Guid? requestId = null, ServiceException exception = null, List<ServiceSubStatus> subStatuses = null)
        : base(statusCode, message, requestId, exception, subStatuses)
    {
        Data = data;
    }
    public Response(T data, Response res) : base(res.StatusCode, res.Message, res.RequestId, res.Exception,
        res.SubStatuses)
    {
        Data = data;
    }

    public Response(T data)
    {
        Data = data;
    }

    public Response() : this(default(T)!, new Response())
    {
    }
}