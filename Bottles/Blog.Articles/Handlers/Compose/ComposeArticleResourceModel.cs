namespace Blog.Articles.Compose
{
    public class ComposeArticleResourceModel
    {

        private string _url;
        public string Url
        {
            get { return _url; }
            set { _url = string.Format("/{0}", value) ; }
        }

        public string ManageUrl { get; set; }
    }
}