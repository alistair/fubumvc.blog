using System.Collections.Generic;

namespace Blog.Articles.Archive
{
    public class ArchiveViewModel
    {
        public IDictionary<int, List<ArchiveItemViewModel>> Items { get; set; }
    }
}