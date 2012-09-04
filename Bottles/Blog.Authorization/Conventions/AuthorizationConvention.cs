using System.Collections.Generic;
using System.Linq;
using Blog.Authorization.Policies;
using Blog.Core.Permissions;
using FubuMVC.Core.Registration;

namespace Blog.Authorization.Conventions
{
    public class AuthorizationConvention : IConfigurationAction
    {
        public void Configure(BehaviorGraph graph)
        {
            graph.Behaviors
                .Where(x =>
                {
                    var inputType = x.InputType();
                    return inputType != null && typeof (IRequireBasicAuthorization).IsAssignableFrom(inputType);
                })
                .Each(x => x.Authorization.AddPolicy(typeof(AuthorizationPolicy)));
        }
    }
}