using System.Collections.Generic;

namespace Blog.Articles.Manage
{
    public class ManageArticlesViewModel
    {
        public IEnumerable<ManageArticleViewModel> Articles { get; set; }
        public int TotalPages { get; set; }
        public bool? ShowDraft { get; set; }
    }
}