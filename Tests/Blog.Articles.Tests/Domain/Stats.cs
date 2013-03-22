using MongoAdapt;

namespace Blog.Articles.Tests.Domain
{
    public class Stats : IDocumentCollection
    {
        public Stats(long count)
        {
            Count = count;
        }
        public string Name { get; private set; }
        public long Count { get; private set; }
    }
}