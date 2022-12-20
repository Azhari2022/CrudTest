namespace CrudTest.Domain.Share;

public class BaseListInput
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    //public string Sort { get; set; } = null;
    //public string SortDir { get; set; } = null;
}