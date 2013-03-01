using System.Linq;
using Blog.Comments.Domain;
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
                .First(x => x.Id == inputModel.Id);

            //_database.Increment("Articles", comment.ArticleUri, "CommentsCount", -1);

            _database.Delete(new Comment(inputModel.Id));
            return new DeleteCommentViewModel();
        }
    }
}