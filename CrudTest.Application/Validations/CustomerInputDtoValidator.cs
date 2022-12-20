namespace CrudTest.Application.Validations;

public class CustomerInputDtoValidator : AbstractValidator<CustomerInputDto>
{
    public CustomerInputDtoValidator()
    {
        RuleFor(a => a.Firstname).Must(NameValidator.IsValid);
        RuleFor(a => a.Lastname).Must(NameValidator.IsValid);
        RuleFor(a => a.DateOfBirth).Must(v => DateOfBirthValidator.IsValid(v));
        RuleFor(a => a.Email).Must(EmailValidator.IsValid).WithErrorCode("102")
            .WithMessage("Invalid Email address");
        RuleFor(a => a.PhoneNumber).Must(v => MobileValidator.IsValid(v)).WithErrorCode("101")
            .WithMessage("Invalid Mobile Number");
    }
}