namespace Blog.Comments.Count
{
  public class CommentsCountInputModel
  {
      private string _articleUri;
      public string ArticleUri
      {
          get { return string.Format("article/{0}",_articleUri); }
          set { _articleUri = value; }
      }
  }
}