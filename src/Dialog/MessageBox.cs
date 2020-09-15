using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Microsoft.AspNetCore.Mvc
{
    public static partial class MessageBox
    {
        public static Dialog Dialog(string id)
        {
            return new Dialog(id);
        }

        public static Dialog Dialog(this IHtmlHelper html, string id)
        {
            return new Dialog(id, html);
        }

        public static IHtmlContent OpenDialog(this IHtmlHelper html, string id)
        {
            string script = new Dialog(id, html).Show().Script;
            return new HtmlString(script);
        }

        public static Dialog Dialog(string id, string title, Func<object, HelperResult> body, Func<object, HelperResult> buttons)
        {
            return new Dialog(id).Title(title).Body(body).Buttons(buttons);
        }

        public static Dialog Dialog(this IHtmlHelper html, string id, string title, Func<object, HelperResult> body, Func<object, HelperResult> buttons)
        {
            return new Dialog(id, html).Title(title).Body(body).Buttons(buttons);
        }

        public static Dialog Dialog<T>(this IHtmlHelper html, string id, string title, Func<T, HelperResult> body, Func<T, HelperResult> buttons, T item)
        {
            return new Dialog(id, html).Title(title).Body(body, item).Buttons(buttons, item);
        }

        public static Dialog Dialog(string id, string title, string body, string buttons)
        {
            return new Dialog(id).Title(title).Body(body).Buttons(buttons);
        }
    }
}
