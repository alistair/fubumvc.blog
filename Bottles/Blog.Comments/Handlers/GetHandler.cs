using System.Linq;
using Blog.Comments.Domain;
using Blog.Core.Database;
using Blog.Core.Extensions;
using FubuMVC.Core;

namespace Blog.Comments
{
    public class GetHandler
    {
        private readonly IDocumentDatabase _database;

        public GetHandler(IDocumentDatabase database)
        {
            _database = database;
        }

        [UrlPattern("comments/{Uri}")]
        public CommentsViewModel Execute(CommentsInputModel inputModel)
        {
            var comments = _database
                .Query<Comment>()
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