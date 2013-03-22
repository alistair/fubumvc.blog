using System.Linq;
using Blog.Comments.Domain;
using Blog.Core.Domain;
using Blog.Core.Extensions;
using MongoAdapt;

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
                .Query<Comment>()
               // .WithCount<Comment>(out totalCount)
                //.AsQueryable<Comment>()
                .FilteryBySpam(inputModel.ShowSpam)
                .OrderByDescending(x => x.PublishedDate)
                .Page(inputModel)
                .ToList();

            return new ManageCommentsViewModel
            {
                Comments = comments.Select(x => x.DynamicMap<ManageCommentViewModel>()),
                //TotalPages = totalCount.TotalPages(inputModel.Count),
                ShowSpam = inputModel.ShowSpam
            };
        }
    }
}