﻿using System.Linq;
using Blog.Articles.Domain;
using Blog.Core.Extensions;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Blog.Articles.Compose
{
    public class GetHandler
    {
        private readonly MongoDatabase _database;

        public GetHandler(MongoDatabase database)
        {
            _database = database;
        }

        public ComposeViewModel Execute(ComposeInputModel inputModel)
        {
            if(string.IsNullOrEmpty(inputModel.Id)) return new ComposeViewModel();

            var article = _database.GetCollection("Articles")
                .AsQueryable<Article>()
                .First(x => x.Id == inputModel.Id);

            return article.DynamicMap<ComposeViewModel>();
        }
    }
}