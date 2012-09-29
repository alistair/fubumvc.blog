using System.Collections.Generic;
using Blog.Comments.Domain;
using Raven.Client;
using Raven.Client.Linq;

namespace Blog.Comments.DeleteForArticle
{
    public class DeleteHandler
    {
        private readonly IDocumentSession _session;

        public DeleteHandler(IDocumentSession session)
        {
            _session = session;
        }

        public void Execute(DeleteCommentsForArticleInputModel inputModel)
        {
            var comments = _session.Query<Comment>()
                .Where(x => x.ArticleUri == inputModel.ArticleId);

            comments.Each(x => _session.Delete(x));
        }
    }
}