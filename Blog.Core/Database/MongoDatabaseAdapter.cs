using System.Collections.Generic;
using System.Linq;
using Blog.Core.Extensions;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

namespace Blog.Core.Database
{
    public class MongoDatabaseAdapter : IDocumentDatabase
    {
        private readonly MongoDatabase _database;

        public MongoDatabaseAdapter(MongoDatabase database)
        {
            _database = database;
        }

        public void Delete(string collection, string column, object value)
        {
            _database.GetCollection(collection)
                     .Remove(MongoDB.Driver.Builders.Query.EQ(column, BsonValue.Create(value)));
        }

        public void Delete(string collection, object value)
        {
            _database.GetCollection(collection)
                     .Remove(MongoDB.Driver.Builders.Query.EQ("_id", BsonValue.Create(value)));
        }

        public void Delete<T>(object value) where T : class
        {
            
            _database.CollectionForType<T>()
                     .Remove(MongoDB.Driver.Builders.Query.EQ("_id", BsonValue.Create(value)));
        }

        public void Delete<T>(string column, object value) where T : class
        {
            _database.CollectionForType<T>()
                     .Remove(MongoDB.Driver.Builders.Query.EQ(column, BsonValue.Create(value)));
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return _database.Query<T>();
        }

        public IQueryable<T> WithCount<T>(out long count) where T : class
        {
            var collection = _database.CollectionForType<T>();
            count = collection.Count();

            return collection.AsQueryable<T>();
        }

        public long Count<T>() where T : class
        {
            return _database.CollectionForType<T>().Count();
        }

        public IEnumerable<T> All<T>() where T : class
        {
            return _database.CollectionForType<T>()
                .FindAllAs<T>();
        }

        public void Insert<T>(T data) where T : class
        {
            _database.CollectionForType<T>()
                     .Insert(data);
        }

        public void Save<T>(T data) where T : class
        {
            _database.CollectionForType<T>()
                     .Save(data);
        }

        public void Increment<T>(string value, string incrementColumn, int incrementer)
        {
            var update = Update.Inc(incrementColumn, incrementer);

            _database.CollectionForType<T>()
                .FindAndModify(MongoDB.Driver.Builders.Query.EQ("_id", value), SortBy.Null, update, false);
        }

        public void Increment(string collection, string value, string incrementColumn, int incrementer)
        {
            var update = Update.Inc(incrementColumn, incrementer);

            _database.GetCollection(collection)
                .FindAndModify(MongoDB.Driver.Builders.Query.EQ("_id", value), SortBy.Null, update, false);
        }
    }
}