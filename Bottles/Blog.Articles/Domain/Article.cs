using System;

namespace Blog.Articles.Domain
{
    public class Article
    {
        public string Id { get; set; }
        public string Author { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}