using Blog.Core.Extensions;
using Blog.Profile.Domain;
using FubuMVC.Core.Runtime;
using FubuMVC.Core.Security;
using MongoDB.Driver;

namespace Blog.Profile.BasicInformation
{
    public class PostHandler
    {
        private readonly ISecurityContext _securityContext;
        private readonly MongoDatabase _database;
        private readonly ISessionState _state;

        public PostHandler(ISecurityContext securityContext, MongoDatabase database, ISessionState state)
        {
            _securityContext = securityContext;
            _database = database;
            _state = state;
        }

        public BasicInformationViewModel Execute(EditBasicInformationInputModel inputModel)
        {
            var user = inputModel.DynamicMap<User>();

            user.Id = _securityContext.CurrentIdentity.Name;

            _database.GetCollection("Users")
                .Save(user);
            //_state.Set();

            return user.DynamicMap<BasicInformationViewModel>();
        }
    }
}