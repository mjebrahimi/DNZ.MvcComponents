using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Microsoft.AspNetCore.Mvc
{
    public static class TagsInputHelper
    {
        public static TagsInputOption<TModel, TValue> TagsInputFor<TModel, TValue>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
        {
            return new TagsInputOption<TModel, TValue>(htmlHelper, expression, htmlAttributes);
        }

        public static TagsInputOption<TModel, TValue> TagsInputTypeaheadFor<TModel, TValue>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, string url, object htmlAttributes = null)
        {
            return new TagsInputOption<TModel, TValue>(htmlHelper, expression, htmlAttributes).AutoCompleteUrl(url);
        }

        public static TagsInputOption TagsInput(this IHtmlHelper htmlHelper, string expression, object htmlAttributes = null)
        {
            return new TagsInputOption(htmlHelper, expression, (string)null, htmlAttributes);
        }

        public static TagsInputOption TagsInput(this IHtmlHelper htmlHelper, string expression, string value, object htmlAttributes = null)
        {
            return new TagsInputOption(htmlHelper, expression, value, htmlAttributes);
        }

        public static TagsInputOption TagsInput(this IHtmlHelper htmlHelper, string expression, IEnumerable<string> values, object htmlAttributes = null)
        {
            return new TagsInputOption(htmlHelper, expression, values, htmlAttributes);
        }

        public static TagsInputOption TagsInputTypeahead(this IHtmlHelper htmlHelper, string expression, string url, object htmlAttributes = null)
        {
            return new TagsInputOption(htmlHelper, expression, (string)null, htmlAttributes).AutoCompleteUrl(url);
        }

        public static TagsInputOption TagsInputTypeahead(this IHtmlHelper htmlHelper, string expression, string value, string url, object htmlAttributes = null)
        {
            return new TagsInputOption(htmlHelper, expression, value, htmlAttributes).AutoCompleteUrl(url);
        }

        public static TagsInputOption TagsInputTypeahead(this IHtmlHelper htmlHelper, string expression, IEnumerable<string> values, string url, object htmlAttributes = null)
        {
            return new TagsInputOption(htmlHelper, expression, values, htmlAttributes).AutoCompleteUrl(url);
        }
    }
}
