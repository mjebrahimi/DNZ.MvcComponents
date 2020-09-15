using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using DNZ.MvcComponents;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;

namespace Microsoft.AspNetCore.Mvc
{
    public class HtmlContent : IHtmlContent
    {
        private readonly Func<string> _func;

        public HtmlContent(Func<string> func)
        {
            _func = func;
        }

        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            string result = _func();
            writer.WriteLine(result);
        }
    }

    public static partial class RenderScriptAndStyle
    {
        public static IHtmlContent Script(this IHtmlHelper htmlHelper, IHtmlContent template)
        {
            return Script(htmlHelper, template.ToHtmlString());
        }

        public static IHtmlContent Script(this IHtmlHelper htmlHelper, Func<object, HelperResult> template)
        {
            return Script(htmlHelper, template(null).ToHtmlString());
        }

        public static IHtmlContent Script(this IHtmlHelper htmlHelper, string template)
        {
            return ScriptSingle(htmlHelper, ComponentUtility.UtcNowTicks.ToString(), template);
        }

        public static IHtmlContent ScriptFileSingle(this IHtmlHelper htmlHelper, Func<object, HelperResult> template, bool overWrite = false)
        {
            return ScriptFileSingle(htmlHelper, template(null).ToHtmlString(), overWrite);
        }

        public static IHtmlContent ScriptFileSingle(this IHtmlHelper htmlHelper, string template, bool overWrite = false)
        {
            string fileName = Regex.Match(template, "<script.+?src=[\"'](.+?)[\"'].*?>", RegexOptions.IgnoreCase).Groups[1].Value;
            return ScriptSingle(htmlHelper, fileName, template, overWrite);
        }

        public static IHtmlContent ScriptSingle(this IHtmlHelper htmlHelper, string keyName, Func<object, HelperResult> template, bool overWrite = false)
        {
            return ScriptSingle(htmlHelper, keyName, template(null).ToHtmlString(), overWrite);
        }

        public static IHtmlContent ScriptSingle(this IHtmlHelper htmlHelper, string keyName, string template, bool overWrite = false)
        {
            htmlHelper.ViewContext.HttpContext.SetItem(GetKeyValue(keyName, template), true, overWrite);
            return HtmlString.NewLine;
        }

        public static IHtmlContent Style(this IHtmlHelper htmlHelper, Func<object, HelperResult> template)
        {
            return Style(htmlHelper, template(null).ToHtmlString());
        }

        public static IHtmlContent Style(this IHtmlHelper htmlHelper, string template)
        {
            return StyleSingle(htmlHelper, ComponentUtility.UtcNowTicks.ToString(), template);
        }

        public static IHtmlContent StyleFileSingle(this IHtmlHelper htmlHelper, Func<object, HelperResult> template, bool overWrite = false)
        {
            return StyleFileSingle(htmlHelper, template(null).ToHtmlString(), overWrite);
        }

        public static IHtmlContent StyleFileSingle(this IHtmlHelper htmlHelper, string template, bool overWrite = false)
        {
            string fileName = Regex.Match(template, "<link.+?href=[\"'](.+?)[\"'].*?>", RegexOptions.IgnoreCase).Groups[1].Value;
            return StyleSingle(htmlHelper, fileName, template, overWrite);
        }

        public static IHtmlContent StyleSingle(this IHtmlHelper htmlHelper, string keyName, Func<object, HelperResult> template, bool overWrite = false)
        {
            return StyleSingle(htmlHelper, keyName, template(null).ToHtmlString(), overWrite);
        }

        public static IHtmlContent StyleSingle(this IHtmlHelper htmlHelper, string keyName, string template, bool overWrite = false)
        {
            htmlHelper.ViewContext.HttpContext.SetItem(GetKeyValue(keyName, template), false, overWrite);
            return HtmlString.NewLine;
        }

        // ===============================================================================
        public static IHtmlContent RenderScripts(this IHtmlHelper htmlHelper)
        {
            return new HtmlContent(() =>
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (object key in htmlHelper.ViewContext.HttpContext.Items.Keys.Cast<object>().Select(p => p.ToString()).Where(p => p.StartsWith("_script_")).OrderBy(p => p))
                {
                    KeyValuePair<string, string> template = (KeyValuePair<string, string>)htmlHelper.ViewContext.HttpContext.Items[key];// as Func<object, HelperResult>;
                    if (template.Value != null)
                    {
                        stringBuilder.AppendLine(template.Value);
                    }
                }
                return stringBuilder.ToString();
            });
        }

        public static IHtmlContent RenderStyles(this IHtmlHelper htmlHelper)
        {
            return new HtmlContent(() =>
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (object key in htmlHelper.ViewContext.HttpContext.Items.Keys.Cast<object>().Select(p => p.ToString()).Where(p => p.StartsWith("_style_")).OrderBy(p => p))
                {
                    KeyValuePair<string, string> template = (KeyValuePair<string, string>)htmlHelper.ViewContext.HttpContext.Items[key];// as Func<object, HelperResult>;
                    if (template.Value != null)
                    {
                        stringBuilder.AppendLine(template.Value);
                    }
                }
                return stringBuilder.ToString();
            });
        }

        private static KeyValuePair<string, string> GetKeyValue(string key, string value)
        {
            return new KeyValuePair<string, string>(key, value);
        }

        private static void SetItem(this HttpContext context, KeyValuePair<string, string> item, bool isScript, bool overWrite)
        {
            bool isUnique = true;
            foreach (object key in context.Items.Keys.Cast<object>().Select(p => p.ToString()).Where(p => isScript ? p.StartsWith("_script_") : p.StartsWith("_style_")))
            {
                KeyValuePair<string, string> value = (KeyValuePair<string, string>)context.Items[key];
                if (value.Key != "" && value.Key == item.Key)
                {
                    isUnique = false;
                    if (overWrite)
                    {
                        context.Items[key] = item;
                    }

                    break;
                }
            }
            if (isUnique)
            {
                if (isScript)
                {
                    context.Items["_script_" + ComponentUtility.UtcNowTicks] = item;
                }
                else
                {
                    context.Items["_style_" + ComponentUtility.UtcNowTicks] = item;
                }
            }
        }
    }

    public static partial class RenderScriptAndStyle
    {
        public static IHtmlContent Script(Func<object, HelperResult> template)
        {
            return Script(template(null).ToHtmlString());
        }

        public static IHtmlContent Script(string template)
        {
            return ScriptSingle(ComponentUtility.UtcNowTicks.ToString(), template);
        }

        public static IHtmlContent ScriptFileSingle(Func<object, HelperResult> template, bool overWrite = false)
        {
            return ScriptFileSingle(template(null).ToHtmlString(), overWrite);
        }

        public static IHtmlContent ScriptFileSingle(string template, bool overWrite = false)
        {
            string fileName = Regex.Match(template, "<script.+?src=[\"'](.+?)[\"'].*?>", RegexOptions.IgnoreCase).Groups[1].Value;
            return ScriptSingle(fileName, template, overWrite);
        }

        public static IHtmlContent ScriptSingle(string keyName, Func<object, HelperResult> template, bool overWrite = false)
        {
            return ScriptSingle(keyName, template(null).ToHtmlString(), overWrite);
        }

        public static IHtmlContent ScriptSingle(string keyName, string template, bool overWrite = false)
        {
            ComponentUtility.GetHttpContext().SetItem(GetKeyValue(keyName, template), true, overWrite);
            return HtmlString.NewLine;
        }

        public static IHtmlContent Style(Func<object, HelperResult> template)
        {
            return Style(template(null).ToHtmlString());
        }

        public static IHtmlContent Style(string template)
        {
            return StyleSingle(ComponentUtility.UtcNowTicks.ToString(), template);
        }

        public static IHtmlContent StyleFileSingle(Func<object, HelperResult> template, bool overWrite = false)
        {
            return StyleFileSingle(template(null).ToHtmlString(), overWrite);
        }

        public static IHtmlContent StyleFileSingle(string template, bool overWrite = false)
        {
            string fileName = Regex.Match(template, "<link.+?href=[\"'](.+?)[\"'].*?>", RegexOptions.IgnoreCase).Groups[1].Value;
            return StyleSingle(fileName, template, overWrite);
        }

        public static IHtmlContent StyleSingle(string keyName, Func<object, HelperResult> template, bool overWrite = false)
        {
            return StyleSingle(keyName, template(null).ToHtmlString(), overWrite);
        }

        public static IHtmlContent StyleSingle(string keyName, string template, bool overWrite = false)
        {
            ComponentUtility.GetHttpContext().SetItem(GetKeyValue(keyName, template), false, overWrite);
            return HtmlString.NewLine;
        }
    }
}