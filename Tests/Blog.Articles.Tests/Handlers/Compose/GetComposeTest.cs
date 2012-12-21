using Blog.Articles.Compose;
using Blog.Core.Tests;
using SharpTestsEx;
using Xunit;

namespace Blog.Articles.Tests.Handlers.Compose
{
    public class GetComposeTest : TestContext<Articles.Compose.GetHandler>
    {
        [Fact]
        public void Retrieves_existing_article_for_composing()
        {
            var composeViewModel = ClassUnderTest.Execute(new ComposeInputModel());

            composeViewModel.Should().Not.Be.Null();
            composeViewModel.Should().Be.OfType<ComposeViewModel>();
        }
    }
}