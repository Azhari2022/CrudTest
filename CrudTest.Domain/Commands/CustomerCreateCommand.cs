using CrudTest.Domain.Dto;

namespace CrudTest.Domain.Commands;

public class CustomerCreateCommand : CreateCommand<CustomerInputDto>, IRequest<Response<CustomerDto>>
{
}
