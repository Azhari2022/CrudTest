namespace CrudTest.Domain.Commands;

public class CreateCommand<T>
{
    public T Data { get; set; }
}
