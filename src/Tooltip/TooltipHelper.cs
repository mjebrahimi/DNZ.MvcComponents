using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Microsoft.AspNetCore.Mvc
{
    public static class TooltipHelper
    {
        public static IHtmlContent BsTooltip(this IHtmlHelper html, string title, Placement placement = Placement.Top)
        {
            return new HtmlString("data-toggle=\"tooltip\" title=\"" + title + "\"" + (placement == Placement.Top ? "" : " data-placement=\"" + placement.ToString().ToLower() + "\""));
        }

        public static Dictionary<string, string> BsTooltipAttibutes(this IHtmlHelper html, string title, Placement placement = Placement.Top)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                { "data-toggle", "tooltip" },
                { "title", title }
            };
            if (placement != Placement.Top)
            {
                dict.Add("data-placement", placement.ToString().ToLower());
            }

            return dict;
        }

        public static Tooltip Tooltip(string id)
        {
            return new Tooltip(id);
        }

        public static Tooltip Tooltip(this IHtmlHelper html, string id)
        {
            return new Tooltip(id, html);
        }
    }
}
