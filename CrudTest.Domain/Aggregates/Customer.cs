using CrudTest.Domain.Common;
using CrudTest.Domain.Dto;
using CrudTest.Domain.ValuesObjects;

namespace CrudTest.Domain.Aggregates;

public class Customer : Entity, IAggregateRoot
{
    public NameValueObject? Firstname { get; set; }
    public NameValueObject? Lastname { get; set; }
    public DateOfBirthValueObject? DateOfBirth { get; set; }
    public EmailValueObject? Email { get; set; }
    public MobileValueObject? PhoneNumber { get; set; }

    public void Update(CustomerInputDto customer)
    {
        if (customer.DateOfBirth != null) this.DateOfBirth = DateOfBirthValueObject.From(customer.DateOfBirth);
        if (customer.Firstname != null) this.Firstname = NameValueObject.From(customer.Firstname);
        if (customer.Lastname != null) this.Lastname = NameValueObject.From(customer.Lastname);
        if (customer.PhoneNumber != null) this.PhoneNumber = MobileValueObject.From(customer.PhoneNumber);
        if (customer.Email != null) this.Email = EmailValueObject.From(customer.Email);
    }
    
}



