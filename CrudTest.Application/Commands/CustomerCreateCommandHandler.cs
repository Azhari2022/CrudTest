namespace CrudTest.Application.Commands
{
    public class CustomerCreateCommandHandler : ServiceBase, IRequestHandler<CustomerCreateCommand, Response<CustomerDto>>
    {
        readonly ICustomerRepository _customerRepository;
        readonly IMapper _mapper;

        public CustomerCreateCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<Response<CustomerDto>> Handle(CustomerCreateCommand request, CancellationToken cancellationToken)
        {

            var customer = _mapper.Map<Customer>(request.Data);
       
            _customerRepository.Add(customer);
            await _customerRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return Ok(_mapper.Map<CustomerDto>(customer));
        }
    }
}
