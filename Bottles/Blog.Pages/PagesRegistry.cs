using Blog.Core.Constants;
using Blog.Pages.Manage;
using FubuMVC.Core;
using FubuMVC.Navigation;

namespace Blog.Pages
{
    public class PagesRegistry : IFubuRegistryExtension
    {
        public void Configure(FubuRegistry registry)
        {
            registry.Policies.Add<PagesNavigationRegistry>();
        }
    }

    public class PagesNavigationRegistry : NavigationRegistry
    {
        public PagesNavigationRegistry()
        {
            ForMenu(StringConstants.ProfileMenu);
            InsertAfter["Dashboard"] = MenuNode.ForInput<ManagePagesInputModel>("Pages");
        }
    }
}