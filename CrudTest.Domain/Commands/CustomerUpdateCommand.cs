using CrudTest.Domain.Dto;

namespace CrudTest.Domain.Commands;

public class CustomerUpdateCommand : UpdateCommand<CustomerInputDto>, IRequest<Response>
{
    public int Id { get; set; }
}
