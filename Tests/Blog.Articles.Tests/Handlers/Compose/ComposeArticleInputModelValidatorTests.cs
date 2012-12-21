using System.Linq;
using Blog.Articles.Compose;
using Blog.Core.Tests;
using SharpTestsEx;
using Xunit;

namespace Blog.Articles.Tests.Handlers.Compose
{
    public class ComposeArticleInputModelValidatorTests : TestContext<ComposeArticleInputModelValidator>
    {
        private ComposeArticleInputModel _model;

        protected override void Given()
        {
            _model = new ComposeArticleInputModel
            {
                Title = "test",
                Body = "some body",
                CommentsCount = 1,
                Id = "some_article"
            };
        }

        [Fact]
        public void Valid_article_compoisition_scenario()
        {
            var validationResults = ClassUnderTest.Validate(_model);
            validationResults.IsValid.Should().Be.True();
        }

        [Fact]
        public void Title_cannot_be_empty()
        {
            _model.Title = string.Empty;

            var validationResults = ClassUnderTest.Validate(_model);

            validationResults.IsValid.Should().Be.False();
            validationResults.Errors.Single(x => x.PropertyName == "Title")
                .Should().Not.Be.Null();
        }

        [Fact]
        public void Title_cannot_be_null()
        {
            _model.Title = null;

            var validationResults = ClassUnderTest.Validate(_model);

            validationResults.IsValid.Should().Be.False();
            validationResults.Errors.Single(x => x.PropertyName == "Title")
                .Should().Not.Be.Null();
        }

        [Fact]
        public void Body_cannot_be_empty()
        {
            _model.Body = string.Empty;

            var validationResults = ClassUnderTest.Validate(_model);

            validationResults.IsValid.Should().Be.False();
            validationResults.Errors.Single(x => x.PropertyName == "Body")
                .Should().Not.Be.Null();
        }

        [Fact]
        public void Body_cannot_be_null()
        {
            _model.Body = null;

            var validationResults = ClassUnderTest.Validate(_model);

            validationResults.IsValid.Should().Be.False();
            validationResults.Errors.Single(x => x.PropertyName == "Body")
                .Should().Not.Be.Null();
        }


        [Fact]
        public void Id_cannot_be_empty()
        {
            _model.Id = string.Empty;

            var validationResults = ClassUnderTest.Validate(_model);

            validationResults.IsValid.Should().Be.False();
            validationResults.Errors.Single(x => x.PropertyName == "Id")
                .Should().Not.Be.Null();
        }

        [Fact]
        public void Id_cannot_be_null()
        {
            _model.Id = null;

            var validationResults = ClassUnderTest.Validate(_model);

            validationResults.IsValid.Should().Be.False();
            validationResults.Errors.Single(x => x.PropertyName == "Id")
                .Should().Not.Be.Null();
        }

        [Fact]
        public void Id_cannot_contain_special_characters_except_dashes()
        {
            _model.Id = "+=)(*&^%$#@!~`'\"[]{}|\\/?<>.,";

            var validationResults = ClassUnderTest.Validate(_model);

            validationResults.IsValid.Should().Be.False();
            validationResults.Errors.Single(x => x.PropertyName == "Id")
                .Should().Not.Be.Null();
        }
    }
}