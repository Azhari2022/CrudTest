namespace CrudTest.Domain.Commands;

public record DataList<T>(List<T> Items, int? TotalCount, int? PageCount, bool HasNext)
{
    public DataList() : this(default, 0, 0, false)
    {
    }

    public DataList(List<T> items) : this(items, items.Count, 1, false)
    {
    }
}
