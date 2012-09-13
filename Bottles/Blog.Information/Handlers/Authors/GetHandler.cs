using System.Linq;
using Blog.Core.Domain;
using Raven.Client;
using Blog.Core.Extensions;

namespace Blog.Information.Authors
{
    public class GetHandler
    {
        private readonly IDocumentSession _session;

        public GetHandler(IDocumentSession session)
        {
            _session = session;
        }

        public AuthorsViewModel Execute(AuthorsInputModel inputModel)
        {
            var authors = _session.Query<UserInformation>()
                .ToList();

            return new AuthorsViewModel
            {
                Authors = authors.Select(x => x.DynamicMap<AuthorViewModel>())
            };
        }
    }
}