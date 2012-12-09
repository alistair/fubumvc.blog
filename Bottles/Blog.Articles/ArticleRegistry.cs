using Blog.Articles.Archive;
using Blog.Articles.Compose;
using Blog.Articles.Manage;
using Blog.Articles.Summaries;
using Blog.Core.Constants;
using FubuMVC.Core;
using FubuMVC.Core.UI.Navigation;

namespace Blog.Articles
{
    public class ArticleRegistry : IFubuRegistryExtension
    {
        public void Configure(FubuRegistry registry)
        {

            registry.Routes.HomeIs<Summaries.GetHandler>(x => x.Execute(null));

            registry.Navigation(x =>
            {
                x.ForMenu(StringConstants.BlogName);
                x.Add += MenuNode.ForInput<ArticleSummariesInputModel>("Home");
                x.InsertAfter["Home"] = MenuNode.ForInput<ArchiveInputModel>("Archive");

                x.ForMenu(StringConstants.AdminMenu);
                x.Add += MenuNode.ForInput<ComposeInputModel>("Compose");
                x.Add += MenuNode.ForInput<ManageArticlesInputModel>("Articles");
            });
        }
    }
}