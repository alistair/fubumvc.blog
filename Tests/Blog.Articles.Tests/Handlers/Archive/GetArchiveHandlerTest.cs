using System;
using System.Collections.Generic;
using System.Linq;
using Blog.Articles.Archive;
using Blog.Articles.Domain;
using Blog.Core.Domain;
using Blog.Core.Tests;
using MongoAdapt;
using SharpTestsEx;
using Xunit;

namespace Blog.Articles.Tests.Handlers.Archive
{
    public class GetArchiveHandlerTest : TestContext<Articles.Archive.GetHandler>
    {
        private IList<Article> _articles;

        protected override void Given()
        {
            _articles = new[]
            {
                new Article
                {
                    IsPublished = false,
                    Id = "1",
                    PublishedDate = new DateTime(2000, 1, 1)
                },
                new Article
                {
                    IsPublished = true,
                    Id = "2",
                    PublishedDate = new DateTime(2000, 1, 2)
                },
                new Article
                {
                    IsPublished = true,
                    Id = "2",
                    PublishedDate = new DateTime(2001, 1, 1)
                }
            };

            Container.GetMock<IDocumentDatabase>()
                .Setup(x => x.Query<Article>())
                .Returns(new EnumerableQuery<Article>(_articles));
        }

        [Fact]
        public void Has_full_archive_of_published_articles__grouped_by_year_only()
        {
            var archive = ClassUnderTest.Execute(new ArchiveInputModel()).Items;
            archive.Should().Not.Be.Empty();
            archive.Count.Should("Expected to have two different years.").Be(2);

            var firstArchive = archive.Single(x => x.Key == 2000).Value;
            firstArchive.Count.Should("Expected to only have one publishedItem").Be(1);

            var firstArchivedItem = firstArchive.First();
            firstArchivedItem.Id.Should().Be(_articles[1].Id);
            firstArchivedItem.PublishedDate.Should().Be(_articles[1].PublishedDate);
            firstArchivedItem.Title.Should().Be(_articles[1].Title);
        }
    }
}