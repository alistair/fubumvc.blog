using System;
using Blog.Comments.Domain;
using Raven.Client;

namespace Blog.Comments.Modify
{
    public class PostHandler
    {
        private readonly IDocumentSession _session;

        public PostHandler(IDocumentSession session)
        {
            _session = session;
        }

        public void Execute(UpdateCommentInputModel inputModel)
        {
            _session.Store(new Comment
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