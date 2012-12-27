using Blog.Core.Constants;
using FubuMVC.Core;
using FubuMVC.Navigation;

namespace Blog.Information
{
    public class InformationRegistry : IFubuRegistryExtension
    {
        public void Configure(FubuRegistry registry)
        {
            registry.Policies.Add<InformationNavigationRegistry>();
        }
    }

    public class InformationNavigationRegistry : NavigationRegistry
    {
        public InformationNavigationRegistry()
        {
            ForMenu(StringConstants.BlogName);
            InsertAfter["Archive"] = MenuNode.ForInput<AboutInputModel>("About");
        }
    }
}