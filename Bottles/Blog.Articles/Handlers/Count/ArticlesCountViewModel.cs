using System.Collections.Generic;

namespace Blog.Articles.Count
{
    public class ArticlesCountViewModel
    {
        public long Total { get; set; }
        public long Draft { get; set; }
        public IEnumerable<DateCountViewModal> History { get; set; }
    }

    public class DateCountViewModal
    {
        public string PostedDate { get; set; }
        public int PostedArticleCount { get; set; }
        public int DraftArticleCount { get; set; }
    }
}