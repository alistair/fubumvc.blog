using HtmlTags;

namespace Blog.Core.HtmlTags
{
  public class TextAreaTag : HtmlTag
  {
    public TextAreaTag()
      : base("textarea")
    {
    }

    public TextAreaTag(string name, string value)
      : this()
    {
      this.Attr("name", (object) name);
      this.Attr("value", (object) value);
    }
  }
}