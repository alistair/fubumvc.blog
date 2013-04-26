using Blog.Core.Extensions;
using Blog.Policies;
using FubuMVC.Core;
using FubuMVC.Core.Assets;
using FubuMVC.Core.Runtime;
using FubuMVC.HandlerConventions;

namespace Blog
{
    public class BlogRegistry : FubuRegistry
    {
        public BlogRegistry()
        {
            Import<HandlerConvention>();
            Import<BlogHtmlConventionRegistry>();

            Actions.FindBy(s => s.ForBottles(a => s.Applies.ToAssembly(a))
                .IncludeMethods(m => m.Name == "Execute"));

            #if !DEBUG
                this.Assets().CombineAllUniqueAssetRequests();
            #endif

            Policies.Add<ValidationPolicy>();

            Services(registry => registry.AddService<IJsonWriter, NewtonSoftJsonWriter>());
        }
    }
}