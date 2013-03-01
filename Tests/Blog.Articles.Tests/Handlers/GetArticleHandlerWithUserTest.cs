using System;
using System.Linq;
using Blog.Articles.Domain;
using Blog.Core.Domain;
using Blog.Core.Tests;
using MongoAdapt;
using SharpTestsEx;
using Xunit;

namespace Blog.Articles.Tests.Handlers
{
    public class GetArticleHandlerWithUserTest : TestContext<GetHandler>
    {
        private Article _article;
        private User _user;

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

            _user = new User
            {
                Id = "test",
                FirstName = "John",
                LastName = "Doe"
            };

            Container.GetMock<IDocumentDatabase>()
                     .Setup(x => x.Query<Article>())
                     .Returns(new EnumerableQuery<Article>(new[] { _article }));

            Container.GetMock<IDocumentDatabase>()
                     .Setup(x => x.Query<User>())
                     .Returns(new EnumerableQuery<User>(new[] { _user }));
        }

        [Fact]
        public void Expect_article_view_data_based_on_article_uri()
        {
            var articlesViewModel = ClassUnderTest.Execute(new ArticleInputModel
            {
                Uri = _article.Id
            });

            articlesViewModel.Author.Should().Be("John Doe");
            articlesViewModel.Body.Should().Be(_article.Body);
            articlesViewModel.Id.Should().Be(_article.Id);
            articlesViewModel.PublishedDate.Should().Be(_article.PublishedDate);
            articlesViewModel.PublishedDateString.Should().Be(_article.PublishedDate.ToString("MMMM dd, yyyy"));
            articlesViewModel.Title.Should().Be(_article.Title);
        }
    }
}