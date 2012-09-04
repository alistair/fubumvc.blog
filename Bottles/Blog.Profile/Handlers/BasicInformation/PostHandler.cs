using Blog.Core.Domain;
using Blog.Core.Extensions;
using FubuMVC.Core.Runtime;
using FubuMVC.Core.Security;
using Raven.Client;

namespace Blog.Profile.BasicInformation
{
    public class PostHandler
    {
        private readonly ISecurityContext _securityContext;
        private readonly IDocumentSession _session;
        private readonly ISessionState _state;

        public PostHandler(ISecurityContext securityContext, IDocumentSession session, ISessionState state)
        {
            _securityContext = securityContext;
            _session = session;
            _state = state;
        }

        public BasicInformationViewModel Execute(EditBasicInformationInputModel inputModel)
        {
            var identity = _state.Get<UserInformation>();
            var userInformation = inputModel.DynamicMap<UserInformation>();
            userInformation.Id = identity.Id;

            userInformation.ClaimedIdentifier = _securityContext.CurrentIdentity.Name;

            _session.Store(userInformation);
            _state.Set(userInformation);

            return userInformation.DynamicMap<BasicInformationViewModel>();
        }
    }
}