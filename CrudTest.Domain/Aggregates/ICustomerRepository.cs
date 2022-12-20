using Ardalis.Specification;
using CrudTest.Domain.Common;
using CrudTest.Domain.ValuesObjects;

namespace CrudTest.Domain.Aggregates;

public interface ICustomerRepository : IRepository
{
    Customer Add(Customer customer);

    void Update(Customer customer);

    void Delete(Customer customer);

    Task<Customer?> Get(int id);

    Task<Customer?> GetByEmail(string email);

    Task<bool> CheckExistsEmail(EmailValueObject email, int? exceptId = null);

    Task<bool> CheckExistsProfile(NameValueObject firstName, NameValueObject lastName, DateOfBirthValueObject dateOfBirth, int? exceptId = null);

    Task<List<Customer>> GetBySpecAsync(ISpecification<Customer> specification,
        CancellationToken cancellationToken = default);

}

