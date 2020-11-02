using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using DNZ.MvcComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Microsoft.AspNetCore.Mvc
{
    public static class TypeaheadMaster
    {
        //http://twitter.github.io/typeahead.js/
        //https://cdnjs.com/libraries/typeahead.js

        private const string typeahead_bundle_js_cdn = "<script src=\"https://cdnjs.cloudflare.com/ajax/libs/typeahead.js/0.11.1/typeahead.bundle.min.js\" integrity=\"sha512-qOBWNAMfkz+vXXgbh0Wz7qYSLZp6c14R0bZeVX2TdQxWpuKr6yHjBIM69fcF8Ve4GUX6B6AKRQJqiiAmwvmUmQ==\" crossorigin=\"anonymous\"></script>";
        private const string typeahead_css = "DNZ.MvcComponents.TypeaheadMaster.typeahead.css";
        private const string typeahead_bundle_js = "DNZ.MvcComponents.TypeaheadMaster.typeahead.bundle.js";

        public static IHtmlContent TypeaheadMasterFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IEnumerable<string> source, object htmlAttributes = null)
        {
            var option = new TypeaheadMasterOption();
            if (source != null)
            {
                option.DataSetSource(source);
            }

            return html.TypeaheadMasterFor(expression, option, htmlAttributes);
        }
        //public static IHtmlContent TypeaheadMasterFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Dictionary<int, string> source, object htmlAttributes = null)
        //{
        //    var option = new TypeaheadMasterOption();
        //    option.DataSetSource(source);
        //    return html.TypeaheadMasterFor(expression, option, htmlAttributes);
        //}
        //public static IHtmlContent TypeaheadMasterFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IEnumerable source, object htmlAttributes = null)
        //{
        //    var option = new TypeaheadMasterOption();
        //    option.DataSetSource(source);
        //    return html.TypeaheadMasterFor(expression, option, htmlAttributes);
        //}

        public static IHtmlContent TypeaheadMasterFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IEnumerable<string> source, TypeaheadMasterOption option, object htmlAttributes = null)
        {
            if (source != null)
            {
                option.DataSetSource(source);
            }

            return html.TypeaheadMasterFor(expression, option, htmlAttributes);
        }
        //public static IHtmlContent TypeaheadMasterFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Dictionary<int, string> source, TypeaheadMasterOption option, object htmlAttributes = null)
        //{
        //    option.DataSetSource(source);
        //    return html.TypeaheadMasterFor(expression, option, htmlAttributes);
        //}
        //public static IHtmlContent TypeaheadMasterFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IEnumerable source, TypeaheadMasterOption option, object htmlAttributes = null)
        //{
        //    option.DataSetSource(source);
        //    return html.TypeaheadMasterFor(expression, option, htmlAttributes);
        //}

        public static IHtmlContent TypeaheadMasterFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, TypeaheadMasterOption option, object htmlAttributes = null)
        {
            var metadata = html.GetModelExplorer(expression);
            var htmlFieldName = html.FieldNameFor(expression);
            var id = html.FieldIdFor(expression);
            var displayName = metadata.Metadata.DisplayName ?? metadata.Metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            var mergAttr = ComponentUtility.MergeAttributes(htmlAttributes, new { @class = "form-control", placeholder = displayName, autocomplete = "off" });
            var editor = html.TextBoxFor(expression, mergAttr);
            html.StyleOnce(ComponentUtility.GetCssTag(typeahead_css, null));
            html.ScriptOnce(ComponentUtility.GetCssTag(typeahead_bundle_js, typeahead_bundle_js_cdn));
            html.Script(@"
            <script>
                $(function(){
                    $(""#" + id + @""").typeahead(" + option.RenderOptions() + @",
                    " + option.RenderDataSetOptions() + @");
                });
            </script>");
            return editor;
        }

        public static Bloodhound DefinGlobalBloodhound(this IHtmlHelper html, string name, Bloodhound bloodhound)
        {
            bloodhound.DefinGlobalJavascriptVariable(html, name);
            return bloodhound;
        }
    }
}