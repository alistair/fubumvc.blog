using System;
using Blog.Comments.Domain;
using Blog.Core.Database;

namespace Blog.Comments.Modify
{
    public class PostHandler
    {
        private readonly IDocumentDatabase _database;

        public PostHandler(IDocumentDatabase database)
        {
            _database = database;
        }

        public void Execute(UpdateCommentInputModel inputModel)
        {
            _database.Save(new Comment
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