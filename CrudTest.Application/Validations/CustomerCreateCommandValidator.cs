
namespace CrudTest.Application.Validations;

public class CustomerCreateCommandValidator : AbstractValidator<CustomerCreateCommand>
{
    public CustomerCreateCommandValidator(ICustomerRepository customerRepository)
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Data)
            .SetValidator(new CustomerInputDtoValidator());

        RuleFor(x => x.Data.Email)
            .MustAsync(async (v, _) =>
                v != null && !await customerRepository.CheckExistsEmail(
                    EmailValueObject.From(v)
                )).WithErrorCode("202")
            .WithMessage("Duplicate customer by Email address");
        RuleFor(x => new { x.Data.Firstname, x.Data.Lastname, x.Data.DateOfBirth })
            .MustAsync(async (v, _) =>
                !await customerRepository.CheckExistsProfile(
                    NameValueObject.From(v.Firstname),
                    NameValueObject.From(v.Lastname),
                    DateOfBirthValueObject.From(v.DateOfBirth)
            )).WithErrorCode("201")
            .WithMessage("Duplicate customer by First-name, Last-name, Date-of-Birth");
    }
}
