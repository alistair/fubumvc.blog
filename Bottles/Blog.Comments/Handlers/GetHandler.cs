using System.Linq;
using Blog.Comments.Domain;
using Blog.Core.Extensions;
using FubuMVC.Core;
using MongoDB.Driver;

namespace Blog.Comments
{
    public class GetHandler
    {
        private readonly MongoDatabase _database;

        public GetHandler(MongoDatabase database)
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