namespace CrudTest.Infra.Data;
public class CustomerRepository : ICustomerRepository, IScopedService
{
    readonly CrudTestDbContext _context;

    public CustomerRepository(CrudTestDbContext dbContext)
    {
        _context = dbContext;
    }

    public IUnitOfWork UnitOfWork => _context;

    public Customer Add(Customer customer)
    {
        return _context.Add(customer).Entity;
    }

    public void Delete(Customer customer)
    {
        _context.Customers.Remove(customer);
    }

    public void Update(Customer customer)
    {
        _context.Entry(customer).State = EntityState.Modified;
    }

    public Task<Customer?> Get(int id)
    {
        return _context.Customers.SingleOrDefaultAsync(c => c.Id == id);
    }

    public Task<Customer?> GetByEmail(string email)
    {
        return _context.Customers.SingleOrDefaultAsync(c => c.Email.Value == email);
    }

    public Task<bool> CheckExistsEmail(EmailValueObject email, int? exceptId = null)
    {
        return _context.Customers.AnyAsync(c => c.Email == email && (exceptId == null || c.Id != exceptId.Value));
    }

    public Task<bool> CheckExistsProfile(NameValueObject firstName, NameValueObject lastName, DateOfBirthValueObject dateOfBirth, int? exceptId = null)
    {
        return _context.Customers.AnyAsync(c => c.Firstname == firstName
            && c.Lastname == lastName
            && c.DateOfBirth == dateOfBirth
            && (exceptId == null || c.Id != exceptId.Value));
    }
    public async Task<List<Customer>> GetBySpecAsync(ISpecification<Customer> specification, CancellationToken cancellationToken = default)
    {
        return await ApplySpecification(specification).ToListAsync(cancellationToken);
    }

    private IQueryable<Customer> ApplySpecification(ISpecification<Customer> specification)
    {
        return SpecificationEvaluator.Default.GetQuery(_context.Set<Customer>().AsQueryable(), specification);
    }
}
