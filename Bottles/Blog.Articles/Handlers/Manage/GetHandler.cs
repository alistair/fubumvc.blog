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
            var articles = _database
                .GetCollection("Articles")
                .AsQueryable<Article>()
                .OrderByDescending(x => x.PublishedDate)
                //.Statistics(out stats)
                //.Page(inputModel)
                .ToList();

            return new ManageArticlesViewModel
            {
                Articles = articles.Select(x => x.DynamicMap<ManageArticleViewModel>()),
                TotalPages = 1// stats.TotalPages(inputModel.Count ?? 0)
            };
        }

    }
}