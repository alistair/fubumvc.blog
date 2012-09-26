using System.Linq;
using Blog.Articles.Domain;
using Blog.Core.Extensions;
using Raven.Client;
using Raven.Client.Linq;

namespace Blog.Articles.Manage
{
    public class GetHandler
    {
        private readonly IDocumentSession _session;

        public GetHandler(IDocumentSession session)
        {
            _session = session;
        }

        public ManageArticlesViewModel Execute(ManageArticlesInputModel inputModel)
        {
            RavenQueryStatistics stats;
            var articles = _session.Query<Article>()
                .OrderByDescending(x => x.PublishedDate)
                .Statistics(out stats)
                .Page(inputModel)
                .ToList();

            return new ManageArticlesViewModel
            {
                Articles = articles.Select(x => x.DynamicMap<ManageArticleViewModel>()),
                TotalPages = stats.TotalPages(inputModel.Count ?? 0)
            };
        }

    }
}