using System;
using Raven.Client;
using Raven.Client.Document;
using StructureMap.Configuration.DSL;

namespace Blog
{
    public class RavenDBRegistry : Registry
    {
        public RavenDBRegistry()
        {
            var documentStore = new DocumentStore
            {
                ConnectionStringName = "MyBlog"
            }.Initialize();

            documentStore.Conventions.FindTypeTagName = t => t.Name.Replace("ViewModel", string.Empty);

            Func<IDocumentSession> getSession = documentStore.OpenSession;
            For<IDocumentSession>().Use(getSession);
            For<IDocumentStore>().Singleton().Use(documentStore);
        }
    }
}