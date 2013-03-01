using System;
using System.Collections.Generic;
using System.Linq;
using Blog.Comments.Domain;
using Blog.Comments.Recent;
using Blog.Core.Tests;
using MongoAdapt;
using SharpTestsEx;
using Xunit;

namespace Blog.Comments.Tests.Handlers.Recent
{
    public class GetMostRecentCommentsHandlerTest : TestContext<Comments.Recent.GetHandler>
    {
        private IList<Comment> _comments;

        protected override void Given()
        {
            _comments = new List<Comment>();

            for (var i = 0; i < 5; i++)
            {
                _comments.Add(new Comment(Guid.NewGuid())
                {
                    PublishedDate = DateTime.Today.AddDays(-i),
                    Author = "test",
                    ArticleUri = "test",
                    Body = "some body",
                    IsApproved = true,
                    IsPotentialSpam = true
                });
            }
            Container.GetMock<IDocumentDatabase>()
                     .Setup(x => x.Query<Comment>())
                     .Returns(new EnumerableQuery<Comment>(_comments));
        }

        [Fact]
        public void Gets_five_most_recent_comments()
        {
            var recentComments = ClassUnderTest.Execute(new RecentCommentInputModel());

            recentComments.Should().Not.Be.Empty();
            recentComments.Count().Should().Be.EqualTo(5);
            recentComments.All(x => x.PublishedDate >= DateTime.Today.AddDays(-5) ).Should().Be.True();
            recentComments.All(x => x.Id != null).Should().Be.True();
            recentComments.All(x => x.Author == "test").Should().Be.True();
            recentComments.All(x => x.Body == "some body").Should().Be.True();
        }

    }
}