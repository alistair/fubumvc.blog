namespace Blog.Articles.Compose
{
    public class ComposeArticleInputModel
    {
        private string _id;
        public string Id
        {
            get { return _id.Replace("/",string.Empty); }
            set { _id = value; }
        }

        public string Title { get; set; }
        public string Body { get; set; }
        public string IsDraft { get; set; }
    }
}