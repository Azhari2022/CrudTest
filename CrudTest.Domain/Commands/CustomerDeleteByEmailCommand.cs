namespace CrudTest.Domain.Commands;

public class CustomerDeleteByEmailCommand : IRequest<Response>
{
    public string? Email { get; set; }
}
