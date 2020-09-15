using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using DNZ.MvcComponents;
using System.Collections.Generic;

namespace Microsoft.AspNetCore.Mvc
{
    public static class PopoverHelper
    {
        public static IHtmlContent BsPopover(this IHtmlHelper html, string content, string title = "", Placement placement = Placement.Bottom)
        {
            return new HtmlString("data-toggle=\"popover\" data-content=\"" + content + "\" " + (string.IsNullOrEmpty(title) ? "" : " title =\"" + title + "\"") + (placement == Placement.Top ? "" : " data-placement=\"" + placement.ToString().ToLower() + "\""));
        }

        public static Dictionary<string, string> BsPopoverAttibutes(this IHtmlHelper html, string content, string title = "", Placement placement = Placement.Bottom)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                { "data-toggle", "popover" },
                { "data-content", content }
            };
            if (title.HasValue())
            {
                dict.Add("title", title);
            }

            if (placement != Placement.Top)
            {
                dict.Add("data-placement", placement.ToString().ToLower());
            }

            return dict;
        }

        public static Popover Popover(string id)
        {
            return new Popover(id);
        }

        public static Popover Popover(this IHtmlHelper html, string id)
        {
            return new Popover(id, html);
        }
    }
}