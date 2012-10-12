using System.Linq;
using Blog.Comments.Domain;
using Blog.Core.Extensions;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Blog.Comments.Modify
{
    public class GetHandler
    {
        private readonly MongoDatabase _database;

        public GetHandler(MongoDatabase database)
        {
            _database = database;
        }

        public ModifyCommentViewModel Execute(ModifyCommentInputModel inputModel)
        {
            var comment = _database.GetCollection("Comments")
                .AsQueryable<Comment>()
                .First(x => x.Id == inputModel.Id);

            return comment.DynamicMap<ModifyCommentViewModel>();
        }
    }
}