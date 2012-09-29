using System;
using System.Collections.Generic;
using System.Linq;
using Blog.Behaviors;
using FubuMVC.Core.Registration;
using FubuMVC.Core.Registration.Nodes;

namespace Blog.Policies
{
    public class ValidationPolicy : IConfigurationAction
    {
        public void Configure(BehaviorGraph graph)
        {
            graph.Actions()
                .Where(x => !x.HandlerType.Name.StartsWith("Get", StringComparison.InvariantCultureIgnoreCase) && x.HasInput)
                .Each(x => x.AddBefore(new ValidationNode(x.InputType())));
        }

        private class ValidationNode : Wrapper
        {
            public ValidationNode(Type inputModel)
                : base(typeof(ValidationBehavior<>).MakeGenericType(inputModel))
            {
            }
        }
    }
}