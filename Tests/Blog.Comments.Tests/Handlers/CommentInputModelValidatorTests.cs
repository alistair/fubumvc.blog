using System.Linq;
using Blog.Core.Tests;
using SharpTestsEx;
using Xunit;

namespace Blog.Comments.Tests.Handlers
{
    public class CommentInputModelValidatorTests : TestContext<CommentInputModelValidator>
    {
        private CommentInputModel _model;

        protected override void Given()
        {
            _model = new CommentInputModel
            {
                Author = "test",
                Uri = "test",
                Id = "test",
                Comment = "test",
                Email = "test@test.com"

            };
        }

        [Fact]
        public void Validates_valid_comment()
        {
            var validationResults = ClassUnderTest.Validate(_model);
            validationResults.IsValid.Should().Be.True();
        }

        [Fact]
        public void Author_cannot_be_empty()
        {
            _model.Author = string.Empty;

            var validationResults = ClassUnderTest.Validate(_model);

            validationResults.IsValid.Should().Be.False();
            validationResults.Errors.Single(x => x.PropertyName == "Author")
                .Should().Not.Be.Null();
        }

        [Fact]
        public void Author_cannot_be_null()
        {
            _model.Author = null;

            var validationResults = ClassUnderTest.Validate(_model);

            validationResults.IsValid.Should().Be.False();
            validationResults.Errors.Single(x => x.PropertyName == "Author")
                .Should().Not.Be.Null();
        }

        [Fact]
        public void Comment_cannot_be_empty()
        {
            _model.Comment = string.Empty;

            var validationResults = ClassUnderTest.Validate(_model);

            validationResults.IsValid.Should().Be.False();
            validationResults.Errors.Single(x => x.PropertyName == "Comment")
                .Should().Not.Be.Null();
        }

        [Fact]
        public void Comment_cannot_be_null()
        {
            _model.Comment = null;

            var validationResults = ClassUnderTest.Validate(_model);

            validationResults.IsValid.Should().Be.False();
            validationResults.Errors.Single(x => x.PropertyName == "Comment")
                .Should().Not.Be.Null();
        }

        [Fact]
        public void Must_be_a_valid_email_when_provided()
        {
            _model.Email = "dsadsadsadasd";

            var validationResults = ClassUnderTest.Validate(_model);

            validationResults.IsValid.Should().Be.False();
            validationResults.Errors.Single(x => x.PropertyName == "Email")
                .Should().Not.Be.Null();
        }

    }
}