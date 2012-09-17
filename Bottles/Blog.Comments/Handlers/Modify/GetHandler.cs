using Blog.Comments.Domain;
using Blog.Core.Extensions;
using Raven.Client;

namespace Blog.Comments.Modify
{
    public class GetHandler
    {
        private readonly IDocumentSession _session;

        public GetHandler(IDocumentSession session)
        {
            _session = session;
        }

        public ModifyCommentViewModel Execute(ModifyCommentInputModel inputModel)
        {
            var comment = _session.Load<Comment>(inputModel.Id);

            return comment.DynamicMap<ModifyCommentViewModel>();
        }
    }
}