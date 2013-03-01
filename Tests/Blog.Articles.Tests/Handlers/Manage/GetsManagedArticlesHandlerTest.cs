using System;
using System.Linq;
using Blog.Articles.Domain;
using Blog.Articles.Manage;
using Blog.Core.Tests;
using MongoAdapt;
using SharpTestsEx;
using Xunit;

namespace Blog.Articles.Tests.Handlers.Manage
{
    public class GetsManagedArticlesHandlerTest : TestContext<Articles.Manage.GetHandler>
    {
        private Article _article;

        protected override void Given()
        {
            _article =
                new Article
                {
                    AuthorId = "test",
                    IsPublished = false,
                    Id = "1",
                    PublishedDate = new DateTime(2000, 1, 1),
                    CommentsCount = 1,
                    Title = "test"
                };

            long count;

            //Container.GetMock<IDocumentDatabase>()
            //    .Setup(x => x.WithCount<Article>(out count))
            //    .Returns(new EnumerableQuery<Article>(new[] { _article }));
        }

        [Fact]
        public void Retrieves_articles_for_management()
        {
            var articlesForManagement = ClassUnderTest.Execute(
                new ManageArticlesInputModel());

            articlesForManagement.ShowDraft.Should().Be(null);
            articlesForManagement.TotalPages.Should().Be(1);
            articlesForManagement.Articles.Should().Not.Be.Empty();
            articlesForManagement.Articles.Count().Should().Be(1);

            var article = articlesForManagement.Articles.Single();

            article.Id.Should().Be(_article.Id);
            article.IsPublished.Should().Be(_article.IsPublished);
            article.PublishedDate.Should().Be(_article.PublishedDate);
            article.PublishedDateString.Should().Be(_article.PublishedDate.ToShortDateString());
            article.Title.Should().Be(_article.Title);
        }
    }
}