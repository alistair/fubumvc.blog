using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using FubuCore.Reflection;
using FubuMVC.Core.Registration;

namespace Blog.Conventions
{
    public class JsonConvention : IConfigurationAction
    {
        public void Configure(BehaviorGraph graph)
        {
            graph.Actions()
                .Where(x => x.Method.ReturnParameter.HasAttribute<DynamicAttribute>())
                .Each(x => x.ParentChain().Output.UsesFormatter<NewtonSoftJsonWriter>());
        }
    }
}