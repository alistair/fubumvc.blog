using System;
using Blog.Articles.Domain;
using Blog.Core.Domain;
using FubuMVC.Core.Runtime;
using Raven.Client;

namespace Blog.Articles.Compose
{
    public class PostHandler
    {
        private readonly IDocumentSession _session;
        private readonly ISessionState _state;

        public PostHandler(IDocumentSession session, ISessionState state)
        {
            _session = session;
            _state = state;
        }

        public ComposeArticleResourceModel Execute(ComposeArticleInputModel inputModel)
        {
            var identity = _state.Get<UserInformation>();

            _session.Store(new Article
            {
                Author = identity != null
                    ? string.Format("{0} {1}", identity.FirstName, identity.LastName)
                    : "Unknown",
                Body = inputModel.Body,
                Id =  inputModel.Id,
                Title = inputModel.Title,
                PublishedDate = DateTime.Now
            });

            return new ComposeArticleResourceModel(inputModel.Id);
        }
    }
}