using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using DNZ.MvcComponents;
using System;

namespace Microsoft.AspNetCore.Mvc
{
    public static class DataTablesHelper
    {
        private const string dataTables_bootstrap_css = "DNZ.MvcComponents.DataTables.dataTables.bootstrap.css";
        private const string jquery_dataTables_css = "DNZ.MvcComponents.DataTables.jquery.dataTables.css";
        private const string jquery_dataTables_js = "DNZ.MvcComponents.DataTables.jquery.dataTables.js";
        private const string jquery_dataTables_min_js = "DNZ.MvcComponents.DataTables.jquery.dataTables.min.js";
        private const string dataTables_bootstrap_js = "DNZ.MvcComponents.DataTables.dataTables.bootstrap.js";
        private const string dataTables_bootstrap_min_js = "DNZ.MvcComponents.DataTables.dataTables.bootstrap.min.js";

        //public static DataTablesOption DataTables(this IHtmlHelper helper, Func<object, HelperResult> thead, Func<object, HelperResult> tbody, Dictionary<string, object> htmlAttributes = null)
        //{
        //    helper.StyleFileSingle(@"<link href=""" + ComponentUtility.GetWebResourceUrl(dataTables_bootstrap_css) + @""" rel=""stylesheet"" />");
        //    helper.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(jquery_dataTables_min_js) + @"""></script>");
        //    helper.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(dataTables_bootstrap_min_js) + @"""></script>");
        //    return new DataTablesOption(helper, thead, tbody, new RouteValueDictionary(htmlAttributes));
        //}
        public static DataTablesOption DataTables(this IHtmlHelper helper, Func<object, HelperResult> thead, Func<object, HelperResult> tbody, object htmlAttributes = null)
        {
            helper.StyleFileSingle(@"<link href=""" + ComponentUtility.GetWebResourceUrl(dataTables_bootstrap_css) + @""" rel=""stylesheet"" />");
            helper.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(jquery_dataTables_min_js) + @"""></script>");
            helper.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(dataTables_bootstrap_min_js) + @"""></script>");
            return new DataTablesOption(helper, thead, tbody, new RouteValueDictionary(htmlAttributes));
        }
    }
}
