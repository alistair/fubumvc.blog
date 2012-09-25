using System;
using System.Linq;
using Blog.Comments.Domain;
using Blog.Core.Extensions;
using Raven.Client;
using Raven.Client.Linq;

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
            RavenQueryStatistics stats;
            var comments = _session.Query<Comment>()
                .Statistics(out stats)
                .Page(inputModel)
                .ToList();

            return new ManageCommentsViewModel
            {
                Comments = comments.Select(x => x.DynamicMap<ManageCommentViewModel>()),
                TotalPages = stats.TotalPages(inputModel.Count ?? 0)
            };
        }
    }
}