using MongoDB.Driver;
using StructureMap.Configuration.DSL;

namespace Blog
{
    public class MongoRegistry : Registry
    {
        public class ArticleTototototo
        {
            public int Id { get; set; }
            public string Text { get; set; }
        }

        public MongoRegistry()
        {
            var server = MongoServer.Create("mongodb://localhost:27017/?safe=true");
            var database = server.GetDatabase("default");

            For<MongoDatabase>().Singleton().Use(database);
        }
    }
}