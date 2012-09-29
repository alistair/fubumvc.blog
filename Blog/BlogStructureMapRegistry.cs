using System.Collections.Generic;
using System.Linq;
using Blog.Core.Validation;
using Bottles;
using FluentValidation;
using StructureMap.Configuration.DSL;

namespace Blog
{
    public class BlogStructureMapRegistry : Registry
    {
        public BlogStructureMapRegistry()
        {
            Scan(scanner =>
            {
                PackageRegistry.PackageAssemblies
                    .Where(x => x.FullName.StartsWith("Blog"))
                    .Each(scanner.Assembly);

                scanner.ConnectImplementationsToTypesClosing(typeof(IValidator<>));
            });
            For(typeof (IValidator<>)).Use(typeof (EmptyValidator<>));
        }
    }
}