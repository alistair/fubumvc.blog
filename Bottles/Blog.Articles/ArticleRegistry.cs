using Blog.Articles.Archive;
using Blog.Articles.Compose;
using Blog.Articles.Manage;
using Blog.Articles.Summaries;
using Blog.Core.Constants;
using FubuMVC.Core;
using FubuMVC.Navigation;

namespace Blog.Articles
{
    public class ArticleRegistry : IFubuRegistryExtension
    {
        public void Configure(FubuRegistry registry)
        {

            registry.Routes.HomeIs<Summaries.GetHandler>(x => x.Execute(null));
            registry.Policies.Add<ArticleNavigationRegistry>();

        }
    }

    public class ArticleNavigationRegistry : NavigationRegistry
    {
        public ArticleNavigationRegistry()
        {
            ForMenu(StringConstants.BlogName);
            Add += MenuNode.ForInput<ArticleSummariesInputModel>("Home");
            InsertAfter["Home"] = MenuNode.ForInput<ArchiveInputModel>("Archive");

            ForMenu(StringConstants.AdminMenu);
            Add += MenuNode.ForInput<ComposeInputModel>("Compose");
            Add += MenuNode.ForInput<ManageArticlesInputModel>("Articles");
        }
    }
}