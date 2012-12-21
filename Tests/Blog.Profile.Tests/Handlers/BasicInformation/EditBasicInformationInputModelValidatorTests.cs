using System.Linq;
using Blog.Core.Tests;
using Blog.Profile.BasicInformation;
using SharpTestsEx;
using Xunit;

namespace Blog.Profile.Tests.Handlers.BasicInformation
{
    public class EditBasicInformationInputModelValidatorTests : TestContext<EditBasicInformationInputModelValidator>
    {
        private EditBasicInformationInputModel _inputModel;

        protected override void Given()
        {
            _inputModel = new EditBasicInformationInputModel
            {
                FirstName = "John",
                LastName = "Doe",
                Description = "Some description",
                EmailAddress = "test@test.com",
                GravatarEmailAddress = "test@test.com",
                NickName = "JDoe"
            };
        }

        [Fact]
        public void Should_allow_valid_input_model()
        {
            var validationResults = ClassUnderTest.Validate(_inputModel);
            validationResults.IsValid.Should().Be.True();
        }

        [Fact]
        public void Should_invalidate_empty_firstName()
        {
            _inputModel.FirstName = string.Empty;

            var validationResults = ClassUnderTest.Validate(_inputModel);

            validationResults.IsValid.Should().Be.False();
            validationResults.Errors.Single(x => x.PropertyName == "FirstName")
                .Should().Not.Be.Null();
        }


        [Fact]
        public void Should_invalidate_null_firstName()
        {
            _inputModel.FirstName = null;

            var validationResults = ClassUnderTest.Validate(_inputModel);

            validationResults.IsValid.Should().Be.False();
            validationResults.Errors.Single(x => x.PropertyName == "FirstName")
                .Should().Not.Be.Null();
        }

        [Fact]
        public void Should_invalidate_empty_lastName()
        {
            _inputModel.LastName = string.Empty;

            var validationResults = ClassUnderTest.Validate(_inputModel);

            validationResults.IsValid.Should().Be.False();
            validationResults.Errors.Single(x => x.PropertyName == "LastName")
                .Should().Not.Be.Null();
        }

        [Fact]
        public void Should_invalidate_null_lastName()
        {
            _inputModel.LastName = null;

            var validationResults = ClassUnderTest.Validate(_inputModel);

            validationResults.IsValid.Should().Be.False();
            validationResults.Errors.Single(x => x.PropertyName == "LastName")
                .Should().Not.Be.Null();
        }

        [Fact]
        public void Email_address_should_be_optional()
        {
            _inputModel.EmailAddress = null;

            var validationResults = ClassUnderTest.Validate(_inputModel);

            validationResults.IsValid.Should().Be.True();
        }

        [Fact]
        public void Email_address_should_be_valid_format_when_provided()
        {
            _inputModel.EmailAddress = "asdasdasd";

            var validationResults = ClassUnderTest.Validate(_inputModel);

            validationResults.IsValid.Should().Be.False();
            validationResults.Errors.Single(x => x.PropertyName == "EmailAddress")
                .Should().Not.Be.Null();
        }

        [Fact]
        public void GravatarEmail_address_should_be_optional()
        {
            _inputModel.GravatarEmailAddress = null;

            var validationResults = ClassUnderTest.Validate(_inputModel);

            validationResults.IsValid.Should().Be.True();
        }

        [Fact]
        public void GravatarEmail_address_should_be_valid_format_when_provided()
        {
            _inputModel.GravatarEmailAddress = "asdasdasd";

            var validationResults = ClassUnderTest.Validate(_inputModel);

            validationResults.IsValid.Should().Be.False();
            validationResults.Errors.Single(x => x.PropertyName == "GravatarEmailAddress")
                .Should().Not.Be.Null();
        }
    }
}