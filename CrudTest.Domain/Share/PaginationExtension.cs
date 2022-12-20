namespace CrudTest.Domain.Share;

public static class PaginationExtension
{
    public static int ToOffset(this int page, int pageSize)
    {
        return (page - 1) * pageSize;
    }

    public static int Offset(this BaseListInput query)
    {
        return (query.Page - 1) * query.PageSize;
    }

    public static bool HasNext(this BaseListInput query, int totalCount)
    {
        return query.Page * query.PageSize < totalCount;
    }

    public static int PageCount(this BaseListInput query, int totalCount)
    {
        return totalCount / query.PageSize + (totalCount % query.PageSize != 0 ? 1 : 0);
    }

    public static DataList<T> ToDataList<T>(this List<T> items, int totalCount, BaseListInput input)
    {
        totalCount = totalCount != -1 ? totalCount : items.Count;
        return new DataList<T>(items, totalCount, input.PageCount(totalCount), input.HasNext(totalCount));
    }
}