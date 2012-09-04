using System;
using System.Linq;
using Blog.Core.Constants;

namespace Blog.Articles.Summaries
{
    public class ArticleSummaryViewModel
    {
        public string Id { get; set; }
        public string Author { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public string Summary
        {
            get
            {
                var text = Body.Split(new[] { StringConstants.ArticleMore }, StringSplitOptions.None);
                return text.First();
            }
        }

        public string PublishedDateString
        {
            get { return PublishedDate.ToString("MMMM dd, yyyy"); }
        }

    }
}