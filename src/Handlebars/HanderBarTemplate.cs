using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using DNZ.MvcComponents;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;

namespace Microsoft.AspNetCore.Mvc
{
    public class HanderBarTemplate : IHtmlContent
    {
        private const string handlebars_js = "DNZ.MvcComponents.Handlebars.handlebars.js";
        private const string handlebars_4_js = "DNZ.MvcComponents.Handlebars.handlebars-v4.0.5.js";

        public HanderBarTemplate(IHtmlHelper helper)
        {
            helper.ScriptFileSingle(@"<script hand src=""" + ComponentUtility.GetWebResourceUrl(handlebars_js) + @"""></script>");
        }

        public IHtmlContent Html { get; set; }

        public string Id { get; set; }

        public string Script
        {
            get
            {
                if (string.IsNullOrEmpty(Id))
                {
                    return string.Format("Handlebars.compile({0})", Html.ToHtmlString().ToJavaScriptString());
                }
                else
                {
                    return @"Handlebars.compile($(""#" + Id + @""").html())";
                }
            }
        }

        //public IHtmlContent Render(string context)
        //{
        //    var html = string.Format("{0}({1})", Script, context);
        //    return new HtmlString(html);
        //}
        //public IHtmlContent Render(object value)
        //{
        //    var html = string.Format("{0}({1})", Script, ComponentUtility.ToJsonStringWithoutQuotes(value));
        //    return new HtmlString(html);
        //}
        //public IHtmlContent Render(Dictionary<string, object> value)
        //{
        //    var html = string.Format("{0}({1})", Script, ComponentUtility.ToJsonStringWithoutQuotes(value));
        //    return new HtmlString(html);
        //}

        public IHtmlContent Render(string context)
        {
            return new HtmlString(string.Format("{0}({1})", Script, context));
        }

        public IHtmlContent Render(object value)
        {
            return new HtmlString(string.Format("{0}({1})", Script, ComponentUtility.ToJsonStringWithoutQuotes(value)));
        }

        public IHtmlContent Render(Dictionary<string, object> value)
        {
            return new HtmlString(string.Format("{0}({1})", Script, ComponentUtility.ToJsonStringWithoutQuotes(value)));
        }

        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            writer.Write("");
        }
    }
}