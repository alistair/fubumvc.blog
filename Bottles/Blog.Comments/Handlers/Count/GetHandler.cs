using System.Linq;
using Blog.Comments.Domain;
using Blog.Core.Database;

namespace Blog.Comments.Count
{
    public class GetHandler
    {
        private readonly IDocumentDatabase _database;

        public GetHandler(IDocumentDatabase database)
        {
            _database = database;
        }

        public dynamic Execute(CommentsCountInputModel inputModel)
        {
            long totalCount;
            var spamCount = _database
                .WithCount<Comment>(out totalCount)
                .Where(x => x.IsPotentialSpam)
                .LongCount();

            return new CommentsCountViewModel
            {
                Total = totalCount,
                Spam = spamCount
            };
        }
    }
}