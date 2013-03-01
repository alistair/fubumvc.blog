using System;

namespace Blog.Articles.Domain
{
    public class Article
    {
        public Article()
        {
        }

        public Article(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
        public string AuthorId { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int CommentsCount { get; set; }
        public bool IsPublished { get; set; }
    }
}