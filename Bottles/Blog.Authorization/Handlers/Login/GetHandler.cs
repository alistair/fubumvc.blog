using DotNetOpenAuth.OpenId.RelyingParty;
using FubuMVC.Core.Security;

namespace Blog.Authorization.Login
{
    public class GetHandler
    {
        private readonly IAuthenticationContext _authenticationContext;

        public GetHandler(IAuthenticationContext authenticationContext)
        {
            _authenticationContext = authenticationContext;
        }

        public LoginViewModel Execute(LoginInputModel inputModel)
        {
            var party = new OpenIdRelyingParty();
            var response = party.GetResponse();
            var viewModel = new LoginViewModel();

            if (response != null && response.Status == AuthenticationStatus.Authenticated)
            {
                _authenticationContext.ThisUserHasBeenAuthenticated(response.ClaimedIdentifier, false);
                viewModel.LoginSuccessful = true;
            }

            return viewModel;
        }
    }
}