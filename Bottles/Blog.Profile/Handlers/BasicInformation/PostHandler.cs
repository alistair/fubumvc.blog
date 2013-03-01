using Blog.Core.Domain;
using Blog.Core.Extensions;
using FubuMVC.Core.Security;
using MongoAdapt;

namespace Blog.Profile.BasicInformation
{
    public class PostHandler
    {
        private readonly ISecurityContext _securityContext;
        private readonly IDocumentDatabase _database;

        public PostHandler(ISecurityContext securityContext, IDocumentDatabase database)
        {
            _securityContext = securityContext;
            _database = database;
        }

        public BasicInformationViewModel Execute(EditBasicInformationInputModel inputModel)
        {
            var user = inputModel.DynamicMap<User>();

            user.Id = _securityContext.CurrentIdentity.Name;

            _database.Save(user);

            return user.DynamicMap<BasicInformationViewModel>();
        }
    }
}