using Blog.Core.Domain;
using Blog.Core.Extensions;
using FubuMVC.Core.Runtime;
using FubuMVC.Core.Security;
using MongoDB.Driver;

namespace Blog.Profile.BasicInformation
{
    public class PostHandler
    {
        private readonly ISecurityContext _securityContext;
        private readonly MongoDatabase _database;

        public PostHandler(ISecurityContext securityContext, MongoDatabase database)
        {
            _securityContext = securityContext;
            _database = database;
        }

        public BasicInformationViewModel Execute(EditBasicInformationInputModel inputModel)
        {
            var user = inputModel.DynamicMap<User>();

            user.Id = _securityContext.CurrentIdentity.Name;

            _database.GetCollection("Users")
                .Save(user);

            return user.DynamicMap<BasicInformationViewModel>();
        }
    }
}