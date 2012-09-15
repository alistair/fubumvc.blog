using Blog.Core.Constants;
using Blog.Profile.BasicInformation;
using FubuMVC.Core;
using FubuMVC.Core.UI.Navigation;

namespace Blog.Profile
{
    public class ProfileRegistry : IFubuRegistryExtension
    {
        public void Configure(FubuRegistry registry)
        {
            registry.Navigation(x =>
            {
                x.ForMenu(StringConstants.ProfileMenu);
                x.Add += MenuNode.ForInput<ProfileInputModel>("Profile");
                x.Add += MenuNode.ForInput<BasicInformationInputModel>("Edit Information");
            });
        }
    }
}