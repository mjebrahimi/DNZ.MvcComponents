using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using DNZ.MvcComponents;
using System;

namespace Microsoft.AspNetCore.Mvc
{
    public static class DataTablesHelper
    {
        //https://datatables.net/
        //https://cdnjs.com/libraries/datatables
        private const string dataTables_bootstrap_css_cdn = "<link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/datatables/1.10.21/css/dataTables.bootstrap.min.css\" integrity=\"sha512-BMbq2It2D3J17/C7aRklzOODG1IQ3+MHw3ifzBHMBwGO/0yUqYmsStgBjI0z5EYlaDEFnvYV7gNYdD3vFLRKsA==\" crossorigin=\"anonymous\" />";
        private const string jquery_dataTables_js_cdn = "<script src=\"https://cdnjs.cloudflare.com/ajax/libs/datatables/1.10.21/js/jquery.dataTables.min.js\" integrity=\"sha512-BkpSL20WETFylMrcirBahHfSnY++H2O1W+UnEEO4yNIl+jI2+zowyoGJpbtk6bx97fBXf++WJHSSK2MV4ghPcg==\" crossorigin=\"anonymous\"></script>";
        private const string dataTables_bootstrap_js_cdn = "<script src=\"https://cdnjs.cloudflare.com/ajax/libs/datatables/1.10.21/js/dataTables.bootstrap.min.js\" integrity=\"sha512-F0E+jKGaUC90odiinxkfeS3zm9uUT1/lpusNtgXboaMdA3QFMUez0pBmAeXGXtGxoGZg3bLmrkSkbK1quua4/Q==\" crossorigin=\"anonymous\"></script>";
        private const string dataTables_bootstrap_css = "DNZ.MvcComponents.DataTables.dataTables.bootstrap.css";
        private const string jquery_dataTables_min_js = "DNZ.MvcComponents.DataTables.jquery.dataTables.min.js";
        private const string dataTables_bootstrap_min_js = "DNZ.MvcComponents.DataTables.dataTables.bootstrap.min.js";

        //public static DataTablesOption DataTables(this IHtmlHelper helper, Func<object, HelperResult> thead, Func<object, HelperResult> tbody, Dictionary<string, object> htmlAttributes = null)
        //{
        //    helper.StyleOnce(@"<link href=""" + ComponentUtility.GetWebResourceUrl(dataTables_bootstrap_css) + @""" rel=""stylesheet"" />");
        //    helper.ScriptOnce(@"<script src=""" + ComponentUtility.GetWebResourceUrl(jquery_dataTables_min_js) + @"""></script>");
        //    helper.ScriptOnce(@"<script src=""" + ComponentUtility.GetWebResourceUrl(dataTables_bootstrap_min_js) + @"""></script>");
        //    return new DataTablesOption(helper, thead, tbody, new RouteValueDictionary(htmlAttributes));
        //}
        public static DataTablesOption DataTables(this IHtmlHelper helper, Func<object, HelperResult> thead, Func<object, HelperResult> tbody, object htmlAttributes = null)
        {
            helper.StyleOnce(ComponentUtility.GetCssTag(dataTables_bootstrap_css, dataTables_bootstrap_css_cdn));
            helper.ScriptOnce(ComponentUtility.GetJsTag(jquery_dataTables_min_js, jquery_dataTables_js_cdn));
            helper.ScriptOnce(ComponentUtility.GetJsTag(dataTables_bootstrap_min_js, dataTables_bootstrap_js_cdn));
            return new DataTablesOption(helper, thead, tbody, new RouteValueDictionary(htmlAttributes));
        }
    }
}
