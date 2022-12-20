using Ardalis.Specification;
using CrudTest.Domain.Aggregates;

namespace CrudTest.Domain.Specifications;

public sealed class CustomerByEmailSpec : Specification<Customer>
{
    public CustomerByEmailSpec(Customer customer)
    {
        Query.Where(c => c.Email == customer.Email && (c.Id != customer.Id));

    }
}