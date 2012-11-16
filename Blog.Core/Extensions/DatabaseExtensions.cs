using System.Linq;
using Blog.Core.Domain;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Blog.Core.Extensions
{
    public static class DatabaseExtensions
    {
        public static IQueryable<T> Query<T>(this MongoDatabase db)
        {
            var type = typeof (T);
            var typeName = type.Name;
            var collectionName = typeName.EndsWith("s") ? typeName : typeName + "s";

            return db.GetCollection(collectionName).AsQueryable<T>();
        }

        public static IQueryable<T>  Page<T>(this IQueryable<T> query, IPageable paging)
        {
            return query
                .Skip(paging.Page.Value - 1)
                .Take(paging.Count.Value);
        }

        public static MongoCollection WithCount(this MongoCollection collection, out long count)
        {
            count = collection.Count();
            return collection;
        }
    }
}