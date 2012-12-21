using System.Security.Principal;

namespace Blog.Articles.Tests.Handlers
{
    public class TestIdentity : IIdentity
    {
        public TestIdentity(string name, bool isAuthenticated = false)
        {
            Name = name;
            IsAuthenticated = isAuthenticated;
        }
        public string Name { get; private set; }
        public string AuthenticationType { get; private set; }
        public bool IsAuthenticated { get; private set; }
    }
}