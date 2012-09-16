using Blog.Articles.Archive;
using Blog.Articles.Compose;
using Blog.Articles.Manage;
using Blog.Core.Constants;
using FubuMVC.Core;
using FubuMVC.Core.UI.Navigation;

namespace Blog.Articles
{
  public class ArticleRegistry : IFubuRegistryExtension
  {
    public void Configure(FubuRegistry registry)
    {
            registry.Navigation(x =>
            {
                x.ForMenu(StringConstants.BlogName);
                x.InsertAfter["Home"] = MenuNode.ForInput<ArchiveInputModel>("Archive");

                x.ForMenu(StringConstants.AdminMenu);
                x.Add += MenuNode.ForInput<ComposeInputModel>("Compose");
                x.Add += MenuNode.ForInput<ManageArticlesInputModel>("Manage Articles");
            });
    }
  }
}