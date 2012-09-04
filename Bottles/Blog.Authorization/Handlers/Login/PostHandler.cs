using DotNetOpenAuth.OpenId.RelyingParty;

namespace Blog.Authorization.Login
{
    public class PostHandler
    {
        public void Execute(AuthenticateInputModel inputModel)
        {
            var party = new OpenIdRelyingParty();

            var request = party.CreateRequest(inputModel.GetIdentifier());

            request.RedirectToProvider();
        }
    }
}
