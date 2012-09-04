namespace Blog.Articles.Compose
{
    public class ComposeArticleResourceModel
    {
        public ComposeArticleResourceModel(string url)
        {
            Url = string.Format("/{0}", url);
        }
        public string Url { get; set; }
    }
}