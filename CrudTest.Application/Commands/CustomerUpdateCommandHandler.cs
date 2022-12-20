namespace CrudTest.Application.Commands;

public class CustomerUpdateCommandHandler : ServiceBase, IRequestHandler<CustomerUpdateCommand, Response>
{
    readonly ICustomerRepository _customerRepository;

    public CustomerUpdateCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Response> Handle(CustomerUpdateCommand request, CancellationToken cancellationToken)
    {
        var dbCustomer = await _customerRepository.Get(request.Id);
        if (dbCustomer != null)
        {
            dbCustomer.Update(request.Data);
            _customerRepository.Update(dbCustomer);
            await _customerRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return Ok();
        }

        return NotFound();
    }
}