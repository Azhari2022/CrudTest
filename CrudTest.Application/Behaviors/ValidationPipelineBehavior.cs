
namespace CrudTest.Application.Behaviors;
public class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    where TResponse : class, new()
{
    private readonly IEnumerable<IValidator> _validators;

    public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);
            var validationResults = new List<ValidationResult>();
            foreach (var validator in _validators)
            {
                validationResults.Add(await validator.ValidateAsync(context));
            }
            var failures = validationResults
                .Where(r => !r.IsValid)
                .SelectMany(r => r.Errors)
                .Where(f => f is { Severity: Severity.Error })
                .ToList();
            if (failures.Any())
            {
                if (new TResponse() is Response r)
                {

                    r.StatusCode = 400;
                    r.Message = "Bad request";
                    r.SubStatuses = failures.GroupBy(f => $"{f.PropertyName} : {f.AttemptedValue}")
                        .Select(f => new ServiceSubStatus
                        {
                            StatusCode = f.Select(g=>int.TryParse(g.ErrorCode,out var code)?code:400).FirstOrDefault(),
                            Message = f.Select(g => g.ErrorMessage).Aggregate((res, item) => res + item + ", "),
                            Subject = f.Key
                        }).ToList();
                    return (r as TResponse)!;
                }
            }
        }

        return await next();
    }
}