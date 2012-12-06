using System.Linq;
using Blog.Core.Domain;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Blog.Core.Extensions
{
    public static class MongoDatabaseExtensions
    {
        public static IQueryable<T> Query<T>(this MongoDatabase db)
        {
            return db.CollectionForType<T>().AsQueryable<T>();
        }

        public static MongoCollection CollectionForType<T>(this MongoDatabase db)
        {
            var type = typeof (T);
            var typeName = type.Name;
            var collectionName = typeName.EndsWith("s") ? typeName : typeName + "s";

            return db.GetCollection(collectionName);
        }

        public static IQueryable<T> Page<T>(this IQueryable<T> query, IPageable paging)
        {
            return query
                .Skip(paging.Page.Value - 1)
                .Take(paging.Count.Value);
        }

    }
}