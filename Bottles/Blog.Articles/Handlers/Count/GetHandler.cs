using System;
using System.Linq;
using Blog.Articles.Domain;
using Blog.Core.Database;

namespace Blog.Articles.Count
{
    public class GetHandler
    {
        private readonly IDocumentDatabase _database;

        public GetHandler(IDocumentDatabase database)
        {
            _database = database;
        }

        public dynamic Execute(ArticlesCountInputModel inputModel)
        {
            long totalCount;
            var draftCount = _database
                .WithCount<Article>(out totalCount)
                .Where(x => !x.IsPublished)
                .LongCount();

            var history = _database.Query<Article>()
                .Where(x => x.PublishedDate > DateTime.Now.Subtract(new TimeSpan(30, 0, 0, 0)))
                .ToList()
                .GroupBy(x => x.PublishedDate.Date)
                .Select(x => new DateCountViewModal
                {
                    PostedDate = x.Key.ToString("MM/dd"),
                    DraftArticleCount = x.Sum(a => a.IsPublished ? 0 : 1),
                    PostedArticleCount = x.Sum(a => a.IsPublished ? 1 : 0),
                });


            return new ArticlesCountViewModel
            {
                Total = totalCount,
                Draft = draftCount,
                History = history
            };
        }
    }
}