using FluentValidation;

namespace Blog.Comments
{
    public class CommentInputModelValidator : AbstractValidator<CommentInputModel>
    {
        public CommentInputModelValidator()
        {
            RuleFor(x => x.Author)
                .Must(x => !string.IsNullOrEmpty(x))
                .WithMessage("Please provide a Author");

            RuleFor(x => x.Comment)
                .Must(x => !string.IsNullOrEmpty(x))
                .WithMessage("Please provide a Comment");

            RuleFor(x => x.Email)
                .Must(x => !string.IsNullOrEmpty(x))
                .WithMessage("Please provide an Email Address");

            RuleFor(x => x.Email)
                .EmailAddress()
                .When(x => !string.IsNullOrEmpty(x.Email))
                .WithMessage("Please provide a valid Email Address");
        }
    }
}