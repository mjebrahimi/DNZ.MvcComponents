﻿using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Microsoft.AspNetCore.Routing;
using DNZ.MvcComponents;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Microsoft.AspNetCore.Mvc
{
    public static class TagAutocompleteHelper
    {
        private const string Bootstrap_Typeahead_js = "DNZ.MvcComponents.TagAutocomplete.bootstrap-typeahead.js";
        private const string Rangy_Core_js = "DNZ.MvcComponents.TagAutocomplete.rangy-core.js";
        private const string Caret_Position_js = "DNZ.MvcComponents.TagAutocomplete.caret-position.js";
        private const string Bootstrap_Tagautocomplete_js = "DNZ.MvcComponents.TagAutocomplete.bootstrap-tagautocomplete.js";

        public static IHtmlContent TagAutocompleteFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IEnumerable<string> source, object htmlAttributes = null)
        {
            TagAutocompleteOption option = new TagAutocompleteOption();
            if (source != null)
            {
                option.Source(source);
            }

            return html.TagAutocompleteFor(expression, option, htmlAttributes);
        }

        public static IHtmlContent TagAutocompleteFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IEnumerable<string> source, TagAutocompleteOption option, object htmlAttributes = null)
        {
            if (source != null)
            {
                option.Source(source);
            }

            return html.TagAutocompleteFor(expression, option, htmlAttributes);
        }

        public static IHtmlContent TagAutocompleteFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, TagAutocompleteOption option, object htmlAttributes = null)
        {
            ViewFeatures.ModelExplorer metadata = ExpressionMetadataProvider.FromLambdaExpression(expression, html.ViewData, html.MetadataProvider);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string id = html.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName);
            string divId = id + "_autotag";
            object value = metadata.Model ?? "";
            TagBuilder tag = new TagBuilder("div");
            tag.AddCssClass("form-control");
            tag.Attributes.Add("contenteditable", "true");
            tag.Attributes.Add("id", id + "_autotag");
            tag.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            tag.InnerHtml.SetContent(value.ToString());
            IHtmlContent editor = html.HiddenFor(expression);

            html.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(Bootstrap_Typeahead_js) + @"""></script>");
            html.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(Rangy_Core_js) + @"""></script>");
            html.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(Caret_Position_js) + @"""></script>");
            html.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(Bootstrap_Tagautocomplete_js) + @"""></script>");
            html.Script(@"
            <script>
                $(function(){
                    $(""#" + divId + @""").tagautocomplete(" + option.RenderOptions() + @");
                });
            </script>");
            return new HtmlString(tag.ToHtmlString() + "\n" + editor.ToHtmlString());
        }
    }
}