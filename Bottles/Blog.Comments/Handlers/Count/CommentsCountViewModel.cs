using System.Collections.Generic;

namespace Blog.Comments.Count
{
    public class CommentsCountViewModel
    {
        public long Total { get; set; }
        public long Spam { get; set; }
        public IEnumerable<DateCountViewModal> History { get; set; }
    }

    public class DateCountViewModal
    {
        public string PostedDate { get; set; }
        public int SpamCount { get; set; }
        public int PostedCommentsCount { get; set; }
    }
}