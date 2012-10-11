using Blog.Core.Constants;
using FubuMVC.Core;
using FubuMVC.Core.UI.Navigation;

namespace Blog.Settings
{
    public class SetttingsRegistry : IFubuRegistryExtension
    {
        public void Configure(FubuRegistry registry)
        {
            registry.Navigation(x =>
            {
                x.ForMenu(StringConstants.ProfileMenu);
                x.Add += MenuNode.ForInput<SettingsInputModel>("Settings");
            });
        }
    }
}