using Blog.Articles.Domain;
using Blog.Core.Database;

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

            _database.Delete("Comments", "ArticleUri", inputModel.Id);

            return new DeleteArticleViewModel();
        }
    }
}