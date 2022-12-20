namespace CrudTest.Domain.Share;

public static class ResponseExtension
{
    public static Response<T> To<T>(this Response response)
    {
        return new(default!, response);
    }

    public static Response<T> To<T>(this Response response, T data)
    {
        return new(data, response);
    }

    public static bool IsSuccess(this Response response, int statusCode = 200)
    {
        return response.StatusCode == statusCode;
    }
}