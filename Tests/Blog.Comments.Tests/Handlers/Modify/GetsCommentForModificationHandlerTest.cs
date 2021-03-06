﻿using System;
using System.Linq;
using Blog.Comments.Domain;
using Blog.Comments.Modify;
using Blog.Core.Domain;
using Blog.Core.Tests;
using MongoAdapt;
using SharpTestsEx;
using Xunit;

namespace Blog.Comments.Tests.Handlers.Modify
{
    public class GetsCommentForModificationHandlerTest : TestContext<Comments.Modify.GetHandler>
    {
        private Comment _comment;

        protected override void Given()
        {
            _comment = new Comment(Guid.NewGuid());

            Container.GetMock<IDocumentDatabase>()
                     .Setup(x => x.Load<Comment>(_comment.Id))
                     .Returns(_comment);
        }

        [Fact]
        public void Gets_comment_for_modification_by_comment_id()
        {

            var commentForModification = ClassUnderTest.Execute(new ModifyCommentInputModel
            {
                Id = _comment.Id
            });

            commentForModification.Author.Should().Be.EqualTo(_comment.Author);
            commentForModification.ArticleUri.Should().Be.EqualTo(_comment.ArticleUri);
            commentForModification.Body.Should().Be.EqualTo(_comment.Body);
            commentForModification.Id.Should().Be.EqualTo(_comment.Id.ToString());
        }
    }
}