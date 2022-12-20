namespace CrudTest.Application.Validations;

public class CustomerDeleteByEmailCommandValidator : AbstractValidator<CustomerDeleteByEmailCommand>
{
    public CustomerDeleteByEmailCommandValidator()
    {
        RuleFor(x => x.Email).Must(Domain.Validators.EmailValidator.IsValid);
    }
}
