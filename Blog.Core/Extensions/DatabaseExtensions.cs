using System.Linq;
using Blog.Core.Domain;
using Raven.Abstractions.Commands;
using Raven.Client;
using Raven.Client.Linq;

namespace Blog.Core.Extensions
{
    public static class DatabaseExtensions
    {
         public static void Delete<T>(this IDocumentSession session, string id)
         {
             session.Advanced.Defer(new DeleteCommandData { Key = id });
         }

        public static IQueryable<T> Page<T>(this IRavenQueryable<T> query, IPageable pager)
        {
            return query
                .Skip((pager.Page.Value - 1) * pager.Count.Value)
                .Take(pager.Count.Value);
        }
    }
}