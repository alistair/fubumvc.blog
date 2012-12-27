using FluentValidation;

namespace Blog.Profile.BasicInformation
{
    public class EditBasicInformationInputModelValidator : AbstractValidator<EditBasicInformationInputModel>
    {
        public EditBasicInformationInputModelValidator()
        {
            RuleFor(x => x.FirstName)
                .Must(x => !string.IsNullOrEmpty(x))
                .WithMessage("Please provide a First Name");

            RuleFor(x => x.LastName)
                .Must(x => !string.IsNullOrEmpty(x))
                .WithMessage("Please provide a Last Name");

            RuleFor(x => x.EmailAddress)
                .EmailAddress()
                .When(x => !string.IsNullOrEmpty(x.EmailAddress))
                .WithMessage("Please provide a valid Email Address");


            RuleFor(x => x.GravatarEmailAddress)
                .EmailAddress()
                .When(x => !string.IsNullOrEmpty(x.GravatarEmailAddress))
                .WithMessage("Please provide a valid Gravatar Email Address");
        }
    }
}