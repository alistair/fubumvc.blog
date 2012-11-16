using System.Linq;
using Blog.Articles.Domain;
using Blog.Core.Extensions;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Blog.Articles.Manage
{
    public class GetHandler
    {
        private readonly MongoDatabase _database;

        public GetHandler(MongoDatabase database)
        {
            _database = database;
        }

        public ManageArticlesViewModel Execute(ManageArticlesInputModel inputModel)
        {
            long totalCount;

            var articles = _database.GetCollection("Articles")
                .WithCount(out totalCount)
                .AsQueryable<Article>()
                .OrderByDescending(x => x.PublishedDate)
                .Page(inputModel)
                .ToList();

            return new ManageArticlesViewModel
            {
                Articles = articles.Select(x => x.DynamicMap<ManageArticleViewModel>()),
                TotalPages = totalCount.TotalPages(inputModel.Count)
            };
        }

    }
}