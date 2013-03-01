using System.Linq;
using Blog.Core.Domain;

namespace Blog.Core.Extensions
{
    public static class MongoDatabaseExtensions
    {
        public static IQueryable<T> Page<T>(this IQueryable<T> query, IPageable paging)
        {
            return query
                .Skip(paging.Page.Value - 1)
                .Take(paging.Count.Value);
        }

    }
}