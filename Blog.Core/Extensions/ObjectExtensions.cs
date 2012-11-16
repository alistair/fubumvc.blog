using System;

namespace Blog.Core.Extensions
{
    public static class ObjectExtensions
    {
        public static int TotalPages(this long totalItems, int? itemsPerPage)
        {
            if(itemsPerPage >=  totalItems || !itemsPerPage.HasValue) return 1;

            var pages = Math.Ceiling(d: totalItems/itemsPerPage.Value);

            return (int) pages;
        }
    }
}