using System.Linq;
using Blog.Comments.Domain;
using Blog.Core.Database;
using Blog.Core.Extensions;

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
            var comment = _database.Query<Comment>()
                .Single(x => x.Id == inputModel.Id);

            return comment.DynamicMap<ModifyCommentViewModel>();
        }
    }
}