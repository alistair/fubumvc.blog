using Blog.Articles.Domain;
using Blog.Core.Extensions;
using Raven.Client;

namespace Blog.Articles.Compose
{
    public class GetHandler
    {
        private readonly IDocumentSession _session;

        public GetHandler(IDocumentSession session)
        {
            _session = session;
        }

        public ComposeViewModel Execute(ComposeInputModel inputModel)
        {
            if(string.IsNullOrEmpty(inputModel.Id)) return new ComposeViewModel();

            var article = _session.Load<Article>(inputModel.Id);

            return article.DynamicMap<ComposeViewModel>();
        }
    }
}