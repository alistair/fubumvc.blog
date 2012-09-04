using System.Linq;
using Blog.Articles.Domain;
using Blog.Core.Extensions;
using Raven.Client;

namespace Blog.Articles.Summaries
{
    public class GetHandler
    {
        private readonly IDocumentSession _session;

        public GetHandler(IDocumentSession session)
        {
            _session = session;
        }

        public ArticleSummariesViewModel Execute()
        {
            var articles = _session.Query<Article>()
                .OrderByDescending(x => x.PublishedDate)
                .Take(10).ToList();
            return new ArticleSummariesViewModel
            {
                Summaries = articles.Select(x => x.DynamicMap<ArticleSummaryViewModel>())
            };
        }
    }
}