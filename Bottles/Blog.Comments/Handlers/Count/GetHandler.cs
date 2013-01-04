using System;
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

        public CommentsCountViewModel Execute(CommentsCountInputModel inputModel)
        {
            long totalCount;
            var spamCount = _database
                .WithCount<Comment>(out totalCount)
                .Where(x => x.IsPotentialSpam)
                .LongCount();


            var history = _database.Query<Comment>()
                .Where(x => x.PublishedDate > DateTime.Now.Subtract(new TimeSpan(30, 0, 0, 0)))
                .ToList()
                .GroupBy(x => x.PublishedDate.Date)
                .Select(x => new DateCountViewModal
                {
                    PostedDate = x.Key.ToString("MM/dd"),
                    SpamCount = x.Sum(a => a.IsPotentialSpam ? 1 : 0),
                    PostedCommentsCount = x.Sum(a => a.IsApproved ? 1 : 0),
                });

            return new CommentsCountViewModel
            {
                Total = totalCount,
                Spam = spamCount,
                History = history
            };
        }
    }
}