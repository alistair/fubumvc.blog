using System.Linq;

namespace Blog.Articles.Domain
{
    public static class ArticleExtensions
    {
         public static IQueryable<Article> FilteryByPublished(this IQueryable<Article> query, bool? showDraft)
         {
             return showDraft.HasValue ? query.Where(x => x.IsPublished == !showDraft.Value) : query;
         }
    }
}