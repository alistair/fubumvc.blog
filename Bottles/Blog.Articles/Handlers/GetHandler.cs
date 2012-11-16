using System.Linq;
using Blog.Articles.Domain;
using Blog.Core.Extensions;
using FubuMVC.Core;
using MongoDB.Driver;

namespace Blog.Articles
{
    public class GetHandler
    {
        private readonly MongoDatabase _database;

        public GetHandler(MongoDatabase database)
        {
            _database = database;
        }

        [UrlPattern("{Uri}")]
        public ArticleViewModel Execute(ArticleInputModel inputModel)
        {
            var article = _database.Query<Article>().FirstOrDefault(x => x.Id == inputModel.Uri);

            return article.DynamicMap<ArticleViewModel>();
        }
    }
}