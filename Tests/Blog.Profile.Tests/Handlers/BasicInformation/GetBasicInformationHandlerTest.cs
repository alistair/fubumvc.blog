using System.Linq;
using Blog.Core.Domain;
using Blog.Core.Extensions;
using Blog.Core.Tests;
using Blog.Profile.BasicInformation;
using FubuMVC.Core.Security;
using MongoAdapt;
using SharpTestsEx;
using Xunit;

namespace Blog.Profile.Tests.Handlers.BasicInformation
{
    public class GetBasicInformationHandlerTest : TestContext<Profile.BasicInformation.GetHandler>
    {
        private string _userId;
        private User _user;

        protected override void Given()
        {
            _userId = "test";
            _user = new User
            {
                Id = _userId,
                NickName = "JDoe",
                FirstName = "John",
                LastName = "Doe",
                Description = "Information about user.",
                EmailAddress = "test@test.com",
                GravatarEmailAddress = "test@test.com",
            };

            Container.GetMock<ISecurityContext>()
                     .Setup(x => x.CurrentIdentity)
                     .Returns(new TestIdentity(_userId));

            Container.GetMock<IDocumentDatabase>()
                     .Setup(x => x.Query<User>())
                     .Returns(new EnumerableQuery<User>(new[] { _user }));
        }

        [Fact]
        public void Should_get_user_information_based_on_authentication()
        {
            var basicInformation = ClassUnderTest.Execute(new BasicInformationInputModel());

            basicInformation.Description.Should().Be.EqualTo(_user.Description);
            basicInformation.EmailAddress.Should().Be.EqualTo(_user.EmailAddress);
            basicInformation.FirstName.Should().Be.EqualTo(_user.FirstName);
            basicInformation.GravatarEmailAddress.Should().Be.EqualTo(_user.GravatarEmailAddress);
            basicInformation.LastName.Should().Be.EqualTo(_user.LastName);
            basicInformation.NickName.Should().Be.EqualTo(_user.NickName);
            basicInformation.FullName.Should().Be.EqualTo(_user.FullName());
        }

    }
}