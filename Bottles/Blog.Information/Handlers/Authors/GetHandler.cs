using System.Linq;
using Blog.Core.Domain;
using Blog.Core.Extensions;
using MongoAdapt;

namespace Blog.Information.Authors
{
    public class GetHandler
    {
        private readonly IDocumentDatabase _database;

        public GetHandler(IDocumentDatabase database)
        {
            _database = database;
        }

        public AuthorsViewModel Execute(AuthorsInputModel inputModel)
        {
            var authors = _database.Query<User>().ToList();

            return new AuthorsViewModel
            {
                Authors = authors.Select(x => x.DynamicMap<AuthorViewModel>())
            };
        }
    }
}