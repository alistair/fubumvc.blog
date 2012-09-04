using System.Linq;
using Blog.Comments.Domain;
using Blog.Core.Extensions;
using FubuMVC.Core;
using Raven.Client;
using Raven.Client.Linq;

namespace Blog.Comments
{
    public class GetHandler
    {
        private readonly IDocumentSession _session;

        public GetHandler(IDocumentSession session)
        {
            _session = session;
        }

        [UrlPattern("comments/{Uri}")]
        public CommentsViewModel Execute(CommentsInputModel inputModel)
        {
            var comments = _session.Query<Comment>()
                .Where(x => x.ArticleUri.Equals(inputModel.Uri))
                .OrderByDescending(x => x.PublishedDate)
                .ToList();

            return new CommentsViewModel
            {
                Uri = inputModel.Uri,
                Comments = comments.Select(x => x.DynamicMap<CommentViewModel>())
            };
        }
    }
}