using System.Linq;
using Blog.Core.Domain;
using DotNetOpenAuth.OpenId.RelyingParty;
using FubuMVC.Core.Runtime;
using FubuMVC.Core.Security;
using Raven.Client;

namespace Blog.Authorization.Login
{
    public class GetHandler
    {
        private readonly IAuthenticationContext _authenticationContext;
        private readonly IDocumentSession _session;
        private readonly ISessionState _state;

        public GetHandler(IAuthenticationContext authenticationContext,
            IDocumentSession session,
            ISessionState state)
        {
            _authenticationContext = authenticationContext;
            _session = session;
            _state = state;
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

                _state.Set(_session.Query<UserInformation>()
                    .SingleOrDefault(x => x.ClaimedIdentifier == response.ClaimedIdentifier)
                    ?? new UserInformation
                    {
                        FirstName = "Unknown"
                    });
            }

            return viewModel;
        }
    }
}