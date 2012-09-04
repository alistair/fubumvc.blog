using FubuMVC.Core.Runtime;
using FubuMVC.Core.Security;

namespace Blog.Authorization.Policies
{
    public class AuthorizationPolicy: IAuthorizationPolicy
    {
        private readonly ISecurityContext _securityContext;

        public AuthorizationPolicy(ISecurityContext securityContext)
        {
            _securityContext = securityContext;
        }

        public AuthorizationRight RightsFor(IFubuRequest request)
        {
            return _securityContext.IsAuthenticated()
                ? AuthorizationRight.Allow
                : AuthorizationRight.Deny;
        }
    }
}