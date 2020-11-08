using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using DNZ.MvcComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.AspNetCore.Mvc
{
    public static partial class RenderScriptAndStyle
    {
        #region Script
        public static IHtmlContent Script(this IHtmlHelper htmlHelper, Func<object, HelperResult> scriptTag)
        {
            return Script(htmlHelper, scriptTag(null).ToHtmlString());
        }

        public static IHtmlContent Script(this IHtmlHelper htmlHelper, string scriptTag)
        {
            return ScriptOnce(htmlHelper, Guid.NewGuid().ToString(), scriptTag, false);
        }

        public static IHtmlContent ScriptOnce(this IHtmlHelper htmlHelper, Func<object, HelperResult> scriptTag, bool overWrite = false)
        {
            return ScriptOnce(htmlHelper, scriptTag(null).ToHtmlString(), overWrite);
        }

        public static IHtmlContent ScriptOnce(this IHtmlHelper htmlHelper, string scriptTag, bool overWrite = false)
        {
            return ScriptOnce(htmlHelper, scriptTag.GetHashCode().ToString(), scriptTag, overWrite);
        }

        public static IHtmlContent ScriptOnce(this IHtmlHelper htmlHelper, string key, string scriptTag, bool overWrite = false)
        {
            htmlHelper.ViewContext.HttpContext.SetItem(GetKeyValue(key, scriptTag), true, overWrite);
            return HtmlString.Empty;
        }
        #endregion

        #region Style
        public static IHtmlContent Style(this IHtmlHelper htmlHelper, Func<object, HelperResult> styleOrLinkTag)
        {
            return Style(htmlHelper, styleOrLinkTag(null).ToHtmlString());
        }

        public static IHtmlContent Style(this IHtmlHelper htmlHelper, string styleOrLinkTag)
        {
            return StyleOnce(htmlHelper, Guid.NewGuid().ToString(), styleOrLinkTag, false);
        }

        public static IHtmlContent StyleOnce(this IHtmlHelper htmlHelper, Func<object, HelperResult> styleOrLinkTag, bool overWrite = false)
        {
            return StyleOnce(htmlHelper, styleOrLinkTag(null).ToHtmlString(), overWrite);
        }

        public static IHtmlContent StyleOnce(this IHtmlHelper htmlHelper, string styleOrLinkTag, bool overWrite = false)
        {
            return StyleOnce(htmlHelper, styleOrLinkTag.GetHashCode().ToString(), styleOrLinkTag, overWrite);
        }

        public static IHtmlContent StyleOnce(this IHtmlHelper htmlHelper, string key, string styleOrLinkTag, bool overWrite = false)
        {
            htmlHelper.ViewContext.HttpContext.SetItem(GetKeyValue(key, styleOrLinkTag), false, overWrite);
            return HtmlString.Empty;
        }
        #endregion

        #region Renders
        public static IHtmlContent RenderScripts(this IHtmlHelper htmlHelper)
        {
            return new LazyHtmlContent(() =>
            {
                var stringBuilder = new StringBuilder();
                foreach (object key in htmlHelper.ViewContext.HttpContext.Items.Keys.Select(p => p.ToString()).Where(p => p.StartsWith("_script_")).OrderBy(p => p))
                {
                    var template = (KeyValuePair<string, string>)htmlHelper.ViewContext.HttpContext.Items[key];
                    if (template.Value != null)
                        stringBuilder.AppendLine(template.Value);
                }
                return stringBuilder.ToString();
            });
        }

        public static IHtmlContent RenderStyles(this IHtmlHelper htmlHelper)
        {
            return new LazyHtmlContent(() =>
            {
                var stringBuilder = new StringBuilder();
                foreach (object key in htmlHelper.ViewContext.HttpContext.Items.Keys.Select(p => p.ToString()).Where(p => p.StartsWith("_style_")).OrderBy(p => p))
                {
                    var template = (KeyValuePair<string, string>)htmlHelper.ViewContext.HttpContext.Items[key];
                    if (template.Value != null)
                        stringBuilder.AppendLine(template.Value);
                }
                return stringBuilder.ToString();
            });
        }
        #endregion

        #region Helpers
        private static KeyValuePair<string, string> GetKeyValue(string key, string value)
        {
            return new KeyValuePair<string, string>(key, value);
        }

        private static void SetItem(this HttpContext context, KeyValuePair<string, string> item, bool isScript, bool overWrite)
        {
            var isUnique = true;
            foreach (object key in context.Items.Keys.Select(p => p.ToString()).Where(p => isScript ? p.StartsWith("_script_") : p.StartsWith("_style_")))
            {
                var value = (KeyValuePair<string, string>)context.Items[key];
                if (value.Key != "" && value.Key == item.Key)
                {
                    isUnique = false;
                    if (overWrite)
                        context.Items[key] = item;

                    break;
                }
            }
            if (isUnique)
            {
                if (isScript)
                    context.Items["_script_" + ComponentUtility.UtcNowTicks] = item;
                else
                    context.Items["_style_" + ComponentUtility.UtcNowTicks] = item;
            }
        }
        #endregion
    }

    #region Without HtmlHelper
    public static partial class RenderScriptAndStyle
    {
        #region Script
        public static IHtmlContent Script(Func<object, HelperResult> scriptTag)
        {
            return Script(scriptTag(null).ToHtmlString());
        }

        public static IHtmlContent Script(string scriptTag)
        {
            return ScriptOnce(Guid.NewGuid().ToString(), scriptTag, false);
        }

        public static IHtmlContent ScriptOnce(Func<object, HelperResult> scriptTag, bool overWrite = false)
        {
            return ScriptOnce(scriptTag(null).ToHtmlString(), overWrite);
        }

        public static IHtmlContent ScriptOnce(string scriptTag, bool overWrite = false)
        {
            return ScriptOnce(scriptTag.GetHashCode().ToString(), scriptTag, overWrite);
        }

        public static IHtmlContent ScriptOnce(string key, string scriptTag, bool overWrite = false)
        {
            ComponentUtility.GetHttpContext().SetItem(GetKeyValue(key, scriptTag), true, overWrite);
            return HtmlString.Empty;
        }
        #endregion

        #region Style
        public static IHtmlContent Style(Func<object, HelperResult> styleOrLinkTag)
        {
            return Style(styleOrLinkTag(null).ToHtmlString());
        }

        public static IHtmlContent Style(string styleOrLinkTag)
        {
            return StyleOnce(Guid.NewGuid().ToString(), styleOrLinkTag, false);
        }

        public static IHtmlContent StyleOnce(Func<object, HelperResult> styleOrLinkTag, bool overWrite = false)
        {
            return StyleOnce(styleOrLinkTag(null).ToHtmlString(), overWrite);
        }

        public static IHtmlContent StyleOnce(string styleOrLinkTag, bool overWrite = false)
        {
            return StyleOnce(styleOrLinkTag.GetHashCode().ToString(), styleOrLinkTag, overWrite);
        }

        public static IHtmlContent StyleOnce(string key, string styleOrLinkTag, bool overWrite = false)
        {
            ComponentUtility.GetHttpContext().SetItem(GetKeyValue(key, styleOrLinkTag), false, overWrite);
            return HtmlString.Empty;
        }
        #endregion
    }
    #endregion
}