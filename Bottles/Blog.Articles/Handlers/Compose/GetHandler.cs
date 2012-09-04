namespace Blog.Articles.Compose
{
    public class GetHandler
    {
         public ComposeViewModel Execute(ComposeInputModel inputModel)
         {
             return new ComposeViewModel();
         }
    }
}