using Blog.Articles.Domain;
using Blog.Core.Extensions;
using Raven.Client;

namespace Blog.Articles.Manage
{
    public class DeleteHandler
    {
        private readonly IDocumentSession _session;

        public DeleteHandler(IDocumentSession session)
        {
            _session = session;
        }

        public DeleteArticleViewModel Execute(DeleteArticleInputModel inputModel)
        {
            _session.Delete<Article>(inputModel.Id);
            return new DeleteArticleViewModel();
        }
    }
}