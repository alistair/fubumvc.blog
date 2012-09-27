namespace Blog.Articles.Compose
{
    public class ComposeViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public bool IsPublished { get; set; }
        public int CommentsCount { get; set; }
    }
}