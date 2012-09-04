using Blog.Behaviors;
using FubuMVC.Core;
using FubuMVC.Core.Registration.Conventions;
using FubuMVC.Core.Runtime;
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

            Views.TryToAttachWithDefaultConventions();

            Policies.WrapBehaviorChainsWith<RavenDbBehavior>();

            Services(registry =>
            {
                registry.SetServiceIfNone<IJsonWriter, NewtonSoftJsonWriter>();
            });
        }
    }
}