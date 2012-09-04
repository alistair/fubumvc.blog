using Blog.Behaviors;
using Blog.Core.Constants;
using Blog.Home;
using FubuMVC.Core;
using FubuMVC.Core.Registration.Conventions;
using FubuMVC.Core.Runtime;
using FubuMVC.Core.UI.Navigation;
using FubuMVC.Less;
using FubuMVC.Spark;

namespace Blog
{
    public class BlogRegistry : FubuRegistry
    {
        public BlogRegistry()
        {
            Import<SparkEngine>();
            Import<LessExtension>();
            Import<HandlerConvention>();
            Applies
                .ToThisAssembly()
                .ToAllPackageAssemblies();

            Assets.CombineAllUniqueAssetRequests();

            Routes.HomeIs<GetHandler>(x => x.Execute(null));

            Views.TryToAttachWithDefaultConventions();

            Navigation(x =>
            {
                x.ForMenu(StringConstants.BlogName);
                x.Add += MenuNode.ForInput<HomeInputModel>("Home");
            });

            Policies.WrapBehaviorChainsWith<RavenDbBehavior>();

            Services(registry =>
            {
                registry.SetServiceIfNone<IJsonWriter, NewtonSoftJsonWriter>();
            });
        }
    }
}