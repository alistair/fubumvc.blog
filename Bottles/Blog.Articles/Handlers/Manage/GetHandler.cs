using System.Linq;
using Blog.Articles.Domain;
using Blog.Core.Domain;
using Blog.Core.Extensions;
using MongoAdapt;

namespace Blog.Articles.Manage
{
    public class GetHandler
    {
        private readonly IDocumentDatabase _database;

        public GetHandler(IDocumentDatabase database)
        {
            _database = database;
        }

        public ManageArticlesViewModel Execute(ManageArticlesInputModel inputModel)
        {
            IDocumentCollection stats;

            var articles = _database
                .Statistics<Article>(out stats)
                .FilteryByPublished(inputModel.ShowDraft)
                .Page(inputModel)
                .ToList();

            return new ManageArticlesViewModel
            {
                Articles = articles.Select(x => x.DynamicMap<ManageArticleViewModel>()),
                TotalPages = stats.Count.TotalPages(inputModel.Count),
                ShowDraft = inputModel.ShowDraft
            };
        }

    }
}