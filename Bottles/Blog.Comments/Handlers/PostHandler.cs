using System;
using Blog.Comments.Domain;
using Blog.Core.Database;

namespace Blog.Comments
{
    public class PostHandler
    {
        private readonly IDocumentDatabase _database;

        public PostHandler(IDocumentDatabase database)
        {
            _database = database;
        }

        public void Execute(CommentInputModel inputModel)
        {

            _database.Increment("Articles", inputModel.Uri, "CommentsCount", 1);

            _database.Save(new Comment
                {
                    ArticleUri = inputModel.Uri,
                    Body = inputModel.Comment,
                    Author = inputModel.Author,
                    PublishedDate = new DateTimeOffset(DateTime.Now)
                });

        }
    }
}