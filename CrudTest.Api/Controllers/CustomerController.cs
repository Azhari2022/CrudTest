using CrudTest.Domain.Commands;
using CrudTest.Domain.Dto;
using CrudTest.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CrudTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        readonly IMediator _mediator;
        readonly ICustomerQueries _customerQueries;

        public CustomerController(IMediator mediator, ICustomerQueries customerQueries)
        {
            _mediator = mediator;
            _customerQueries = customerQueries;
        }

        [HttpGet]
        public Task<Response<DataList<CustomerDto>>> Get([FromQuery] CustomerGetListQuery query)
        {
            return _customerQueries.GetList(query);
        }

        [HttpGet("{id}")]
        public Task<Response<CustomerDto>> Get(int id)
        {
            return _customerQueries.Get(new CustomerGetQuery(id));
        }
        
        [HttpPost]
        public Task<Response<CustomerDto>> Create([FromBody] CustomerCreateCommand command)
        {
            return _mediator.Send(command);
        }

        [HttpPut]
        public Task<Response> Update([FromBody] CustomerUpdateCommand command)
        {
            return _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public Task<Response> Delete(int id)
        {
            return _mediator.Send(new CustomerDeleteCommand { Id = id });
        }

        [HttpDelete("delete_by_email/{email}")]
        public Task<Response> Delete(string email)
        {
            return _mediator.Send(new CustomerDeleteByEmailCommand { Email = email });
        }
    }
}
