﻿using System.Collections.Generic;
using System.Linq;
using Blog.Behaviors;
using Bottles;
using FubuMVC.Core;
using FubuMVC.Core.Registration.Conventions;
using FubuMVC.Core.Runtime;

namespace Blog
{
    public class BlogRegistry : FubuRegistry
    {
        public BlogRegistry()
        {
            Import<HandlerConvention>();

            Applies.ToThisAssembly();
            PackageRegistry.PackageAssemblies
                 .Where(x => x.FullName.StartsWith("Blog"))
                 .Each(x => Applies.ToAssembly(x));

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