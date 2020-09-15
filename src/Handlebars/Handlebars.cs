﻿using Microsoft.AspNetCore.Html;
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
            string html = template(null).ToHtmlString();
            HanderBarTemplate handlebar = helper.AddHandlebarsPlugin();
            handlebar.Html = new HtmlString(html);
            return handlebar;
        }

        public static HanderBarTemplate CreateHandlebarsTemplateInlineHelper(this IHtmlHelper helper, HelperResult template)
        {
            string html = template.ToHtmlString();
            HanderBarTemplate handlebar = helper.AddHandlebarsPlugin();
            handlebar.Html = new HtmlString(html);
            return handlebar;
        }

        public static HanderBarTemplate CreateHandlebarsTemplate(this IHtmlHelper helper, string template)
        {
            HanderBarTemplate handlebar = helper.AddHandlebarsPlugin();
            handlebar.Html = new HtmlString(template);
            return handlebar;
        }

        public static HanderBarTemplate CreateHandlebarsTemplate(this IHtmlHelper helper, string id, Func<object, HelperResult> template)
        {
            string html = template(null).ToHtmlString();
            HanderBarTemplate handlebar = helper.AddHandlebarsPlugin();
            handlebar.Id = id;
            handlebar.Html = new HtmlString(html);
            helper.ScriptSingle(id, @"
<script id=""" + id + @""" type=""text/x-handlebars-template"">
    " + html + @"
</script>
");
            return handlebar;
        }

        public static HanderBarTemplate CreateHandlebarsTemplateInlineHelper(this IHtmlHelper helper, string id, HelperResult template)
        {
            string html = template.ToHtmlString();
            HanderBarTemplate handlebar = helper.AddHandlebarsPlugin();
            handlebar.Id = id;
            handlebar.Html = new HtmlString(html);
            helper.ScriptSingle(id, @"
<script id=""" + id + @""" type=""text/x-handlebars-template"">
    " + html + @"
</script>
");
            return handlebar;
        }

        public static HanderBarTemplate CreateHandlebarsTemplate(this IHtmlHelper helper, string id, string template)
        {
            HanderBarTemplate handlebar = helper.AddHandlebarsPlugin();
            handlebar.Id = id;
            handlebar.Html = new HtmlString(template);
            helper.ScriptSingle(id, @"
<script id=""" + id + @""" type=""text/x-handlebars-template"">
    " + template.Replace("\t", "") + @"
</script>");
            return handlebar;
        }
    }
}