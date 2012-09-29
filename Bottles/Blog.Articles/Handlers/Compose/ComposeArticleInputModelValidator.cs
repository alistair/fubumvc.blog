using FluentValidation;

namespace Blog.Articles.Compose
{
    public class ComposeArticleInputModelValidator : AbstractValidator<ComposeArticleInputModel>
    {
        public ComposeArticleInputModelValidator()
        {
            RuleFor(x => x.Title)
                .Must(x => !string.IsNullOrEmpty(x))
                .WithMessage("Please provide a {PropertyName}.");

            RuleFor(x => x.Body)
                .Must(x => !string.IsNullOrEmpty(x))
                .WithMessage("You must provide some text for your Article.");

            RuleFor(x => x.Id)
                .Must(x => !string.IsNullOrEmpty(x))
                .WithMessage("You must provide a Url for your Article.");

            RuleFor(x => x.Id)
                .Matches(@"^([-\w.]+)$")
                .WithMessage("You must provide a valid Url for your Article. Valid characters include alphabetical characters and hyphens.");
        }
    }
}