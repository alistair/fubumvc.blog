﻿using Blog.Comments.Domain;
using Blog.Core.Domain;
using Blog.Core.Tests;
using MongoAdapt;
using Moq;
using Xunit;

namespace Blog.Comments.Tests.Handlers
{
    public class PostSaveCommentForArticleHandlerTest : TestContext<PostHandler>
    {
        private CommentInputModel _commentInputModel;

        protected override void Given()
        {
            _commentInputModel = new CommentInputModel
            {
                Uri = "test"
            };
        }

        [Fact]
        public void Saves_comment_increments_article_comment_count()
        {
            ClassUnderTest.Execute(_commentInputModel);

            Container.GetMock<IDocumentDatabase>()
                .Verify(x => x.Increment<Article>(_commentInputModel.Uri, a => a.CommentsCount));

            Container.GetMock<IDocumentDatabase>()
                .Verify(x => x.Save(It.IsAny<Comment>()));
        }
    }
}