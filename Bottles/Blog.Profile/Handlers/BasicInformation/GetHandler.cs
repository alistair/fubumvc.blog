using System.Linq;
using Blog.Core.Extensions;
using Blog.Profile.Domain;
using FubuMVC.Core.Security;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Blog.Profile.BasicInformation
{
    public class GetHandler
    {
        private readonly ISecurityContext _securityContext;
        private readonly MongoDatabase _database;

        public GetHandler(ISecurityContext securityContext, MongoDatabase database)
        {
            _securityContext = securityContext;
            _database = database;
        }

        public BasicInformationViewModel Execute(BasicInformationInputModel inputModel)
        {
            var user = _database.GetCollection("Users")
                .AsQueryable<User>()
                .SingleOrDefault(x => x.Id == _securityContext.CurrentIdentity.Name) ??
                new User();

            return user.DynamicMap<BasicInformationViewModel>();
        }
    }
}