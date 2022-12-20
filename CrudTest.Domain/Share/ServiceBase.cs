
namespace CrudTest.Domain.Share;
public class ServiceBase
{
    public Response Ok()
    {
        return new();
    }

    public Response<T> Ok<T>(T data)
    {
        return new(data);
    }

    public Response NotFound(string? message = null)
    {
        return new(ServiceStatusEnum.NotFound.Int(), message ?? ServiceStatusEnum.NotFound.ToString());
    }

    public Response<T> NotFound<T>(T data = default!, string? message = null)
    {
        return new(data, ServiceStatusEnum.NotFound.Int(),
            message ?? ServiceStatusEnum.NotFound.ToString());
    }

    public Response BadRequest(string? message = null)
    {
        return new(ServiceStatusEnum.BadRequest.Int(), message ?? ServiceStatusEnum.BadRequest.ToString());
    }

    public Response<T> BadRequest<T>(T data = default!, string? message = null)
    {
        return new(data, ServiceStatusEnum.BadRequest.Int(),
            message ?? ServiceStatusEnum.BadRequest.ToString());
    }

    public Response Unauthorized(string? message = null)
    {
        return new(ServiceStatusEnum.Unauthorized.Int(),
            message ?? ServiceStatusEnum.Unauthorized.ToString());
    }

    public Response<T> Unauthorized<T>(T data = default!, string? message = null)
    {
        return new(data, ServiceStatusEnum.Unauthorized.Int(),
            message ?? ServiceStatusEnum.Unauthorized.ToString());
    }

    public Response Forbidden(string? message = null)
    {
        return new(ServiceStatusEnum.Forbidden.Int(), message ?? ServiceStatusEnum.Forbidden.ToString());
    }

    public Response<T> Forbidden<T>(T data = default!, string? message = null)
    {
        return new(data, ServiceStatusEnum.Forbidden.Int(),
            message ?? ServiceStatusEnum.Forbidden.ToString());
    }

    public Response InternalServerError(string? message = null)
    {
        return new(ServiceStatusEnum.InternalServerError.Int(),
            message ?? ServiceStatusEnum.InternalServerError.ToString());
    }

    public Response<T> InternalServerError<T>(T data = default!, string? message = null)
    {
        return new(data, ServiceStatusEnum.InternalServerError.Int(),
            message ?? ServiceStatusEnum.InternalServerError.ToString());
    }

    public Response StatusCode(Enum status, string? message = null)
    {
        return new(status.Int(), message ?? status.ToString());
    }

    public Response<T> StatusCode<T>(Enum status, T data = default!, string? message = null)
    {
        return new(data, status.Int(),
            message ?? status.ToString());
    }
}