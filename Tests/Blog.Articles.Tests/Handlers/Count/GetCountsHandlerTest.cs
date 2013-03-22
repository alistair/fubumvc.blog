using System;
using System.Linq;
using Blog.Articles.Count;
using Blog.Articles.Domain;
using Blog.Articles.Tests.Domain;
using Blog.Core.Domain;
using Blog.Core.Tests;
using MongoAdapt;
using SharpTestsEx;
using Xunit;

namespace Blog.Articles.Tests.Handlers.Count
{
    public class GetCountsHandlerTest : TestContext<Articles.Count.GetHandler>
    {
        private DateTime _date;

        protected override void Given()
        {
            _date = DateTime.Today;

            var article = new Article
            {
                IsPublished = false,
                PublishedDate = _date
            };

            var publishedArticle = new Article
            {
                IsPublished = true,
                PublishedDate = _date
            };

            var oldArticle = new Article
            {
                IsPublished = true,
                PublishedDate = _date.AddDays(-30)
            };

            var articles = new[]
            {
                article,
                publishedArticle,
                oldArticle
            };

            IDocumentCollection totalCount = new Stats(articles.LongCount());

            TODO: Container.GetMock<IDocumentDatabase>()
                .Setup(x => x.Statistics<Article>(out totalCount))
                .Returns(new EnumerableQuery<Article>(articles));

            Container.GetMock<IDocumentDatabase>()                .Setup(x => x.Query<Article>())                .Returns(new EnumerableQuery<Article>(articles));        }
        [Fact]
        public void Gets_counts_with_history_of_past_30_days()
        {
            var result = ClassUnderTest.Execute(new ArticlesCountInputModel());

            result.Total.Should().Be(3);
            result.Draft.Should().Be(1);

            result.History.Should().Not.Be.Empty();
            var historyItem = result.History.Single(x => x.PostedDate == _date.ToString("MM/dd"));

            historyItem.DraftArticleCount.Should().Be(1);
            historyItem.PostedArticleCount.Should().Be(1);
        }
    }
}