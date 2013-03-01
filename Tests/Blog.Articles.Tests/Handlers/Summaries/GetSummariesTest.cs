using System;
using System.Collections.Generic;
using System.Linq;
using Blog.Articles.Domain;
using Blog.Articles.Summaries;
using Blog.Core.Constants;
using Blog.Core.Domain;
using Blog.Core.Extensions;
using Blog.Core.Tests;
using MongoAdapt;
using SharpTestsEx;
using Xunit;

namespace Blog.Articles.Tests.Handlers.Summaries
{
    public class GetSummariesTest : TestContext<Articles.Summaries.GetHandler>
    {
        private IList<Article> _articles;
        private Article _article;
        private User _user;

        protected override void Given()
        {
            _article = new Article
            {
                IsPublished = true,
                Title = "published",
                PublishedDate = DateTime.Today,
                AuthorId = "test",
                Body = string.Format("summary {0} body", StringConstants.ArticleMore)
            };

            _user = new User
            {
                Id = "test",
                FirstName = "John",
                LastName = "Doe"
            };

            _articles = new List<Article>
            {
                _article,
                new Article
                {
                    IsPublished = false,
                    Title = "test",
                    PublishedDate = DateTime.Today,
                    AuthorId = "test"
                }
            };

            Container.GetMock<IDocumentDatabase>()
                .Setup(x => x.Query<Article>())
                .Returns(new EnumerableQuery<Article>(_articles));

            Container.GetMock<IDocumentDatabase>()
                .Setup(x => x.Query<User>())
                .Returns(new EnumerableQuery<User>(new [] { _user }));
        }

        [Fact]
        public void Gets_published_articles_summaries()
        {
            var result = ClassUnderTest.Execute(new ArticleSummariesInputModel());

            var summaries = result.Summaries.ToList();

            summaries.Should().Not.Be.Empty();
            summaries.Count.Should().Be(1);
            var summary = summaries.Single();

            summary.Author.Should().Be(_user.FullName());
            summary.Title.Should().Be(_article.Title);
            summary.Body.Should().Be(_article.Body);
            summary.Id.Should().Be(_article.Id);
            summary.PublishedDate.Should().Be(_article.PublishedDate);
            summary.PublishedDateString.Should().Be(_article.PublishedDate.ToString("MMMM dd, yyyy"));
            summary.Summary.Should().Be("summary");
        }

    }
}