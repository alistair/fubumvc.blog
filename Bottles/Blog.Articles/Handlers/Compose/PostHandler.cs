using System;
using Blog.Articles.Domain;
using FubuMVC.Core.Security;
using Raven.Client;

namespace Blog.Articles.Compose
{
    public class PostHandler
    {
        private readonly IDocumentSession _session;
        private readonly ISecurityContext _securityContext;

        public PostHandler(IDocumentSession session, ISecurityContext securityContext)
        {
            _session = session;
            _securityContext = securityContext;
        }

        public ComposeArticleResourceModel Execute(ComposeArticleInputModel inputModel)
        {
            _session.Store(new Article
            {
                Author = _securityContext.CurrentIdentity.Name,
                Body = inputModel.Body,
                Id =  inputModel.Id,
                Title = inputModel.Title,
                PublishedDate = DateTime.Now
            });

            return new ComposeArticleResourceModel();
        }
    }
}