using Blog.Authorization.Conventions;
using Blog.Authorization.AuthorizationFailure;
using FubuMVC.Core;
using FubuMVC.Core.Security;

namespace Blog.Authorization
{
    public class AuthorizationRegistry : IFubuRegistryExtension
    {
        public void Configure(FubuRegistry registry)
        {
            registry.ApplyConvention<AuthorizationConvention>();

            registry.Navigation<AuthorizationNavigationRegistry>();

            registry.Services(x =>
            {
                x.ReplaceService<IAuthorizationFailureHandler,AuthorizationFailureHandler>();
            });
        }
    }
}