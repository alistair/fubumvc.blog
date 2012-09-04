using Blog.Core.Extensions;
using Blog.Profile.Domain;
using FubuMVC.Core.Security;
using Raven.Client;

namespace Blog.Profile.BasicInformation
{
    public class PostHandler
    {
        private readonly ISecurityContext _securityContext;
        private readonly IDocumentSession _session;

        public PostHandler(ISecurityContext securityContext, IDocumentSession session)
        {
            _securityContext = securityContext;
            _session = session;
        }

        public BasicInformationViewModel Execute(EditBasicInformationInputModel inputModel)
        {
            var userInformation = inputModel.DynamicMap<UserInformation>();
            userInformation.ClaimedIdentifier = _securityContext.CurrentIdentity.Name;

            _session.Store(userInformation);

            return userInformation.DynamicMap<BasicInformationViewModel>();
        }
    }
}