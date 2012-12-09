using System.Linq;

namespace Blog.Comments.Domain
{
    public static class CommentExtensions
    {
         public static IQueryable<Comment> FilteryBySpam(this IQueryable<Comment> query, bool? isSpam)
         {
             return isSpam.HasValue ? query.Where(x => x.IsPotentialSpam == isSpam.Value) : query;
         }
    }
}