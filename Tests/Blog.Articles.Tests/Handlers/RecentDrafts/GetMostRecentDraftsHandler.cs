using System;
using System.Collections.Generic;
using System.Linq;
using Blog.Articles.Domain;
using Blog.Articles.RecentDrafts;
using Blog.Core.Domain;
using Blog.Core.Tests;
using MongoAdapt;
using SharpTestsEx;
using Xunit;

namespace Blog.Articles.Tests.Handlers.RecentDrafts
{
    public class GetMostRecentDraftsHandler : TestContext<Articles.RecentDrafts.GetHandler>
    {
        private IList<Article> _articles;

        protected override void Given()
        {
            _articles = new List<Article>
            {
                new Article
                {
                    IsPublished = true,
                    Title = "published"
                }
            };

            for (var i = 0; i < 12; i++)
            {
                _articles.Add(new Article
                {
                    AuthorId = "test",
                    Body = "some text",
                    Id = i.ToString(),
                    CommentsCount = i,
                    IsPublished = false,
                    PublishedDate = DateTime.Today,
                    Title = "test"
                });
            }

            Container.GetMock<IDocumentDatabase>()
                .Setup(x => x.Query<Article>())
                .Returns(new EnumerableQuery<Article>(_articles));
        }

        [Fact]
        public void Gets_top_five_draft_articles()
        {
            var result = ClassUnderTest.Execute(new RecentDraftsInputModel())
                .RecentDrafts
                .ToList();

            result.Should().Not.Be.Empty();
            result.Count.Should().Be(5);
            result.All(x => !x.Title.Contains("published"));

        }
    }
}