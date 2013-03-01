using MongoAdapt;
using MongoDB.Driver;
using StructureMap.Configuration.DSL;

namespace Blog
{
    public class MongoDbRegistry : Registry
    {
        public MongoDbRegistry()
        {
            var _server = MongoServer.Create("mongodb://localhost:27017/?safe=true");
            var database = _server.GetDatabase("mongo-csharp-adapt-tests");

            For<MongoDatabase>().Singleton().Use(database);
            For<IDocumentDatabase>().Use<MongoDatabaseAdapter>();
            For<IDocumentCollectionNameMap>()
                .Singleton()
                .Use<MongoDocumentCollectionNameMap>();
        }
    }
}