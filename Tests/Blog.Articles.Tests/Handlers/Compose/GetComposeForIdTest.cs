using System;
using System.Linq;
using Blog.Articles.Compose;
using Blog.Articles.Domain;
using Blog.Core.Domain;
using Blog.Core.Tests;
using MongoAdapt;
using SharpTestsEx;
using Xunit;

namespace Blog.Articles.Tests.Handlers.Compose
{
    public class GetComposeForIdTest : TestContext<Articles.Compose.GetHandler>
    {
        private Article _article;

        protected override void Given()
        {
            _article = new Article
            {
                Id = "test",
                AuthorId = "test",
                Body = "a body of text",
                CommentsCount = 3,
                IsPublished = true,
                PublishedDate = new DateTime(2012,1,1),
                Title = "test"
            };

            Container.GetMock<IDocumentDatabase>()
                .Setup(x => x.Query<Article>())
                .Returns(new EnumerableQuery<Article>(new[] { _article }));
        }

        [Fact]
        public void Retrieves_existing_article_for_composing()
        {
            var composeViewModel = ClassUnderTest.Execute(new ComposeInputModel
            {
                Id = "test"
            });

            composeViewModel.Body.Should().Be(_article.Body);
            composeViewModel.CommentsCount.Should().Be(_article.CommentsCount);
            composeViewModel.Id.Should().Be(_article.Id);
            composeViewModel.IsPublished.Should().Be(_article.IsPublished);
            composeViewModel.Title.Should().Be(_article.Title);
        }
    }
}