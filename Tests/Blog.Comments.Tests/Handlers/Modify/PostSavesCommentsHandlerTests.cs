using Blog.Comments.Domain;
using Blog.Comments.Modify;
using Blog.Core.Tests;
using MongoAdapt;
using Moq;
using Xunit;

namespace Blog.Comments.Tests.Handlers.Modify
{
    public class PostSavesCommentsHandlerTests : TestContext<Comments.Modify.PostHandler>
    {
        [Fact]
        public void Verfiy_save_comment()
        {
            ClassUnderTest.Execute(new UpdateCommentInputModel());

            Container.GetMock<IDocumentDatabase>()
                .Verify(x => x.Save(It.IsAny<Comment>()));
        }
    }
}