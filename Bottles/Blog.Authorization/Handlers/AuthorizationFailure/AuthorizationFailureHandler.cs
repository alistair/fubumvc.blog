using FubuMVC.Core.Runtime;
using FubuMVC.Core.Security;
using FubuMVC.Core.Urls;

namespace Blog.Authorization.AuthorizationFailure
{
    public class AuthorizationFailureHandler : IAuthorizationFailureHandler
    {
        private readonly IOutputWriter _outputWriter;
        private readonly IUrlRegistry _urlRegistry;

        public AuthorizationFailureHandler(IOutputWriter outputWriter, IUrlRegistry urlRegistry)
        {
            _outputWriter = outputWriter;
            _urlRegistry = urlRegistry;
        }

        public void Handle()
        {
            _outputWriter.RedirectToUrl(_urlRegistry.UrlFor<AuthorizationFailureInputModel>());
        }
    }
}