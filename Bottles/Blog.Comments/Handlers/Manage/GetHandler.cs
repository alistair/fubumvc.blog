using System.Linq;
using Blog.Comments.Domain;
using Blog.Core.Extensions;
using Raven.Client;

namespace Blog.Comments.Manage
{
    public class GetHandler
    {
        private readonly IDocumentSession _session;

        public GetHandler(IDocumentSession session)
        {
            _session = session;
        }

        public ManageCommentsViewModel Execute(ManageCommentsInputModel inputModel)
        {
            var comments = _session.Query<Comment>().ToList();

            return new ManageCommentsViewModel
            {
                Comments = comments.Select(x => x.DynamicMap<ManageCommentViewModel>())
            };
        }
    }
}