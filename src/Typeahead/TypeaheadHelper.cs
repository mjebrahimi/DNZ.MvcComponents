using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using DNZ.MvcComponents;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Microsoft.AspNetCore.Mvc
{
    public static class TypeaheadHelper
    {
        private const string typeahead_js = "DNZ.MvcComponents.Typeahead.bootstrap-typeahead.js";
        private const string typeahead_min_js = "DNZ.MvcComponents.Typeahead.bootstrap-typeahead.min.js";

        public static IHtmlContent TypeaheadFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IEnumerable<string> source, object htmlAttributes = null)
        {
            TypeaheadOption option = new TypeaheadOption();
            if (source != null)
            {
                option.Source(source);
            }

            return html.TypeaheadFor(expression, option, htmlAttributes);
        }

        public static IHtmlContent TypeaheadFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Dictionary<int, string> source, object htmlAttributes = null)
        {
            TypeaheadOption option = new TypeaheadOption();
            option.Source(source);
            return html.TypeaheadFor(expression, option, htmlAttributes);
        }

        public static IHtmlContent TypeaheadFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IEnumerable source, object htmlAttributes = null)
        {
            TypeaheadOption option = new TypeaheadOption();
            option.Source(source);
            return html.TypeaheadFor(expression, option, htmlAttributes);
        }

        public static IHtmlContent TypeaheadFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IEnumerable<string> source, TypeaheadOption option, object htmlAttributes = null)
        {
            if (source != null)
            {
                option.Source(source);
            }

            return html.TypeaheadFor(expression, option, htmlAttributes);
        }

        public static IHtmlContent TypeaheadFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Dictionary<int, string> source, TypeaheadOption option, object htmlAttributes = null)
        {
            option.Source(source);
            return html.TypeaheadFor(expression, option, htmlAttributes);
        }

        public static IHtmlContent TypeaheadFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IEnumerable source, TypeaheadOption option, object htmlAttributes = null)
        {
            option.Source(source);
            return html.TypeaheadFor(expression, option, htmlAttributes);
        }

        public static IHtmlContent TypeaheadFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, TypeaheadOption option, object htmlAttributes = null)
        {
            ViewFeatures.ModelExplorer metadata = ExpressionMetadataProvider.FromLambdaExpression(expression, html.ViewData, html.MetadataProvider);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string id = html.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName);
            string name = html.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName);
            string value = metadata.Model?.ToString() ?? "";
            option.Dictionary.TryGetValue(value, out string txtValue);
            string displayName = metadata.Metadata.DisplayName ?? metadata.Metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            Dictionary<string, object> mergAttr = ComponentUtility.MergeAttributes(htmlAttributes, new { id = id + "_typeahead", @class = "form-control", placeholder = displayName, autocomplete = "off" });
            IHtmlContent textbox = html.TextBox(name + "_typeahead", txtValue, mergAttr);
            IHtmlContent hidden = html.HiddenFor(expression);
            html.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(typeahead_js) + @"""></script>");
            option.OnSelect(@"function(item) {
                            if ( item.value != ""-21"") {
                                $(""#" + id + @""").val(item.value).trigger('change').valid();
                            }
                        }");
            html.Script(@"
            <script>
                $(function(){
                    $(""#" + id + @"_typeahead"").typeahead(" + option.RenderOptions() + @")
                    .keypress(function(){
                        $(""#" + id + @""").val('').trigger('change').valid();
                    });
                });
            </script>");
            return new HtmlString(textbox.ToHtmlString() + hidden.ToHtmlString());
        }
    }
}