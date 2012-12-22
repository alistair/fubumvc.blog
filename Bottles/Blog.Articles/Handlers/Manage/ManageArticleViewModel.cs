using System;

namespace Blog.Articles.Manage
{
    public class ManageArticleViewModel
    {
        public string Id { get; set; }
        public DateTime PublishedDate { get; set; }
        public bool IsPublished { get; set; }
        public string PublishedDateString { get { return PublishedDate.ToShortDateString(); } }
        public string Title { get; set; }
        public int CommentsCount { get; set; }
        public string Author { get; set; }
    }
}