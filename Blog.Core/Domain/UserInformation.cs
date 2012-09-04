namespace Blog.Core.Domain
{
    public class UserInformation
    {
        public string Id { get; set; }
        public string ClaimedIdentifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }
}