using Blog.Core.Domain;

namespace Blog.Articles.Manage
{
    public class ManageArticlesInputModel : IPageable
    {
        private int? _page;
        private int? _count;

        public int? Page
        {
            get { return _page.HasValue ? _page : 1; }
            set { _page = value; }
        }

        public int? Count
        {
            get { return _count.HasValue ? _count : 25; }
            set { _count = value; }
        }
    }
}