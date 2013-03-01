using System.Linq;
using Blog.Articles.Domain;
using Blog.Core.Extensions;
using MongoAdapt;

namespace Blog.Articles.RecentDrafts
{
    public class GetHandler
    {
        private readonly IDocumentDatabase _database;

        public GetHandler(IDocumentDatabase database)
        {
            _database = database;
        }

        public RecentDraftsViewModel Execute(RecentDraftsInputModel inputModel)
        {
            var articles = _database.Query<Article>()
                     .OrderByDescending(x => x.PublishedDate)
                     .Where(x => !x.IsPublished)
                     .Take(5);

            return new RecentDraftsViewModel(articles.Select(x => x.DynamicMap<RecentDraftViewModel>()));
        }
    }
}