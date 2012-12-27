using Blog.Core.Extensions;
using Blog.Core.Validation;
using FluentValidation;
using StructureMap.Configuration.DSL;

namespace Blog
{
    public class BlogStructureMapRegistry : Registry
    {
        public BlogStructureMapRegistry()
        {
            Scan(s => s.ForBottles(s.Assembly)
                .ConnectImplementationsToTypesClosing(typeof(IValidator<>)));

            For(typeof (IValidator<>)).Use(typeof (EmptyValidator<>));
        }
    }
}