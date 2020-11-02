using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        //https://github.com/biggora/bootstrap-ajax-typeahead
        private const string typeahead_js = "DNZ.MvcComponents.Typeahead.bootstrap-typeahead.js";

        public static IHtmlContent TypeaheadFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IEnumerable<string> source, object htmlAttributes = null)
        {
            var option = new TypeaheadOption();
            if (source != null)
            {
                option.Source(source);
            }

            return html.TypeaheadFor(expression, option, htmlAttributes);
        }

        public static IHtmlContent TypeaheadFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Dictionary<int, string> source, object htmlAttributes = null)
        {
            var option = new TypeaheadOption();
            option.Source(source);
            return html.TypeaheadFor(expression, option, htmlAttributes);
        }

        public static IHtmlContent TypeaheadFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IEnumerable source, object htmlAttributes = null)
        {
            var option = new TypeaheadOption();
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
            var metadata = html.GetModelExplorer(expression);
            var htmlFieldName = html.FieldNameFor(expression);
            var id = html.FieldIdFor(expression);
            var name = html.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName);
            var value = metadata.Model?.ToString() ?? "";
            option.Dictionary.TryGetValue(value, out var txtValue);
            var displayName = metadata.Metadata.DisplayName ?? metadata.Metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            var mergAttr = ComponentUtility.MergeAttributes(htmlAttributes, new { id = id + "_typeahead", @class = "form-control", placeholder = displayName, autocomplete = "off" });
            var textbox = html.TextBox(name + "_typeahead", txtValue, mergAttr);
            var hidden = html.HiddenFor(expression);
            html.ScriptOnce(ComponentUtility.GetJsTag(typeahead_js, null));
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