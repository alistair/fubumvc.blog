using Blog.Comments.Manage;
using Blog.Core.Constants;
using FubuMVC.Core;
using FubuMVC.Core.UI.Navigation;

namespace Blog.Comments
{
    public class CommentsRegistry : IFubuRegistryExtension
    {
        public void Configure(FubuRegistry registry)
        {
            registry.Navigation(x =>
            {
                x.ForMenu(StringConstants.AdminMenu);
                x.Add += MenuNode.ForInput<ManageCommentsInputModel>("Manage Comments");
            });
        }
    }
}