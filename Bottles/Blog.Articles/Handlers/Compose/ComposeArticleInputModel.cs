namespace Blog.Articles.Compose
{
    public class ComposeArticleInputModel
    {
        private string _id;
        public string Id
        {
            get { return !string.IsNullOrEmpty(_id) ? _id.Replace("/",string.Empty) : string.Empty; }
            set { _id = value; }
        }

        public string Title { get; set; }
        public string Body { get; set; }
        public bool IsDraft { get; set; }
        public int CommentsCount { get; set; }
    }
}