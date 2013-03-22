using System.Linq;
using Blog.Articles.Domain;
using Blog.Core.Domain;
using Blog.Core.Extensions;
using MongoAdapt;

namespace Blog.Articles.Archive
{
    public class GetHandler
    {
        private readonly IDocumentDatabase _database;

        public GetHandler(IDocumentDatabase database)
        {
            _database = database;
        }

        public ArchiveViewModel Execute(ArchiveInputModel inputModel)
        {
            var articles  = _database.Query<Article>()
                .Where(x => x.IsPublished)
                .ToList();

             return new ArchiveViewModel
             {
                 Items = articles
                    .GroupBy(x => x.PublishedDate.Year, x => x.DynamicMap<ArchiveItemViewModel>())
                    .ToDictionary(x => x.Key, x => x.ToList())
             };
         }
    }
}