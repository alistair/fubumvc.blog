using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Blog.Core.Constants;
using Blog.Core.Domain;
using Blog.Core.HtmlTags;
using FubuCore;
using FubuCore.Reflection;
using FubuMVC.Core.Runtime;
using FubuMVC.Core.UI;
using FubuMVC.Core.UI.Configuration;
using FubuMVC.Core.UI.Navigation;
using FubuMVC.Core.View;
using HtmlTags;
using HtmlTags.Extended.Attributes;

namespace Blog.Core.Extensions
{
    public static class PageExtensions
    {
        public static HtmlTag Menu(this IFubuPage page, string menuName = null)
        {
            var navigationService = page.Get<INavigationService>();
            var state = page.Get<ISessionState>();
            var identity = state.Get<UserInformation>();
            var items = navigationService.MenuFor(new NavigationKey(menuName ?? StringConstants.BlogName));
            var menu = new HtmlTag("ul");

            items.Each(x =>
            {
                var link = new LinkTag(x.Key, x.Url);
                var li = new HtmlTag("li");

                if (x.Key.Equals("Logout") && x.MenuItemState == MenuItemState.Available && identity != null)
                {
                    var aTag = new LinkTag(string.Format("Welcome, {0}", identity.FirstName), "/profile");
                    aTag.AddClass("user");
                    menu.Append(aTag);
                }

                if (x.MenuItemState == MenuItemState.Active)
                    li.AddClass("current");

                if (x.MenuItemState == MenuItemState.Active || x.MenuItemState == MenuItemState.Available)
                    menu.Append(li.Append(link));

            });

            return menu;
        }

        public static HtmlTag Submit(this IFubuPage page)
        {
            var submitTag = new HtmlTag("input");
            submitTag.Attr("type", "submit");
            submitTag.Attr("value", "Submit");

            return submitTag;
        }

        public static TextAreaTag TextAreaFor<T>(this IFubuPage<T> page, Expression<Func<T, object>> expression) where T : class
        {
            var name = page.Get<IElementNamingConvention>().GetName(typeof(T), expression.ToAccessor());

            var text = page.Model.ValueOrDefault(expression).As<string>();

            var textarea = new TextAreaTag(name, string.Empty);

            textarea.Text(text);

            return textarea;
        }

        public static HtmlTag WithCustomLabel(this HtmlTag tag, string text)
        {
            var label = new HtmlTag("label");
            label.Attr("for", tag.Attr("name"));
            label.Text(text);

            return label.After(tag);
        }

        public static HiddenTag HiddenInputFor<T>(this IFubuPage<T> page, Expression<Func<T, object>> expression) where T : class
        {
            var name = page.ElementNameFor(expression);
            var value = page.Model.ValueOrDefault(expression);
            var hiddenTag = new HiddenTag().Name(name);
            hiddenTag.Value(value);

            return hiddenTag;
        }
    }
}