using CrudTest.Domain.Commands;
using CrudTest.Domain.Dto;

namespace CrudTest.Domain.Queries;

public interface ICustomerQueries
{
    Task<Response<CustomerDto>> Get(CustomerGetQuery query);
    Task<Response<DataList<CustomerDto>>> GetList(CustomerGetListQuery query);
}
