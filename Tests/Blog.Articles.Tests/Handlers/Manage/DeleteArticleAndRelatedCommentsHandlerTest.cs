using System;
using System.Collections.Generic;
using System.Linq;
using Blog.Articles.Domain;
using Blog.Articles.Manage;
using Blog.Core.Domain;
using Blog.Core.Tests;
using MongoAdapt;
using Moq;
using Xunit;

namespace Blog.Articles.Tests.Handlers.Manage
{
    public class DeleteArticleAndRelatedCommentsHandlerTest : TestContext<DeleteHandler>
    {
        private string _articleId;

        protected override void Given()
        {
            _articleId = "test";
            Container.GetMock<IDocumentDatabase>()
                     .Setup(x => x.Query<Comment>())
                     .Returns(new List<Comment>
                         {
                             new Comment(Guid.NewGuid())
                                 {
                                     ArticleUri = _articleId,
                                 }
                         }.AsQueryable());
        }

        [Fact]
        public void Verify_deletion_of_article_and_comments_uses_correct_articleId()
        {
            ClassUnderTest.Execute(new DeleteArticleInputModel
            {
                Id = _articleId
            });

            Container.GetMock<IDocumentDatabase>()
                .Verify(x => x.Delete<Article>(_articleId));

            Container.GetMock<IDocumentDatabase>()
                .Verify(x => x.Delete(It.IsAny<Comment>()));
        }
    }
}