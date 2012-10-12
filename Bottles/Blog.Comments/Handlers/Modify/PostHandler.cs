using System;
using Blog.Comments.Domain;
using MongoDB.Driver;

namespace Blog.Comments.Modify
{
    public class PostHandler
    {
        private readonly MongoDatabase _database;

        public PostHandler(MongoDatabase database)
        {
            _database = database;
        }

        public void Execute(UpdateCommentInputModel inputModel)
        {
            _database.GetCollection("Comments")
                .Save(new Comment
                {
                    Id = inputModel.Id,
                    ArticleUri = inputModel.Uri,
                    Body = inputModel.Comment,
                    Author = inputModel.Author,
                    PublishedDate = new DateTimeOffset(DateTime.Now)
                });
        }
    }
}