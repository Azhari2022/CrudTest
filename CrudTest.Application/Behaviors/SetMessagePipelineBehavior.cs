


namespace CrudTest.Application.Behaviors;

public class SetMessagePipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse> where TResponse : class ,new()
{
    private readonly IStatusCodeMessage _translator;

    public SetMessagePipelineBehavior(IStatusCodeMessage translator)
    {
        _translator = translator;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var tresponse = await next();
        if (tresponse is Response response)
        {
            response.Message = _translator.Get(response.StatusCode);
            return (response as TResponse)!;
        }

        return tresponse;
    }
}