using System.Linq;
using Blog.Core.Database;
using Blog.Core.Domain;
using Blog.Core.Extensions;
using FubuMVC.Core.Security;

namespace Blog.Profile.BasicInformation
{
    public class GetHandler
    {
        private readonly ISecurityContext _securityContext;
        private readonly IDocumentDatabase _database;

        public GetHandler(ISecurityContext securityContext, IDocumentDatabase database)
        {
            _securityContext = securityContext;
            _database = database;
        }

        public BasicInformationViewModel Execute(BasicInformationInputModel inputModel)
        {
            var user = _database.Query<User>()
                .SingleOrDefault(x => x.Id == _securityContext.CurrentIdentity.Name) ??
                new User();

            return user.DynamicMap<BasicInformationViewModel>();
        }
    }
}