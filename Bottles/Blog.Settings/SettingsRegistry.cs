using Blog.Core.Constants;
using FubuMVC.Core;
using FubuMVC.Navigation;

namespace Blog.Settings
{
    public class SetttingsRegistry : IFubuRegistryExtension
    {
        public void Configure(FubuRegistry registry)
        {
            registry.Policies.Add<SetttingsNavigationRegistry>();
        }
    }

    public class SetttingsNavigationRegistry : NavigationRegistry
    {
        public SetttingsNavigationRegistry()
        {
            ForMenu(StringConstants.ProfileMenu);
            Add += MenuNode.ForInput<SettingsInputModel>("Settings");
        }
    }
}