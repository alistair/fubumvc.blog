using System.Linq;
using Blog.Core.Domain;
using Blog.Core.Extensions;
using FubuMVC.Core.Security;
using Raven.Client;

namespace Blog.Profile.BasicInformation
{
    public class GetHandler
    {
        private readonly ISecurityContext _securityContext;
        private readonly IDocumentSession _session;

        public GetHandler(ISecurityContext securityContext, IDocumentSession session)
        {
            _securityContext = securityContext;
            _session = session;
        }

        public BasicInformationViewModel Execute(BasicInformationInputModel inputModel)
        {
            var user = _session.Query<UserInformation>()
                .SingleOrDefault(x => x.ClaimedIdentifier == _securityContext.CurrentIdentity.Name) ??
                new UserInformation();

            return user.DynamicMap<BasicInformationViewModel>();
        }
    }
}