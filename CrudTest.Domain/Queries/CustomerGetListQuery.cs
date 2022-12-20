using CrudTest.Domain.Share;

namespace CrudTest.Domain.Queries;

public class CustomerGetListQuery : BaseListInput
{
    public string? Email { get; set; }
}