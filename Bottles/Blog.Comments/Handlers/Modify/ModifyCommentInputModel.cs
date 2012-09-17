using FubuMVC.Core;

namespace Blog.Comments.Modify
{
    public class ModifyCommentInputModel
    {
        [QueryString]
        public string Id { get; set; }
    }
}