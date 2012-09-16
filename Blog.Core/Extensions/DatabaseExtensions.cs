using Raven.Abstractions.Commands;
using Raven.Client;

namespace Blog.Core.Extensions
{
    public static class DatabaseExtensions
    {
         public static void Delete<T>(this IDocumentSession session, string id)
         {
             session.Advanced.Defer(new DeleteCommandData { Key = id });
         }
    }
}