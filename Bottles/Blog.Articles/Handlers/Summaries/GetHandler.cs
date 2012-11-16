using System.Linq;
using Blog.Articles.Domain;
using Blog.Core.Extensions;
using MongoDB.Driver;

namespace Blog.Articles.Summaries
{
    public class GetHandler
    {
        private readonly MongoDatabase _database;

        public GetHandler(MongoDatabase database)
        {
            _database = database;
        }

        public ArticleSummariesViewModel Execute()
        {
            var articles = _database.Query<Article>()
                .Where(x => x.IsPublished)
                .OrderByDescending(x => x.PublishedDate)
                .Take(10).ToList();

            return new ArticleSummariesViewModel
            {
                Summaries = articles.Select(x => x.DynamicMap<ArticleSummaryViewModel>())
            };
        }
    }
}