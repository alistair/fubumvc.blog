using System;
using System.Linq;
using Blog.Comments.Domain;
using Blog.Core.Domain;
using MongoAdapt;

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
            IDocumentCollection info;
            var spamCount = _database
                .Statistics<Comment>(out info)
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
                Total = info.Count,
                Spam = spamCount,
                History = history
            };
        }
    }
}