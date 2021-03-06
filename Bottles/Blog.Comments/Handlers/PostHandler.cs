﻿using System;
using Blog.Comments.Domain;
using Blog.Core.Domain;
using MongoAdapt;

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

            _database.Increment<Article>(inputModel.Uri, x => x.CommentsCount);

            _database.Save(new Comment(Guid.NewGuid())
            {
                ArticleUri = inputModel.Uri,
                Body = inputModel.Comment,
                Author = inputModel.Author,
                PublishedDate = DateTime.Now
            });
        }
    }
}