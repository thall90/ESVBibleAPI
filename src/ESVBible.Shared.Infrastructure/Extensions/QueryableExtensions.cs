using System;
using System.Linq;
using System.Linq.Expressions;
using ESVBible.Shared.Enum;

namespace ThriveNextGen.Shared.Infrastructure.Extensions
{
    public static class QueryableExtensions
    {
        public static IOrderedQueryable<TSource> SortBy<TSource, TKey>(this IQueryable<TSource> queryable,
            Expression<Func<TSource, TKey>> keySelector,
            SortDirection querySortDirection,
            SortDirection sortDirection = SortDirection.ASC)
        {
            switch (sortDirection)
            {
                case SortDirection.DESC:
                    return queryable.OrderByDescending(keySelector);

                case SortDirection.ASC:
                default:
                    return queryable.OrderBy(keySelector);
            }
        }
        
        public static IOrderedQueryable<TSource> ThenSortBy<TSource, TKey>(
            this IOrderedQueryable<TSource> queryable,
            Expression<Func<TSource, TKey>> keySelector,
            SortDirection sortDirection = SortDirection.ASC)
        {
            switch (sortDirection)
            {
                case SortDirection.DESC:
                    return queryable.ThenByDescending(keySelector);

                case SortDirection.ASC:
                default:
                    return queryable.ThenBy(keySelector);
            }
        }
    }
}