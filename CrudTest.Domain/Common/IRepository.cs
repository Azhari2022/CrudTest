namespace CrudTest.Domain.Common;

public interface IRepository
{
    IUnitOfWork UnitOfWork { get; }
}
