using System;

namespace Blog.Comments
{
  public class CommentViewModel
  {
    public string ArticleUri { get; set; }
    public string Author { get; set; }
    public DateTimeOffset PublishedDate { get; set; }
    public string Body { get; set; }

    public string PublishedDateString
    {
      get { return PublishedDate.ToString("MMMM dd, yyyy (hh:mm)"); }
    }

  }
}