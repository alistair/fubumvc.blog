using Blog.Core.Domain;
using SharpTestsEx;
using Xunit;

namespace Blog.Core.Tests.Domain
{
    public class UserTests : TestContext<User>
    {
        [Fact]
        public void Generates_hash_for_gravatar_email()
        {
            ClassUnderTest.GravatarEmailAddress = "test@test.com";

            ClassUnderTest.GravatarHash
                .Should()
                .Be("b642b4217b34b1e8d3bd915fc65c4452");
        }

        [Fact]
        public void Does_not_generate_hash_for_gravatar_email()
        {
            ClassUnderTest.GravatarHash.Should().Be.Null();
        }
    }
}