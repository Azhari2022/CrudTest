namespace CrudTest.Application.Commands;

public class CustomerDeleteCommandHandler : ServiceBase, IRequestHandler<CustomerDeleteCommand, Response>
{
    readonly ICustomerRepository _customerRepository;

    public CustomerDeleteCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Response> Handle(CustomerDeleteCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.Get(request.Id);

        if (customer != null)
        {
            _customerRepository.Delete(customer);
            await _customerRepository.UnitOfWork.SaveEntitiesAsync();
            return Ok();
        }

        return NotFound();
    }
}

public class CustomerDeleteByEmailCommandHandler : ServiceBase, IRequestHandler<CustomerDeleteByEmailCommand, Response>
{
    readonly ICustomerRepository _customerRepository;

    public CustomerDeleteByEmailCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Response> Handle(CustomerDeleteByEmailCommand request, CancellationToken cancellationToken)
    {
        if (request.Email != null)
        {
            var customer = await _customerRepository.GetByEmail(request.Email);

            if (customer != null)
            {
                _customerRepository.Delete(customer);
                await _customerRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                return Ok();

            }

            return NotFound();
        }

        return BadRequest();
    }
}
