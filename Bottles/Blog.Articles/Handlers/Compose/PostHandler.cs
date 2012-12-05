using System;
using Blog.Articles.Domain;
using Blog.Articles.Manage;
using FubuMVC.Core.Security;
using FubuMVC.Core.Urls;
using MongoDB.Driver;

namespace Blog.Articles.Compose
{
    public class PostHandler
    {
        private readonly MongoDatabase _database;
        private readonly ISecurityContext _securityContext;
        private readonly UrlRegistry _urlRegistry;

        public PostHandler(MongoDatabase database, ISecurityContext securityContext,
            UrlRegistry urlRegistry)
        {
            _database = database;
            _securityContext = securityContext;
            _urlRegistry = urlRegistry;
        }

        public ComposeArticleResourceModel Execute(ComposeArticleInputModel inputModel)
        {
            _database.GetCollection("Articles")
                .Save(new Article
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