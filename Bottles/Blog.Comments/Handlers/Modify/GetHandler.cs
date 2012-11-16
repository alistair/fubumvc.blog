using System.Linq;
using Blog.Comments.Domain;
using Blog.Core.Extensions;
using MongoDB.Driver;

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
            var comment = _database.Query<Comment>()
                .First(x => x.Id == inputModel.Id);

            return comment.DynamicMap<ModifyCommentViewModel>();
        }
    }
}