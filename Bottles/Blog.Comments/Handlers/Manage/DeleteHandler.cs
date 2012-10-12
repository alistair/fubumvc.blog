using System.Linq;
using Blog.Comments.Domain;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

namespace Blog.Comments.Manage
{
    public class DeleteHandler
    {
        private readonly MongoDatabase _database;

        public DeleteHandler(MongoDatabase database)
        {
            _database = database;
        }

        public DeleteCommentViewModel Execute(DeleteCommentInputModel inputModel)
        {
            var comments = _database.GetCollection<Comment>("Comments");
            var comment = comments.AsQueryable()
                .First(x => x.Id == inputModel.Id);

            var update = Update.Inc("CommentsCount", -1);
            _database.GetCollection("Articles")
                .FindAndModify(Query.EQ("_id", comment.ArticleUri), SortBy.Null, update, false);

            comments.Remove(Query.EQ("_id", inputModel.Id));
            return new DeleteCommentViewModel();
        }
    }
}