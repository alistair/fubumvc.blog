namespace Blog.Core.Domain
{
    public interface IPageable
    {
        int? Page { get; set; }
        int? Count { get; set; }
    }
}