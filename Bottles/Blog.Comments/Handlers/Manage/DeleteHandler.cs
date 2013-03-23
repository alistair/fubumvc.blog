using System.Linq;
using Blog.Core.Domain;
using MongoAdapt;

namespace Blog.Comments.Manage
{
    public class DeleteHandler
    {
        private readonly IDocumentDatabase _database;

        public DeleteHandler(IDocumentDatabase database)
        {
            _database = database;
        }

        public DeleteCommentViewModel Execute(DeleteCommentInputModel inputModel)
        {
            var comment = _database.Query<Comment>()
                .FirstOrDefault(x => x.Id == inputModel.Id);

            if (comment != null)
            {
                _database.Decrement<Article>(comment.ArticleUri, x => x.CommentsCount);
                _database.Delete(comment);
            }

            return new DeleteCommentViewModel();
        }
    }
}