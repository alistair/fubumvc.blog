using Blog.Core.Database;
using Blog.Core.Domain;
using Blog.Core.Tests;
using Blog.Profile.BasicInformation;
using FubuMVC.Core.Security;
using Moq;
using SharpTestsEx;
using Xunit;

namespace Blog.Profile.Tests.Handlers.BasicInformation
{
    public class PostBasicInformationHandlerTest : TestContext<PostHandler>
    {
        private EditBasicInformationInputModel _inputModel;

        protected override void Given()
        {
            Container.GetMock<ISecurityContext>()
                     .Setup(x => x.CurrentIdentity)
                     .Returns(new TestIdentity("test"));

            _inputModel = new EditBasicInformationInputModel
            {
                NickName = "JDoe",
                FirstName = "John",
                LastName = "Doe",
                Description = "Information about user.",
                EmailAddress = "test@test.com",
                GravatarEmailAddress = "test@test.com",
            };
        }

        [Fact]
        public void Saves_basic_information_returns_updated_information()
        {
            var basicInformation = ClassUnderTest.Execute(_inputModel);

            Container.GetMock<IDocumentDatabase>()
                .Verify(x => x.Save(It.IsAny<User>()));

            basicInformation.Description.Should().Be.EqualTo(_inputModel.Description);
            basicInformation.EmailAddress.Should().Be.EqualTo(_inputModel.EmailAddress);
            basicInformation.FirstName.Should().Be.EqualTo(_inputModel.FirstName);
            basicInformation.GravatarEmailAddress.Should().Be.EqualTo(_inputModel.GravatarEmailAddress);
            basicInformation.LastName.Should().Be.EqualTo(_inputModel.LastName);
            basicInformation.NickName.Should().Be.EqualTo(_inputModel.NickName);
            basicInformation.FullName.Should().Be.EqualTo(string.Format("{0} {1}", _inputModel.FirstName, _inputModel.LastName));
        }
    }
}