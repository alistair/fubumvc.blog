using System.Collections.Generic;
using System.Linq;
using Blog.Comments.Domain;
using Blog.Core.Database;
using Blog.Core.Extensions;

namespace Blog.Comments.Recent
{
    public class GetHandler
    {
        private readonly IDocumentDatabase _database;

        public GetHandler(IDocumentDatabase database)
        {
            _database = database;
        }

        public IEnumerable<RecentCommentViewModel> Execute(RecentCommentInputModel inputModel)
        {
            var recentComments = _database
                .Query<Comment>()
                .OrderByDescending(x => x.PublishedDate)
                .Take(5);

            return recentComments.Select(x => x.DynamicMap<RecentCommentViewModel>());
        }
    }
}