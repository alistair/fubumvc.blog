namespace Blog.Comments.Modify
{
    public class ModifyCommentViewModel
    {
        public string Id { get; set; }
        public string Author { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
        public string ArticleUri { get; set; }
        //TODO: this needs clean up:
        public string Comment { get { return Body; } }
        public string Uri { get { return ArticleUri; } }
    }
}