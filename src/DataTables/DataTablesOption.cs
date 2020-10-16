using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using DNZ.MvcComponents;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;

namespace Microsoft.AspNetCore.Mvc
{
    public class DataTablesOption : IOptionBuilder, IHtmlContent
    {
        private const string persian_json = "DNZ.MvcComponents.DataTables.Persian.json";

        private readonly RouteValueDictionary _htmlAttributes;
        private readonly IHtmlHelper htmlHelper;
        private readonly string _thead;
        private readonly string _tbody;
        private bool bordered;
        private bool striped;
        private bool condensed;
        private bool hover;
        //private string id;
        private bool footer;
        public Dictionary<string, object> Attributes { get; set; }

        public DataTablesOption(IHtmlHelper helper, Func<object, HelperResult> thead, Func<object, HelperResult> tbody, RouteValueDictionary htmlAttributes)
        {
            Attributes = new Dictionary<string, object>();
            _htmlAttributes = htmlAttributes;
            _thead = thead(null).ToHtmlString();
            _tbody = tbody(null).ToHtmlString();
            htmlHelper = helper;
            Bordered(true);
            Striped(true);
            Hover(true);
            Searching(false);
            Info(false);
            Paging(false);
            Order(0, DataTabledOrder.Asc);
            //Attributes["language"] = "{ 'sUrl': '" + ComponentUtility.GetWebResourceUrl(persian_json) + "' }";
        }

        public DataTablesOption Paging(bool value)
        {
            Attributes["paging"] = value.ToString().ToLower();
            return this;
        }

        public DataTablesOption LengthChange(bool value)
        {
            Attributes["lengthChange"] = value.ToString().ToLower();
            return this;
        }

        public DataTablesOption Searching(bool value)
        {
            Attributes["searching"] = value.ToString().ToLower();
            return this;
        }

        public DataTablesOption Ordering(bool value)
        {
            Attributes["ordering"] = value.ToString().ToLower();
            return this;
        }

        public DataTablesOption Order(int columnIndex, DataTabledOrder order)
        {
            Attributes["order"] = $"[[ {columnIndex}, '{order.ToString().ToLower()}' ]]";
            return this;
        }

        public DataTablesOption Info(bool value)
        {
            Attributes["info"] = value.ToString().ToLower();
            return this;
        }

        public DataTablesOption AutoWidth(bool value)
        {
            Attributes["autoWidth"] = value;
            return this;
        }

        public DataTablesOption Bordered(bool value)
        {
            bordered = value;
            return this;
        }

        public DataTablesOption Striped(bool value)
        {
            striped = value;
            return this;
        }

        public DataTablesOption Condensed(bool value)
        {
            condensed = value;
            return this;
        }

        public DataTablesOption Hover(bool value)
        {
            hover = value;
            return this;
        }

        public DataTablesOption Footer(bool value)
        {
            footer = value;
            return this;
        }

        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            var id = Guid.NewGuid().ToString();
            var classes = "";
            id = Guid.NewGuid().ToString();
            classes += bordered ? " table-bordered" : "";
            classes += striped ? " table-striped" : "";
            classes += condensed ? " table-condensed" : "";
            classes += hover ? " table-hover" : "";
            if (_htmlAttributes.ContainsKey("class"))
            {
                classes += " " + _htmlAttributes["class"];
            }

            if (_htmlAttributes.ContainsKey("id"))
            {
                id = _htmlAttributes["id"].ToString();
            }

            var attr = string.Concat(_htmlAttributes.Where(p => p.Key != "class" && p.Key != "id").Select(p => p.Key + "=\"" + p.Value + "\" "));
            var tfoot = "<tfoot" + _thead.Substring(6, _thead.Length - 6) + "tfoot>";
            var html = @"
                    <table id=""" + id + @""" class=""table" + classes + @""" " + attr + @">
                        " + _thead + @"
                        " + _tbody + @"
                        " + (footer ? tfoot : "") + @"
                    </table>
                    ";
            htmlHelper.Script(@"
            <script>
                $(function(){
                    $(""#" + id + @""").DataTable(" + this.RenderOptions() + @");
                });
            </script>");

            writer.Write(html);
        }
    }
}

