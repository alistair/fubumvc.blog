using Blog.Core.Permissions;

namespace Blog.Profile.BasicInformation
{
    public class EditBasicInformationInputModel : IRequireBasicAuthorization
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string EmailAddress { get; set; }
        public string GravatarEmailAddress { get; set; }
        public string Description { get; set; }
    }
}