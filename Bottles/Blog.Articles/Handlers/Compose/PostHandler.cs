using System;
using Blog.Articles.Domain;
using Blog.Articles.Manage;
using Blog.Core.Domain;
using FubuMVC.Core.Runtime;
using FubuMVC.Core.Urls;
using Raven.Client;

namespace Blog.Articles.Compose
{
    public class PostHandler
    {
        private readonly IDocumentSession _session;
        private readonly ISessionState _state;
        private readonly UrlRegistry _urlRegistry;

        public PostHandler(IDocumentSession session, ISessionState state,
            UrlRegistry urlRegistry)
        {
            _session = session;
            _state = state;
            _urlRegistry = urlRegistry;
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
                CommentsCount = inputModel.CommentsCount,
                Id =  inputModel.Id,
                Title = inputModel.Title,
                PublishedDate = DateTime.Now,
                IsPublished = !inputModel.IsDraft
            });

            return new ComposeArticleResourceModel
            {
                Url = inputModel.Id,
                ManageUrl = _urlRegistry.UrlFor<ManageArticlesInputModel>()
            };
        }
    }
}