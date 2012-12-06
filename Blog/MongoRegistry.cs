using Blog.Core.Database;
using MongoDB.Driver;
using StructureMap.Configuration.DSL;

namespace Blog
{
    public class MongoRegistry : Registry
    {
        public MongoRegistry()
        {
            //TODO: Clean all of this up:
            var server = MongoServer.Create("mongodb://localhost:27017/?safe=true");
            var database = server.GetDatabase("default");

            For<MongoDatabase>()
                .Singleton().Use(database);
            For<IDocumentDatabase>().Use<MongoDatabaseAdapter>();
        }
    }
}