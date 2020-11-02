using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using DNZ.MvcComponents;
using System;

namespace Microsoft.AspNetCore.Mvc
{
    public static class Handlebars
    {
        public static HanderBarTemplate AddHandlebarsPlugin(this IHtmlHelper helper)
        {
            return new HanderBarTemplate(helper);
        }

        public static HanderBarTemplate CreateHandlebarsTemplate(this IHtmlHelper helper, Func<object, HelperResult> template)
        {
            var html = template(null).ToHtmlString();
            var handlebar = helper.AddHandlebarsPlugin();
            handlebar.Html = new HtmlString(html);
            return handlebar;
        }

        public static HanderBarTemplate CreateHandlebarsTemplateInlineHelper(this IHtmlHelper helper, HelperResult template)
        {
            var html = template.ToHtmlString();
            var handlebar = helper.AddHandlebarsPlugin();
            handlebar.Html = new HtmlString(html);
            return handlebar;
        }

        public static HanderBarTemplate CreateHandlebarsTemplate(this IHtmlHelper helper, string template)
        {
            var handlebar = helper.AddHandlebarsPlugin();
            handlebar.Html = new HtmlString(template);
            return handlebar;
        }

        public static HanderBarTemplate CreateHandlebarsTemplate(this IHtmlHelper helper, string id, Func<object, HelperResult> template)
        {
            var html = template(null).ToHtmlString();
            var handlebar = helper.AddHandlebarsPlugin();
            handlebar.Id = id;
            handlebar.Html = new HtmlString(html);
            helper.ScriptOnce(@"
<script id=""" + id + @""" type=""text/x-handlebars-template"">
    " + html + @"
</script>");
            return handlebar;
        }

        public static HanderBarTemplate CreateHandlebarsTemplateInlineHelper(this IHtmlHelper helper, string id, HelperResult template)
        {
            var html = template.ToHtmlString();
            var handlebar = helper.AddHandlebarsPlugin();
            handlebar.Id = id;
            handlebar.Html = new HtmlString(html);
            helper.ScriptOnce(@"
<script id=""" + id + @""" type=""text/x-handlebars-template"">
    " + html + @"
</script>");
            return handlebar;
        }

        public static HanderBarTemplate CreateHandlebarsTemplate(this IHtmlHelper helper, string id, string template)
        {
            var handlebar = helper.AddHandlebarsPlugin();
            handlebar.Id = id;
            handlebar.Html = new HtmlString(template);
            helper.ScriptOnce(@"
<script id=""" + id + @""" type=""text/x-handlebars-template"">
    " + template.Replace("\t", "") + @"
</script>");
            return handlebar;
        }
    }
}