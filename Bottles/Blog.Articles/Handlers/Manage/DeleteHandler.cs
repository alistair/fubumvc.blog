using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace Blog.Articles.Manage
{
    public class DeleteHandler
    {
        private readonly MongoDatabase _database;

        public DeleteHandler(MongoDatabase database)
        {
            _database = database;
        }

        public DeleteArticleViewModel Execute(DeleteArticleInputModel inputModel)
        {
            _database.GetCollection("Articles")
                .Remove(Query.EQ("_id", inputModel.Id));

            _database.GetCollection("Comments")
                .Remove(Query.EQ("ArticleUri", inputModel.Id));

            return new DeleteArticleViewModel();
        }
    }
}