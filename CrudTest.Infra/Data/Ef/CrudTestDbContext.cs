namespace CrudTest.Infra.Data.Ef;

public class CrudTestDbContext : DbContext, IUnitOfWork
{
    public CrudTestDbContext(DbContextOptions<CrudTestDbContext> options)
        : base(options)
    {
    }
    public DbSet<Customer> Customers => Set<Customer>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerEntityTypeConfiguration());
    }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        await base.SaveChangesAsync(cancellationToken);
        return true;
    }
}