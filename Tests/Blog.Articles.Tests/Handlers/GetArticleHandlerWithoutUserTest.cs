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
    public class GetArticleHandlerWithoutUserTest : TestContext<GetHandler>
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
        public void Expect_article_view_data_based_on_article_uri()
        {
            var articlesViewModel = ClassUnderTest.Execute(new ArticleInputModel
            {
                Uri = _article.Id
            });

            articlesViewModel.Author.Should().Be("Unknown");
            articlesViewModel.Body.Should().Be(_article.Body);
            articlesViewModel.Id.Should().Be(_article.Id);
            articlesViewModel.PublishedDate.Should().Be(_article.PublishedDate);
            articlesViewModel.PublishedDateString.Should().Be(_article.PublishedDate.ToString("MMMM dd, yyyy"));
            articlesViewModel.Title.Should().Be(_article.Title);
        }

        [Fact]
        public void Expect_no_article_view_data_for_no_uri()
        {
            var articlesViewModel = ClassUnderTest.Execute(new ArticleInputModel());

            articlesViewModel.Should().Not.Be.Null();
            articlesViewModel.Id.Should().Be.Null();
        }
    }
}