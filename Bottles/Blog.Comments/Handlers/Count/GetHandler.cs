using Blog.Comments.Domain;
using MongoDB.Driver;

namespace Blog.Comments.Count
{
    public class GetHandler
    {
        private readonly MongoDatabase _database;

        public GetHandler(MongoDatabase database)
        {
            _database = database;
        }

        public dynamic Execute(CommentsCountInputModel inputModel)
        {
            return _database.GetCollection<Comment>("Comments")
                .Count();
        }
    }
}