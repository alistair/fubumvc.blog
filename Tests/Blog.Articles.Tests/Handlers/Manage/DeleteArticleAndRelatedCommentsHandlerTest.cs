using Blog.Articles.Domain;
using Blog.Articles.Manage;
using Blog.Core.Tests;
using MongoAdapt;
using Xunit;

namespace Blog.Articles.Tests.Handlers.Manage
{
    public class DeleteArticleAndRelatedCommentsHandlerTest : TestContext<DeleteHandler>
    {
        private string _articleId;

        protected override void Given()
        {
            _articleId = "test";
        }

        [Fact]
        public void Verify_deletion_of_article_and_comments_uses_correct_articleId()
        {
            ClassUnderTest.Execute(new DeleteArticleInputModel
            {
                Id = _articleId
            });

            Container.GetMock<IDocumentDatabase>()
                .Verify(x => x.Delete(new Article{ Id = _articleId}));

            //TODO: Container.GetMock<IDocumentDatabase>()
            //    .Verify(x => x.Delete("Comments", "ArticleUri", _articleId));
        }
    }
}