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

            return new ArticlesCountViewModel
            {
                Total = totalCount,
                Draft = draftCount
            };
        }
    }
}