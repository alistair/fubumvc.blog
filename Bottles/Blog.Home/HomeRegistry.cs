using Blog.Core.Constants;
using Blog.Home;
using FubuMVC.Core;
using FubuMVC.Core.UI.Navigation;

namespace Blog.Information
{
    public class HomeRegistry : IFubuRegistryExtension
    {
        public void Configure(FubuRegistry registry)
        {

            registry.Navigation(x =>
            {
                x.ForMenu(StringConstants.BlogName);
                x.Add += MenuNode.ForInput<HomeInputModel>("Home");
            });

            registry.Routes.HomeIs<GetHandler>(x => x.Execute(null));
        }
    }
}