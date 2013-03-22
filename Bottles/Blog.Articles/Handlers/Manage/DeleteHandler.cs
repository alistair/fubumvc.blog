using System.Collections.Generic;
using System.Linq;
using Blog.Articles.Domain;
using Blog.Core.Domain;
using MongoAdapt;

namespace Blog.Articles.Manage
{
    public class DeleteHandler
    {
        private readonly IDocumentDatabase _database;

        public DeleteHandler(IDocumentDatabase database)
        {
            _database = database;
        }

        public DeleteArticleViewModel Execute(DeleteArticleInputModel inputModel)
        {
            _database.Delete<Article>(inputModel.Id);

            _database.Query<Comment>()
                     .Where(x => x.ArticleUri == inputModel.Id)
                     .Each(x => _database.Delete(x));

            return new DeleteArticleViewModel();
        }
    }
}