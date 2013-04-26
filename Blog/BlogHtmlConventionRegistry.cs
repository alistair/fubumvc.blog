using FubuMVC.Core.UI;
using FubuMVC.Core.UI.Elements;

namespace Blog
{
    public class BlogHtmlConventionRegistry : HtmlConventionRegistry
    {
        public BlogHtmlConventionRegistry()
        {
            Editors.Modifier<ButtonModifier>();
        }
    }

    public class ButtonModifier : IElementModifier
    {
        public bool Matches(ElementRequest token)
        {
            return true;
        }

        public void Modify(ElementRequest request)
        {
            var tag = request.CurrentTag;
            if((tag.HasAttr("type") && tag.Attr("type") == "button") || tag.TagName() == "button")
                tag.AddClass("TEST");
        }
    }
}