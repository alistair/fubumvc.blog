using System;
using Blog.Comments.Domain;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace Blog.Comments
{
    public class PostHandler
    {
        private readonly MongoDatabase _database;

        public PostHandler(MongoDatabase database)
        {
            _database = database;
        }

        public void Execute(CommentInputModel inputModel)
        {
            var update = Update.Inc("CommentsCount", 1);
            _database.GetCollection("Articles")
                .FindAndModify(Query.EQ("_id", inputModel.Uri), SortBy.Null, update, false);

            _database.GetCollection("Comments")
                .Insert(new Comment
                {
                    ArticleUri = inputModel.Uri,
                    Body = inputModel.Comment,
                    Author = inputModel.Author,
                    PublishedDate = new DateTimeOffset(DateTime.Now)
                });
        }
    }
}