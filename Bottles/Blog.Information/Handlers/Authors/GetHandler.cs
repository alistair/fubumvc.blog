using System.Linq;
using Blog.Core.Domain;
using MongoDB.Driver;
using Blog.Core.Extensions;

namespace Blog.Information.Authors
{
    public class GetHandler
    {
        private readonly MongoDatabase _database;

        public GetHandler(MongoDatabase database)
        {
            _database = database;
        }

        public AuthorsViewModel Execute(AuthorsInputModel inputModel)
        {
            var authors = _database
                .GetCollection("Users")
                .FindAll()
                .ToList();

            return new AuthorsViewModel
            {
                Authors = authors.Select(x => x.DynamicMap<AuthorViewModel>())
            };
        }
    }
}