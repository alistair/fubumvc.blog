using System;
using Blog.Articles.Domain;
using Blog.Articles.Manage;
using Blog.Core.Database;
using FubuMVC.Core.Security;
using FubuMVC.Core.Urls;

namespace Blog.Articles.Compose
{
    public class PostHandler
    {
        private readonly IDocumentDatabase _database;
        private readonly ISecurityContext _securityContext;
        private readonly UrlRegistry _urlRegistry;

        public PostHandler(IDocumentDatabase database, ISecurityContext securityContext,
            UrlRegistry urlRegistry)
        {
            _database = database;
            _securityContext = securityContext;
            _urlRegistry = urlRegistry;
        }

        public ComposeArticleResourceModel Execute(ComposeArticleInputModel inputModel)
        {
            _database.Save(new Article
                {
                    AuthorId = _securityContext.CurrentIdentity.Name,
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