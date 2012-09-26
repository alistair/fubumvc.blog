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
            var article = _session.Load<dynamic>(inputModel.Uri);
            article.CommentsCount++;

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