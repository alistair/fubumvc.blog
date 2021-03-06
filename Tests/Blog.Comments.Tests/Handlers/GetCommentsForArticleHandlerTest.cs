﻿using System;
using System.Collections.Generic;
using System.Linq;
using Blog.Comments.Domain;
using Blog.Core.Domain;
using Blog.Core.Tests;
using MongoAdapt;
using SharpTestsEx;
using Xunit;

namespace Blog.Comments.Tests.Handlers
{
    public class GetCommentsForArticleHandlerTest : TestContext<GetHandler>
    {
        private string _articleId;
        private Comment _comment;

        protected override void Given()
        {
            _articleId = "test";

            _comment = new Comment(Guid.NewGuid())
            {
                ArticleUri = _articleId,
                Author = "test",
                Body = "some body",
                IsApproved = true,
                IsPotentialSpam = false,
                PublishedDate = DateTime.Today
            };

            Container.GetMock<IDocumentDatabase>()
                     .Setup(x => x.Query<Comment>())
                     .Returns(new EnumerableQuery<Comment>(new[]
                     {
                        _comment,
                        new Comment(_comment.Id) { ArticleUri = "blah" }
                     }));
        }

        [Fact]
        public void Gets_comments_for_a_specific_article()
        {
            var result = ClassUnderTest.Execute(new CommentsInputModel
            {
                Uri = _articleId
            });

            result.Uri.Should().Be(_articleId);
            result.Comments.Should().Not.Be.Empty();
            result.Comments.Each(x => x.ArticleUri.Should().Be.EqualTo(_articleId));

            var comment = result.Comments.Single();

            comment.Author.Should().Be(_comment.Author);
            comment.Body.Should().Be(_comment.Body);
            comment.PublishedDate.Should().Be(_comment.PublishedDate);
            comment.PublishedDateString.Should().Be(_comment.PublishedDate.ToString("MMMM dd, yyyy (hh:mm)"));
        }
    }
}