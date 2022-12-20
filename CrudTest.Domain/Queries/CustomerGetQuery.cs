namespace CrudTest.Domain.Queries;

public class CustomerGetQuery
{
    public CustomerGetQuery(int id)
    {
        Id = id;
    }
    public int Id { get; set; }
}
