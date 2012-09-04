using System.Collections.Generic;
using System.Web;
using Bottles;
using FubuMVC.Core;
using FubuMVC.StructureMap;
using StructureMap;

namespace Blog
{

    public class MvcApplication : HttpApplication
    {

        protected void Application_Start()
        {
            FubuApplication
                .For<BlogRegistry>()
                .StructureMap(() => new Container(x =>
                    x.Scan(i =>
                    {
                        i.TheCallingAssembly();
                        PackageRegistry.PackageAssemblies.Each(i.Assembly);
                        i.LookForRegistries();
                    })))
                .Bootstrap();

            PackageRegistry.AssertNoFailures();
        }

        private static void SetupContainer(ConfigurationExpression x)
        {
        }
    }
}