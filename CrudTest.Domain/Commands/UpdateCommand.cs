namespace CrudTest.Domain.Commands;

public class UpdateCommand<T>
{
    public T Data { get; set; }
}
