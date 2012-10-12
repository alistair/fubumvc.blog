using System.Linq;
using Blog.Articles.Domain;
using Blog.Core.Extensions;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Blog.Articles.Archive
{
    public class GetHandler
    {
        private readonly MongoDatabase _database;

        public GetHandler(MongoDatabase database)
        {
            _database = database;
        }

        public ArchiveViewModel Execute(ArchiveInputModel inputModel)
        {
            var articles  = _database.GetCollection("Articles")
                .AsQueryable<Article>()
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