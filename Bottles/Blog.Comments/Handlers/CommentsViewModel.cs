using System.Collections.Generic;

namespace Blog.Comments
{
    public class CommentsViewModel
    {
        public string Uri { get; set; }
        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}