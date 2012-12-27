using Blog.Core.Constants;
using Blog.Profile.BasicInformation;
using FubuMVC.Core;
using FubuMVC.Navigation;

namespace Blog.Profile
{
    public class ProfileRegistry : IFubuRegistryExtension
    {
        public void Configure(FubuRegistry registry)
        {
            registry.Policies.Add<ProfileNavigationRegistry>();
        }
    }
    public class ProfileNavigationRegistry : NavigationRegistry
    {
        public ProfileNavigationRegistry()
        {
            ForMenu(StringConstants.ProfileMenu);
            Add += MenuNode.ForInput<DashboardInputModel>("Dashboard");
            Add += MenuNode.ForInput<BasicInformationInputModel>("Profile");
        }
    }
}