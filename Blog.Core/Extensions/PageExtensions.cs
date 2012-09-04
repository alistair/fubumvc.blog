﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Blog.Core.Constants;
using Blog.Core.HtmlTags;
using FubuCore.Reflection;
using FubuMVC.Core.Security;
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
            var securityContext = page.Get<ISecurityContext>();
            var items = navigationService.MenuFor(new NavigationKey(menuName ?? StringConstants.BlogName));
            var menu = new HtmlTag("ul");


            items.Each(x =>
            {
                var link = new LinkTag(x.Key, x.Url);
                var li = new HtmlTag("li");

                if (x.Key.Equals("Logout") && x.MenuItemState == MenuItemState.Available)
                {
                    var spanTag = new HtmlTag("span");
                    spanTag.Text(string.Format("Welcome, {0}", securityContext.CurrentIdentity.Name));
                    menu.Append(spanTag);
                }

                if (x.MenuItemState == MenuItemState.Active)
                    li.AddClass("current");

                if(x.MenuItemState == MenuItemState.Active || x.MenuItemState == MenuItemState.Available)
                    menu.Append(li.Append(link));

            });

            return menu;
        }

        public static HtmlTag Submit(this IFubuPage page)
        {
            var submitTag = new HtmlTag("input");
            submitTag.Attr("type","submit");
            submitTag.Attr("value", "Submit");

            return submitTag;
        }

        public static TextAreaTag TextAreaFor<T>(this IFubuPage page, Expression<Func<T, object>> expression) where T : class
        {
            var name = page.Get<IElementNamingConvention>().GetName(typeof (T), expression.ToAccessor());
            return new TextAreaTag(name, string.Empty);
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