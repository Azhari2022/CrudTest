using System.Linq.Expressions;

namespace CrudTest.Domain.Share;

public static class QueryableExtension
{
    public static IQueryable<T> Paging<T>(this IQueryable<T> q, int? pageNumber, int? pageSize)
    {
        return q.Skip(((pageNumber ?? 1) - 1) * (pageSize ?? 1)).Take(pageSize ?? 1);
    }

    public static IOrderedQueryable<TSource> Sort<TSource, TKey>(this IQueryable<TSource> q,
        Expression<Func<TSource, TKey>> keySelector, string dir = "asc")
    {
        return dir == "desc" ? q.OrderBy(keySelector) : q.OrderByDescending(keySelector);
    }

    public static IOrderedQueryable<TSource> ThenSort<TSource, TKey>(this IOrderedQueryable<TSource> q,
        Expression<Func<TSource, TKey>> keySelector, string dir = "asc")
    {
        return dir == "desc" ? q.ThenBy(keySelector) : q.ThenByDescending(keySelector);
    }
}