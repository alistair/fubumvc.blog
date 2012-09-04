using System;

namespace Blog.Comments.Domain
{
    public class Comment
    {
        public string ArticleUri { get; set; }
        public string Author { get; set; }
        public DateTimeOffset PublishedDate { get; set; }
        public string Body { get; set; }
    }
}