using Blog.Authorization.Login;
using Blog.Authorization.Logout;
using Blog.Core.Constants;
using FubuMVC.Core.Runtime.Conditionals;
using FubuMVC.Core.Security;
using FubuMVC.Core.UI.Navigation;

namespace Blog.Authorization
{
    public class AuthorizationNavigationRegistry : NavigationRegistry
    {
        public AuthorizationNavigationRegistry()
        {
            var loginMenu = MenuNode.ForInput<LoginInputModel>("Login");

            loginMenu.HideIf<AuthorizedConditional>();

            var logoutMenu = MenuNode.ForInput<LogoutInputModel>("Logout");

            logoutMenu.HideIf<NotAuthorizedConditional>();

            ForMenu(StringConstants.BlogName);

            InsertAfter["About"] = loginMenu;
            InsertAfter["About"] = logoutMenu;
        }
    }

    public class NotAuthorizedConditional : IConditional
    {
        private readonly ISecurityContext _securityContext;

        public NotAuthorizedConditional(ISecurityContext securityContext)
        {
            _securityContext = securityContext;
        }

        public bool ShouldExecute()
        {
            return !_securityContext.IsAuthenticated();
        }
    }
    public class AuthorizedConditional : IConditional
    {
        private readonly ISecurityContext _securityContext;

        public AuthorizedConditional(ISecurityContext securityContext)
        {
            _securityContext = securityContext;
        }

        public bool ShouldExecute()
        {
            return _securityContext.IsAuthenticated();
        }
    }
}