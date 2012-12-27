using Blog.Comments.Manage;
using Blog.Core.Constants;
using FubuMVC.Core;
using FubuMVC.Navigation;

namespace Blog.Comments
{
    public class CommentsRegistry : IFubuRegistryExtension
    {
        public void Configure(FubuRegistry registry)
        {
            registry.Policies.Add<CommentsNavigationRegistry>();
        }
    }

    public class CommentsNavigationRegistry : NavigationRegistry
    {
        public CommentsNavigationRegistry()
        {
            ForMenu(StringConstants.AdminMenu);
            Add += MenuNode.ForInput<ManageCommentsInputModel>("Comments");
        }
    }
}