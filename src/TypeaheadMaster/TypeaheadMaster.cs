using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using DNZ.MvcComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Microsoft.AspNetCore.Mvc
{
    public static class TypeaheadMaster
    {
        private const string typeahead_css = "DNZ.MvcComponents.TypeaheadMaster.typeahead.css";
        private const string typeahead_jquery_js = "DNZ.MvcComponents.TypeaheadMaster.typeahead.jquery.js";
        private const string bloodhound_js = "DNZ.MvcComponents.TypeaheadMaster.bloodhound.js";
        private const string typeahead_bundle_js = "DNZ.MvcComponents.TypeaheadMaster.typeahead.bundle.js";

        public static IHtmlContent TypeaheadMasterFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IEnumerable<string> source, object htmlAttributes = null)
        {
            TypeaheadMasterOption option = new TypeaheadMasterOption();
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
            ViewFeatures.ModelExplorer metadata = ExpressionMetadataProvider.FromLambdaExpression(expression, html.ViewData, html.MetadataProvider);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string id = html.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName);
            string displayName = metadata.Metadata.DisplayName ?? metadata.Metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            Dictionary<string, object> mergAttr = ComponentUtility.MergeAttributes(htmlAttributes, new { @class = "form-control", placeholder = displayName, autocomplete = "off" });
            IHtmlContent editor = html.TextBoxFor(expression, mergAttr);
            html.StyleFileSingle(@"<link href=""" + ComponentUtility.GetWebResourceUrl(typeahead_css) + @""" rel=""stylesheet"" />");
            html.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(typeahead_bundle_js) + @"""></script>");
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