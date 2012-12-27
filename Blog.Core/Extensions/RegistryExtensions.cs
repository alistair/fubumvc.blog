using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Bottles;
using FubuMVC.Core.Registration;

namespace Blog.Core.Extensions
{
    public static class RegistryExtensions
    {
        public static void ForBottles(this Action<Assembly> action)
        {
            PackageRegistry.PackageAssemblies
               .Where(a => a.FullName.StartsWith("Blog"))
               .Each(action);
        }

        public static ActionSource ForBottles(this ActionSource source, Action<Assembly> action)
        {
            action.ForBottles();

            return source;
        }

        public static StructureMap.Graph.IAssemblyScanner ForBottles(this StructureMap.Graph.IAssemblyScanner scanner, Action<Assembly> action)
        {
            action.ForBottles();

            return scanner;
        }
    }
}