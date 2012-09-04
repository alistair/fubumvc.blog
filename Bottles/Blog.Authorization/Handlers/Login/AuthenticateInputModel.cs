using DotNetOpenAuth.OpenId;

namespace Blog.Authorization.Login
{
    public class AuthenticateInputModel
    {
        public string OpenidIdentifier { get; set; }

        public Identifier GetIdentifier()
        {
            Identifier id;
            return Identifier.TryParse(OpenidIdentifier, out id) ? id : null;
        }
    }
}