using Blog.Comments.Domain;
using Raven.Client;
using Blog.Core.Extensions;

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
            _session.Delete<Comment>(inputModel.Id);

            return new DeleteCommentViewModel();
        }
    }
}