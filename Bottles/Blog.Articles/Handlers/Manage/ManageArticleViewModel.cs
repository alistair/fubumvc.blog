using System;

namespace Blog.Articles.Manage
{
    public class ManageArticleViewModel
    {
        public string Id { get; set; }
        public DateTime PublishedDate { get; set; }
        public string PublishedDateString { get { return PublishedDate.ToShortDateString(); } }
        public string Author { get; set; }
        public string Title { get; set; }
    }
}