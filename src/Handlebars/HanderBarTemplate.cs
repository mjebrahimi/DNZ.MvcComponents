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
        //https://handlebarsjs.com/
        //https://cdnjs.com/libraries/handlebars.js
        private const string handlebars_js_cdn = "<script src=\"https://cdnjs.cloudflare.com/ajax/libs/handlebars.js/4.7.6/handlebars.min.js\" integrity=\"sha512-zT3zHcFYbQwjHdKjCu6OMmETx8fJA9S7E6W7kBeFxultf75OPTYUJigEKX58qgyQMi1m1EgenfjMXlRZG8BXaw==\" crossorigin=\"anonymous\"></script>";
        private const string handlebars_js = "DNZ.MvcComponents.Handlebars.handlebars.js";

        public HanderBarTemplate(IHtmlHelper helper)
        {
            helper.ScriptOnce(ComponentUtility.GetJsTag(handlebars_js, handlebars_js_cdn));
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