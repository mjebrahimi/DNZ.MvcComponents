using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using DNZ.MvcComponents;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Microsoft.AspNetCore.Mvc
{
    public static class TagAutocompleteHelper
    {
        //https://blog.sandglaz.com/bootstrap-tagautocomplete/
        //https://getbootstrap.com/2.3.2/javascript.html#typeahead
        //Bootstrap-3-Typeahead
        //https://github.com/bassjobsen/Bootstrap-3-Typeahead
        //https://cdnjs.com/libraries/bootstrap-3-typeahead
        //Caret.js
        //https://github.com/ichord/Caret.js
        //https://cdnjs.com/libraries/Caret.js
        //rangy
        //https://github.com/timdown/rangy
        //https://cdnjs.com/libraries/rangy

        private const string Bootstrap_Typeahead_js = "DNZ.MvcComponents.TagAutocomplete.bootstrap-typeahead.js";
        private const string Rangy_Core_js = "DNZ.MvcComponents.TagAutocomplete.rangy-core.js";
        private const string Caret_Position_js = "DNZ.MvcComponents.TagAutocomplete.caret-position.js";
        private const string Bootstrap_Tagautocomplete_js = "DNZ.MvcComponents.TagAutocomplete.bootstrap-tagautocomplete.js";

        public static IHtmlContent TagAutocompleteFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IEnumerable<string> source, object htmlAttributes = null)
        {
            var option = new TagAutocompleteOption();
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
            var metadata = html.GetModelExplorer(expression);
            var htmlFieldName = html.FieldNameFor(expression);
            var id = html.FieldIdFor(expression);
            var divId = id + "_autotag";
            var value = metadata.Model ?? "";
            var tag = new TagBuilder("div");
            tag.AddCssClass("form-control");
            tag.Attributes.Add("contenteditable", "true");
            tag.Attributes.Add("id", id + "_autotag");
            tag.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            tag.InnerHtml.SetContent(value.ToString());
            var editor = html.HiddenFor(expression);

            html.ScriptFileSingle(ComponentUtility.GetJsTag(Bootstrap_Typeahead_js, null));
            html.ScriptFileSingle(ComponentUtility.GetJsTag(Rangy_Core_js, null));
            html.ScriptFileSingle(ComponentUtility.GetJsTag(Caret_Position_js, null));
            html.ScriptFileSingle(ComponentUtility.GetJsTag(Bootstrap_Tagautocomplete_js, null));
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