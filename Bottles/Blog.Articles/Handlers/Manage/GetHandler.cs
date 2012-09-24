using System.Linq;
using Blog.Articles.Domain;
using Blog.Core.Extensions;
using Raven.Client;

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
            var articles = _session.Query<Article>()
                .Page(inputModel)
                .ToList();

             return new ManageArticlesViewModel
             {
                 Articles = articles.Select(x => x.DynamicMap<ManageArticleViewModel>())
             };
         }

    }
}