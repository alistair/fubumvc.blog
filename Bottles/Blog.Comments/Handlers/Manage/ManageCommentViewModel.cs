using System;

namespace Blog.Comments.Manage
{
    public class ManageCommentViewModel
    {
        public Guid Id { get; set; }
        public string ArticleUri { get; set; }
        public string Author { get; set; }
        public DateTimeOffset PublishedDate { get; set; }
        public string Body { get; set; }

        public string PublishedDateString
        {
            get { return PublishedDate.ToString("M/dd/yyyy (hh:mm)"); }
        }
    }
}