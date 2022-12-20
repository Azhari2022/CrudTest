namespace CrudTest.Application.Validations;
public class CustomerUpdateCommandValidator : AbstractValidator<CustomerUpdateCommand>
{
    public CustomerUpdateCommandValidator(ICustomerRepository customerRepository)
    {
        ClassLevelCascadeMode = CascadeMode.Stop;
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.Data).SetValidator(new CustomerInputDtoValidator());
        RuleFor(x => new { x.Id, x.Data.Email })
            .MustAsync(async (v, _) => !await customerRepository.CheckExistsEmail(
                EmailValueObject.From(v.Email),
                v.Id
            )).WithErrorCode("202")
            .WithMessage("Duplicate customer by Email address");
        RuleFor(x => new { x.Id, x.Data.Firstname, x.Data.Lastname, x.Data.DateOfBirth })
            .MustAsync(async (v, _) => !await customerRepository.CheckExistsProfile(
                NameValueObject.From(v.Firstname),
                NameValueObject.From(v.Lastname),
                DateOfBirthValueObject.From(v.DateOfBirth),
                v.Id
            )).WithErrorCode(("201"))
            .WithMessage("Duplicate customer by First-name, Last-name, Date-of-Birth");
    }
}
