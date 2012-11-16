﻿using System.Linq;
using Blog.Comments.Domain;
using Blog.Core.Extensions;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Blog.Comments.Manage
{
    public class GetHandler
    {
        private readonly MongoDatabase _database;

        public GetHandler(MongoDatabase database)
        {
            _database = database;
        }

        public ManageCommentsViewModel Execute(ManageCommentsInputModel inputModel)
        {
            long totalCount;

            var comments = _database.GetCollection("Comments")
                .WithCount(out totalCount)
                .AsQueryable<Comment>()
                .OrderByDescending(x => x.PublishedDate)
                .Page(inputModel)
                .ToList();

            return new ManageCommentsViewModel
            {
                Comments = comments.Select(x => x.DynamicMap<ManageCommentViewModel>()),
                TotalPages = totalCount.TotalPages(inputModel.Count)
            };
        }
    }
}