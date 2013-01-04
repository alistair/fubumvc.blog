using Blog.Core.Database;

namespace Blog.Pages.Manage
{
    public class GetHandler
    {
        private readonly IDocumentDatabase _documentDatabase;

        public GetHandler(IDocumentDatabase documentDatabase)
        {
            _documentDatabase = documentDatabase;
        }

        public ManagePagesViewModel Execute(ManagePagesInputModel inputModel)
        {
            return new ManagePagesViewModel();
        }
    }
}