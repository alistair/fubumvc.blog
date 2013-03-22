using Blog.Comments.Domain;
using Blog.Core.Domain;
using Blog.Core.Extensions;
using MongoAdapt;

namespace Blog.Comments.Modify
{
    public class GetHandler
    {
        private readonly IDocumentDatabase _database;

        public GetHandler(IDocumentDatabase database)
        {
            _database = database;
        }

        public ModifyCommentViewModel Execute(ModifyCommentInputModel inputModel)
        {
            var comment = _database.Load<Comment>(inputModel.Id);

            return comment.DynamicMap<ModifyCommentViewModel>();
        }
    }
}