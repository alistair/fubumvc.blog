using System.Linq;
using Blog.Authorization.Domain;
using Blog.Core.Domain;
using DotNetOpenAuth.OpenId.RelyingParty;
using FubuMVC.Core.Runtime;
using FubuMVC.Core.Security;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Blog.Authorization.Login
{
    public class GetHandler
    {
        private readonly IAuthenticationContext _authenticationContext;
        private readonly MongoDatabase _database;
        private readonly ISessionState _state;

        public GetHandler(IAuthenticationContext authenticationContext,
            MongoDatabase database,
            ISessionState state)
        {
            _authenticationContext = authenticationContext;
            _database = database;
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
                //TODO: Get user out of session state.
                //var user = _database.GetCollection("Users")
                //    .AsQueryable<User>()
                //    .SingleOrDefault(x => x.Id == response.ClaimedIdentifier);

                //_state.Set(user ?? new User
                //    {
                //        FirstName = "Unknown"
                //    });
            }

            return viewModel;
        }
    }
}