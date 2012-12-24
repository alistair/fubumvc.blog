using System;
using System.Linq;
using Blog.Comments.Domain;
using Blog.Comments.Manage;
using Blog.Core.Database;
using Blog.Core.Tests;
using Xunit;

namespace Blog.Comments.Tests.Handlers.Manage
{
    public class DeleteCommentTest : TestContext<DeleteHandler>
    {
        private Comment _comment;

        protected override void Given()
        {
            _comment = new Comment
            {
                Id = Guid.NewGuid(),
                ArticleUri = "test"
            };

            Container.GetMock<IDocumentDatabase>()
                     .Setup(x => x.Query<Comment>())
                     .Returns(new EnumerableQuery<Comment>(new[] { _comment }));
        }

        [Fact]
        public void Deletes_comment_updates_article_comment_count()
        {
            ClassUnderTest.Execute(new DeleteCommentInputModel
            {
                Id = _comment.Id
            });

            Container.GetMock<IDocumentDatabase>()
                .Verify(x => x.Increment("Articles", _comment.ArticleUri, "CommentsCount", -1));

            Container.GetMock<IDocumentDatabase>()
                .Verify(x => x.Delete<Comment>(_comment.Id));
        }
    }
}