using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Blog.Core.Constants;
using Blog.Core.Domain;
using Blog.Core.HtmlTags;
using FubuCore;
using FubuCore.Reflection;
using FubuMVC.Core;
using FubuMVC.Core.Security;
using FubuMVC.Core.UI;
using FubuMVC.Core.UI.Elements;
using FubuMVC.Core.View;
using FubuMVC.Navigation;
using HtmlTags;
using HtmlTags.Extended.Attributes;
using MongoAdapt;

namespace Blog.Core.Extensions
{
    public static class FubuPageExtensions
    {
        public static HtmlTag Menu(this IFubuPage page, string menuName = null)
        {
            var navigationService = page.Get<INavigationService>();
            var items = navigationService.MenuFor(new NavigationKey(menuName ?? StringConstants.BlogName));
            var menu = new HtmlTag("ul");
            var user = page.GetUser();

            items.Each(x =>
            {
                var link = new LinkTag(x.Key, x.Url);
                var li = new HtmlTag("li");
                li.AddClass(
                    string.Format("menu-item-{0}", x.Key.Replace(" ", string.Empty).ToLowerInvariant()));

                if (x.Key.Equals("Logout") && x.MenuItemState == MenuItemState.Available && user != null)
                {
                    var aTag = new LinkTag(string.Format("Welcome, {0}", user.FirstName), "/profile");
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

        public static HtmlTag Button(this IFubuPage page, string text)
        {
            var submitTag = new HtmlTag("input");
            submitTag.Attr("type", "button");
            submitTag.Attr("value", text);

            return submitTag;
        }

        public static HtmlTag Submit(this IFubuPage page, string text = "Submit")
        {
            var submitTag = new HtmlTag("input");
            submitTag.Attr("type", "submit");
            submitTag.Attr("value", text);

            return submitTag;
        }

        public static ImageTag Gravatar(this IFubuPage page, string email, int size = 100)
        {
            var user = page.GetUser();

            var image = page.GravatarHash(user.GravatarHash, size);
            image.Title("Refresh page to update, after save.");

            return image;
        }

        public static ImageTag GravatarHash(this IFubuPage page, string hash, int size = 100)
        {
            var image = new ImageTag(string.Format("http://www.gravatar.com/avatar/{0}?s={1}&d=mm", hash, size));

            return image;
        }

        public static TextAreaTag TextAreaFor<T>(this IFubuPage<T> page, Expression<Func<T, object>> expression) where T : class
        {
            var name = page.Get<IElementNamingConvention>().GetName(typeof(T), expression.ToAccessor());

            var text = page.Model.ValueOrDefault(expression).As<string>();

            var textarea = new TextAreaTag(name, string.Empty);

            textarea.Text(text);

            return textarea;
        }

        public static TextAreaTag TextAreaFor<T>(this IFubuPage page, Expression<Func<T, object>> expression) where T : class
        {
            var name = page.Get<IElementNamingConvention>().GetName(typeof(T), expression.ToAccessor());

            var textarea = new TextAreaTag(name, string.Empty);

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

        public static HtmlTag Option<T>(this IFubuPage<T> page,
            Expression<Func<T, object>> expression, string text, string value) where T : class
        {
            var expectedValue = page.Model.ValueOrDefault(expression) ?? string.Empty;
            var optionValue = value ?? string.Empty;

            var selected = expectedValue.ToString() == optionValue ? "selected" : string.Empty;

            var tag = new HtmlTag("option");
            tag.Attr(selected, selected);
            tag.Text(text);
            tag.Value(optionValue);

            return tag;
        }

        private static User GetUser(this IFubuPage page)
        {
            var security = page.Get<ISecurityContext>();
            var user = page.Get<IDocumentDatabase>()
                .Load<User>(security.CurrentIdentity.Name);

            return user;
        }
    }
}