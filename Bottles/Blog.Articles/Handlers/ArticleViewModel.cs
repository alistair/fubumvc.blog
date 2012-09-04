using System;
using Blog.Core.Constants;

namespace Blog.Articles
{
  public class ArticleViewModel
  {
    public string Id { get; set; }
    public string Author { get; set; }
    public DateTime PublishedDate { get; set; }
    public string Title { get; set; }
    private string _body;

    public string Body
    {
      get { return _body.Replace(StringConstants.ArticleMore, string.Empty); }
      set { _body = value; }
    }

    public string PublishedDateString
    {
      get { return PublishedDate.ToString("MMMM dd, yyyy"); }
    }

  }
}