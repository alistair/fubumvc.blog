using System.Linq;
using Blog.Comments.Domain;
using Blog.Core.Database;
using Blog.Core.Extensions;

namespace Blog.Comments.Manage
{
    public class GetHandler
    {
        private readonly IDocumentDatabase _database;

        public GetHandler(IDocumentDatabase database)
        {
            _database = database;
        }

        public ManageCommentsViewModel Execute(ManageCommentsInputModel inputModel)
        {
            long totalCount;

            var comments = _database
                .WithCount<Comment>(out totalCount)
                .AsQueryable<Comment>()
                .FilteryBySpam(inputModel.ShowSpam)
                .OrderByDescending(x => x.PublishedDate)
                .Page(inputModel)
                .ToList();

            return new ManageCommentsViewModel
            {
                Comments = comments.Select(x => x.DynamicMap<ManageCommentViewModel>()),
                TotalPages = totalCount.TotalPages(inputModel.Count),
                ShowSpam = inputModel.ShowSpam
            };
        }
    }
}