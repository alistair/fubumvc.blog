using System.Collections.Generic;

namespace Blog.Articles.RecentDrafts
{
    public class RecentDraftViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
    }

    public class RecentDraftsViewModel
    {
        public IEnumerable<RecentDraftViewModel> RecentDrafts { get; set; }

        public RecentDraftsViewModel(IEnumerable<RecentDraftViewModel> recentDrafts)
        {
            RecentDrafts = recentDrafts;
        }
    }
}