namespace Blog.Information.Authors
{
  public class GetHandler
  {
    public AuthorsViewModel Execute(AuthorsInputModel inputModel)
    {
      return new AuthorsViewModel();
    }
  }
}