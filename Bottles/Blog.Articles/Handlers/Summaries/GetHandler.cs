using System.Linq;
using Blog.Articles.Domain;
using Blog.Core.Domain;
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

            var summaries = articles.Select(a =>
            {
                //TODO: improve
                var user = _database.Query<User>().SingleOrDefault(u => u.Id == a.AuthorId);

                var article = a.DynamicMap<ArticleSummaryViewModel>();

                article.Author = user.FullName();
                return article;
            });

            return new ArticleSummariesViewModel
            {
                Summaries = summaries
            };
        }
    }
}