using Ardalis.Specification;
using CrudTest.Domain.Aggregates;

namespace CrudTest.Domain.Specifications;

public sealed class CustomerByProfileSpec : Specification<Customer>
{
    public CustomerByProfileSpec(Customer customer, int? expectedId = null)
    {
        Query.Where(c =>  customer.DateOfBirth != null
                          && c.DateOfBirth != null 
                          && c.Firstname == customer.Firstname 
                          && c.Lastname == customer.Lastname 
                          && c.DateOfBirth.Equals(customer.DateOfBirth) 
                          && (expectedId == null || c.Id != expectedId));

    }
}