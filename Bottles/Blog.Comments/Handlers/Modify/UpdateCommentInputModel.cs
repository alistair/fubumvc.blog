using System;

namespace Blog.Comments.Modify
{
    public class UpdateCommentInputModel
    {
        public Guid Id { get; set; }
        public string Uri { get; set; }
        public string Author { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
    }
}