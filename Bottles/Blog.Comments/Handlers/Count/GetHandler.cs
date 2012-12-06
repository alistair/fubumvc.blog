using Blog.Comments.Domain;
using Blog.Core.Database;

namespace Blog.Comments.Count
{
    public class GetHandler
    {
        private readonly IDocumentDatabase _database;

        public GetHandler(IDocumentDatabase database)
        {
            _database = database;
        }

        public dynamic Execute(CommentsCountInputModel inputModel)
        {
            return _database.Count<Comment>();
        }
    }
}