using System.Collections.Generic;

namespace Blog.Comments.Manage
{
    public class ManageCommentsViewModel
    {
        public IEnumerable<ManageCommentViewModel> Comments { get; set; }
        public int TotalPages { get; set; }
        public bool? ShowSpam { get; set; }
    }
}