using System.Linq;
using Blog.Articles.Domain;
using Blog.Core.Extensions;
using Raven.Client;

namespace Blog.Articles.Archive
{
    public class GetHandler
    {
        private readonly IDocumentSession _session;

        public GetHandler(IDocumentSession session)
        {
            _session = session;
        }

        public ArchiveViewModel Execute(ArchiveInputModel inputModel)
        {
            var articles = _session.Query<Article>().ToList();

             return new ArchiveViewModel
             {
                 Items = articles
                    .Where(x => x.IsPublished)
                    .GroupBy(x => x.PublishedDate.Year, x => x.DynamicMap<ArchiveItemViewModel>())
                    .ToDictionary(x => x.Key, x => x.ToList())
             };
         }
    }
}