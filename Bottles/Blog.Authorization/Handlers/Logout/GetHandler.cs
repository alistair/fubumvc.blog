using FubuMVC.Core.Security;

namespace Blog.Authorization.Logout
{
    public class GetHandler
    {
        private readonly IAuthenticationContext _authenticationContext;

        public GetHandler(IAuthenticationContext authenticationContext)
        {
            _authenticationContext = authenticationContext;
        }

        public LogoutViewModel Execute(LogoutInputModel inputModel)
        {
            _authenticationContext.SignOut();

            return new LogoutViewModel();
        }
    }
}