using FubuMVC.Core;

namespace Blog.Articles.Compose
{
    public class ComposeInputModel
    {
        [QueryString]
        public string Id { get; set; }
    }
}