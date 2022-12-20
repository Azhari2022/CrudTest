using CrudTest.Application.Validations;
using CrudTest.Domain.Dto;

namespace CrudTest.UnitTest;

public class CustomerTest
{

    CustomerInputDto Customer() => new CustomerInputDto
    {
        Firstname = "Faeze",
        Lastname = "Azhari",
        DateOfBirth = "2000-02-06",
        Email = "f.azhari2019@gmail.com",
        PhoneNumber = "+989126548899",
    };

    private CustomerInputDtoValidator _validator = new CustomerInputDtoValidator();


    [Fact]
    public void IsValidTest()
    {
        var customer = Customer();
        var result = _validator.Validate(customer);
        Assert.True(result.IsValid);
    }

    [Fact]
    public void ProfileTest()
    {
        var customer = Customer();
        customer.Firstname = "";
        customer.Lastname = "";
        var result = _validator.Validate(customer);
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(customer.Firstname));
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(customer.Lastname));
    }


    [Fact]
    public void EmailTest()
    {
        var customer = Customer();
        customer.Email = "";
        var result = _validator.Validate(customer);
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(customer.Email));


        customer.Email = "qweqweqwe6q5w";
        result = _validator.Validate(customer);
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(customer.Email));


        customer.Email = "asdasdasdaseqweqweq.ir";
        result = _validator.Validate(customer);
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(customer.Email));
    }

    
}
