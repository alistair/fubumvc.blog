using Blog.Articles.Compose;
using Blog.Articles.Domain;
using Blog.Core.Database;
using Blog.Core.Tests;
using FubuMVC.Core.Security;
using Moq;
using SharpTestsEx;
using Xunit;

namespace Blog.Articles.Tests.Handlers.Compose
{
    public class PostSaveArticleHandler : TestContext<PostHandler>
    {
        private ComposeArticleInputModel _inputModel;

        protected override void Given()
        {
            Container.GetMock<ISecurityContext>()
                     .Setup(x => x.CurrentIdentity)
                     .Returns(new TestIdentity("test"));

            _inputModel = new ComposeArticleInputModel
            {
                Id = "test",
                Body = "some body",
                CommentsCount = 1,
                IsDraft = true,
                Title = "test"
            };
        }

        [Fact]
        public void Saved_article_and_let_user_know_article_url()
        {
            var viewModel = ClassUnderTest.Execute(_inputModel);

            Container.GetMock<IDocumentDatabase>()
                .Verify(x => x.Save(It.IsAny<Article>()));

            viewModel.Url.Should().Be.EqualTo("/" + _inputModel.Id);
        }
    }
}