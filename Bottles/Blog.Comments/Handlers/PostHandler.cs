using System;
using Blog.Comments.Domain;
using Raven.Client;

namespace Blog.Comments
{
    public class PostHandler
    {
        private readonly IDocumentSession _session;

        public PostHandler(IDocumentSession session)
        {
            _session = session;
        }

        public void Execute(CommentInputModel inputModel)
        {
            _session.Store(new Comment
            {
                ArticleUri = inputModel.Uri,
                Body = inputModel.Comment,
                Author = inputModel.Author,
                PublishedDate = new DateTimeOffset(DateTime.Now)
            });
        }
    }
}