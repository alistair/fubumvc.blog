using System.Linq;
using Blog.Articles.Domain;
using Blog.Core.Domain;
using Blog.Core.Extensions;
using FubuMVC.Core;
using MongoAdapt;

namespace Blog.Articles
{
    public class GetHandler
    {
        private readonly IDocumentDatabase _database;

        public GetHandler(IDocumentDatabase database)
        {
            _database = database;
        }

        [UrlPattern("{Uri}")]
        public ArticleViewModel Execute(ArticleInputModel inputModel)
        {
            var article = _database.Query<Article>().FirstOrDefault(x => x.Id == inputModel.Uri);

            if (article == null)
                return new ArticleViewModel();

            var user = _database.Query<User>().SingleOrDefault(u => u.Id == article.AuthorId);

            var model = article.DynamicMap<ArticleViewModel>();
            model.Author = user.FullName();

            return model;

        }
    }
}