using System;
using FubuMVC.Core;

namespace Blog.Comments.Modify
{
    public class ModifyCommentInputModel
    {
        [QueryString]
        public Guid Id { get; set; }
    }
}