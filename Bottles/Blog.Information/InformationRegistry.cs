using Blog.Core.Constants;
using FubuMVC.Core;
using FubuMVC.Core.UI.Navigation;

namespace Blog.Information
{
    public class InformationRegistry : IFubuRegistryExtension
    {
        public void Configure(FubuRegistry registry)
        {
            registry.Navigation(x =>
            {
                x.ForMenu(StringConstants.BlogName);
                x.InsertAfter["Archive"] = MenuNode.ForInput<AboutInputModel>("About");
            });
        }
    }
}