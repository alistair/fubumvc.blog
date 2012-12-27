using Blog.Core.Constants;
using FubuMVC.Core;

namespace Blog.Settings
{
    public class SetttingsRegistry : IFubuRegistryExtension
    {
        public void Configure(FubuRegistry registry)
        {
            registry.Policies.Add(x =>
            {
                //TODO: move to navigation registry:
                //x.ForMenu(StringConstants.ProfileMenu);
                //x.Add += MenuNode.ForInput<SettingsInputModel>("Settings");
            });
        }
    }
}