using System.Linq;
using Blog.Articles.Compose;
using Blog.Core.Tests;
using SharpTestsEx;
using Xunit;

namespace Blog.Articles.Tests.Handlers.Compose
{
    public class ComposeArticleInputModelValidatorTests : TestContext<ComposeArticleInputModelValidator>
    {
        [Fact]
        public void Valid_article_compoisition_scenario()
        {
            var model = new ComposeArticleInputModel
            {
                Title = "test",
                Body = "some body",
                CommentsCount = 1,
                Id = "some_article"
            };

            var validationResults = ClassUnderTest.Validate(model);
            validationResults.IsValid.Should().Be.True();
        }

        [Fact]
        public void Title_cannot_be_empty()
        {
            var model = new ComposeArticleInputModel
            {
                Title = "",
                Body = "test",
                CommentsCount = 1,
                Id = "test"
            };

            var validationResults = ClassUnderTest.Validate(model);

            validationResults.IsValid.Should().Be.False();
            validationResults.Errors.Single(x => x.PropertyName == "Title")
                .Should().Not.Be.Null();
        }

        [Fact]
        public void Title_cannot_be_null()
        {
            var model = new ComposeArticleInputModel
            {
                Title = null,
                Body = "test",
                CommentsCount = 1,
                Id = "test"
            };

            var validationResults = ClassUnderTest.Validate(model);

            validationResults.IsValid.Should().Be.False();
            validationResults.Errors.Single(x => x.PropertyName == "Title")
                .Should().Not.Be.Null();
        }

        [Fact]
        public void Body_cannot_be_empty()
        {
            var model = new ComposeArticleInputModel
            {
                Title = "test",
                Body = "",
                CommentsCount = 1,
                Id = "test"
            };

            var validationResults = ClassUnderTest.Validate(model);

            validationResults.IsValid.Should().Be.False();
            validationResults.Errors.Single(x => x.PropertyName == "Body")
                .Should().Not.Be.Null();
        }

        [Fact]
        public void Body_cannot_be_null()
        {
            var model = new ComposeArticleInputModel
            {
                Title = "test",
                Body = null,
                CommentsCount = 1,
                Id = "test"
            };

            var validationResults = ClassUnderTest.Validate(model);

            validationResults.IsValid.Should().Be.False();
            validationResults.Errors.Single(x => x.PropertyName == "Body")
                .Should().Not.Be.Null();
        }


        [Fact]
        public void Id_cannot_be_empty()
        {
            var model = new ComposeArticleInputModel
            {
                Title = "test",
                Body = "some body",
                CommentsCount = 1,
                Id = ""
            };

            var validationResults = ClassUnderTest.Validate(model);

            validationResults.IsValid.Should().Be.False();
            validationResults.Errors.Single(x => x.PropertyName == "Id")
                .Should().Not.Be.Null();
        }

        [Fact]
        public void Id_cannot_be_null()
        {
            var model = new ComposeArticleInputModel
            {
                Title = "test",
                Body = "some body",
                CommentsCount = 1,
                Id = null
            };

            var validationResults = ClassUnderTest.Validate(model);

            validationResults.IsValid.Should().Be.False();
            validationResults.Errors.Single(x => x.PropertyName == "Id")
                .Should().Not.Be.Null();
        }

        [Fact]
        public void Id_cannot_contain_special_characters_except_dashes()
        {
            var model = new ComposeArticleInputModel
            {
                Title = "test",
                Body = "some body",
                CommentsCount = 1,
                Id = "+=)(*&^%$#@!~`'\"[]{}|\\/?<>.,"
            };

            var validationResults = ClassUnderTest.Validate(model);

            validationResults.IsValid.Should().Be.False();
            validationResults.Errors.Single(x => x.PropertyName == "Id")
                .Should().Not.Be.Null();
        }
    }
}