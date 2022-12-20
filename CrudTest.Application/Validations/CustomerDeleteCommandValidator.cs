namespace CrudTest.Application.Validations;

public class CustomerDeleteCommandValidator : AbstractValidator<CustomerDeleteCommand>
{
    public CustomerDeleteCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}
