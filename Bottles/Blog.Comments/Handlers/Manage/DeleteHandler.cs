using Blog.Comments.Domain;
using Raven.Client;

namespace Blog.Comments.Manage
{
    public class DeleteHandler
    {
        private readonly IDocumentSession _session;

        public DeleteHandler(IDocumentSession session)
        {
            _session = session;
        }

        public DeleteCommentViewModel Execute(DeleteCommentInputModel inputModel)
        {
            var comment = _session.Load<Comment>(inputModel.Id);

            var article = _session.Load<dynamic>(comment.ArticleUri);
            article.CommentsCount--;

            _session.Delete(comment);

            return new DeleteCommentViewModel();
        }
    }
}