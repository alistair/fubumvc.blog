using System;

namespace Blog.Core.Domain
{
    public class Comment
    {
        public Comment(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
        public string ArticleUri { get; set; }
        public string Author { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Body { get; set; }
        public bool IsApproved { get; set; }
        public bool IsPotentialSpam { get; set; }
    }
}