using Blog.Articles.Domain;
using Blog.Core.Extensions;
using FubuMVC.Core;
using Raven.Client;

namespace Blog.Articles
{
  public class GetHandler
  {
      private readonly IDocumentSession _session;

    public GetHandler(IDocumentSession session)
    {
        _session = session;
    }

    [UrlPattern("{Uri}")]
    public ArticleViewModel Execute(ArticleInputModel inputModel)
    {
        var article = _session.Load<Article>(inputModel.Uri);

        return article.DynamicMap<ArticleViewModel>();
    }
  }
}