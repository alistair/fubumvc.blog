﻿using System.Linq;
using Blog.Core.Domain;
using Blog.Core.Extensions;
using FubuMVC.Core.Security;
using MongoDB.Driver;

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
            var user = _database.Query<User>()
                .SingleOrDefault(x => x.Id == _securityContext.CurrentIdentity.Name) ??
                new User();

            return user.DynamicMap<BasicInformationViewModel>();
        }
    }
}