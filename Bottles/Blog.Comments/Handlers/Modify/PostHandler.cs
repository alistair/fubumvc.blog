﻿using System;
using Blog.Comments.Domain;
using Blog.Core.Domain;
using MongoAdapt;

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
            _database.Save(new Comment(inputModel.Id)
            {
                ArticleUri = inputModel.Uri,
                Body = inputModel.Comment,
                Author = inputModel.Author,
                PublishedDate = DateTime.Now
            });
        }
    }
}