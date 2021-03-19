using DNZ.MvcComponents;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Microsoft.AspNetCore.Mvc
{
    public class TagsInputOption<TModel, TValue> : TagsInputOption
    {
        public TagsInputOption(IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
        {
            base.htmlHelper = htmlHelper.NotNull(nameof(htmlHelper));
            expression.NotNull(nameof(expression));
            id = htmlHelper.FieldIdFor(expression);

            var metadata = htmlHelper.GetModelExplorer(expression);
            if (metadata.ModelType == typeof(string))
            {
                element = htmlHelper.TextBoxFor(expression, htmlAttributes);
            }
            else if (typeof(IEnumerable).IsAssignableFrom(metadata.ModelType))
            {
                var items = ((IEnumerable)metadata.Model).Cast<object>().Select(p =>
                {
                    var value = p.ToString();
                    return new SelectListItem(value, value, true);
                });
                element = htmlHelper.ListBoxFor(expression, items, htmlAttributes);
            }
            else
            {
                throw new NotSupportedException("Only string and IEnumerable supported.");
            }
        }
    }

    public class TagsInputOption : BaseComponent, IOptionBuilder
    {
        //https://cdnjs.com/libraries/bootstrap-tagsinput
        //https://github.com/bootstrap-tagsinput/bootstrap-tagsinput
        //https://bootstrap-tagsinput.github.io/bootstrap-tagsinput/examples/
        //http://twitter.github.io/typeahead.js/
        //https://cdnjs.com/libraries/typeahead.js

        #region Constants
        private const string bootstrap_tagsinput_js_cdn = "<script src=\"https://cdnjs.cloudflare.com/ajax/libs/bootstrap-tagsinput/0.7.0/bootstrap-tagsinput.min.js\" integrity=\"sha512-eM7U+fzjIs4UM7Uf93WPqt2ObmZ9cQ2VmfhbU91L98+CCV158gDUvsrXUCJcxDewYSTfcuB1INU7arzDKO4jvw==\" crossorigin=\"anonymous\"></script>";
        //typeahead.bundle.min.js = typeahead.jquery.min.js + bloodhound.min.js
        private const string typeahead_bundle_js_cdn = "<script src=\"https://cdnjs.cloudflare.com/ajax/libs/typeahead.js/0.11.1/typeahead.bundle.min.js\" integrity=\"sha512-qOBWNAMfkz+vXXgbh0Wz7qYSLZp6c14R0bZeVX2TdQxWpuKr6yHjBIM69fcF8Ve4GUX6B6AKRQJqiiAmwvmUmQ==\" crossorigin=\"anonymous\"></script>";
        private const string bootstrap_tagsinput_css_cdn = "<link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/bootstrap-tagsinput/0.7.0/bootstrap-tagsinput.css\" integrity=\"sha512-3uVpgbpX33N/XhyD3eWlOgFVAraGn3AfpxywfOTEQeBDByJ/J7HkLvl4mJE1fvArGh4ye1EiPfSBnJo2fgfZmg==\" crossorigin=\"anonymous\" />";
        private const string bootstrap_tagsinput_typeahead_css_cdn = "<link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/bootstrap-tagsinput/0.7.0/bootstrap-tagsinput-typeahead.css\" integrity=\"sha512-VcBOcE2uJNcryzSnSWRAS6cgD9oRLg31lefaEVKVu+FPNtuTd4+i0GjbXFBKCuEXWqELTYIDa8zLZZSANrgHCg==\" crossorigin=\"anonymous\" />";
        private const string bootstrap_tagsinput_js = "DNZ.MvcComponents.TagsInput.js.bootstrap-tagsinput.min.js";
        private const string typeahead_bundle_js = "DNZ.MvcComponents.TagsInput.js.typeahead.bundle.min.js";
        private const string bootstrap_tagsinput_css = "DNZ.MvcComponents.TagsInput.css.bootstrap-tagsinput.min.css";
        private const string bootstrap_tagsinput_typeahead_css = "DNZ.MvcComponents.TagsInput.css.bootstrap-tagsinput-typeahead.min.css";
        #endregion

        public Dictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();
        public string AutoCompleteUrl;
        protected IHtmlContent element;
        protected IHtmlHelper htmlHelper;
        protected string id;

        protected TagsInputOption()
        {
        }

        public TagsInputOption(IHtmlHelper htmlHelper, string expression, string value, object htmlAttributes)
        {
            expression.NotNull(nameof(expression));
            this.htmlHelper = htmlHelper.NotNull(nameof(htmlHelper));
            id = htmlHelper.GenerateIdFromName(expression);
            element = htmlHelper.TextBox(expression, value, htmlAttributes);
        }

        public TagsInputOption(IHtmlHelper htmlHelper, string expression, IEnumerable<string> values, object htmlAttributes)
        {
            expression.NotNull(nameof(expression));
            this.htmlHelper = htmlHelper.NotNull(nameof(htmlHelper));
            id = htmlHelper.GenerateIdFromName(expression);
            var items = values.Cast<object>().Select(p =>
            {
                var value = p.ToString();
                return new SelectListItem(value, value, true);
            });
            element = htmlHelper.ListBox(expression, items, htmlAttributes);
        }

        public override string ToHtmlString()
        {
            htmlHelper.StyleOnce(ComponentUtility.GetCssTag(bootstrap_tagsinput_css, null/*bootstrap_tagsinput_css_cdn*/));

            string bloodhound = null;
            if (AutoCompleteUrl != null)
            {
                Attributes["typeaheadjs"] = "{ name: 'bloodhound', displayKey: 'name', valueKey: 'name', source: bloodhound.ttAdapter() }";
                bloodhound = @"
                var bloodhound = new Bloodhound({
	                datumTokenizer: Bloodhound.tokenizers.obj.whitespace('name'),
	                queryTokenizer: Bloodhound.tokenizers.whitespace,
	                //prefetch: '" + AutoCompleteUrl + @"'
	                prefetch: {
	                	url: '" + AutoCompleteUrl + @"',
	                    filter: function(list) {
	                	  return $.map(list, function(name) {
	                	    return { name: name }; 
	                	  });
	                	}
	                }
                });
                bloodhound.initialize();";


                htmlHelper.StyleOnce(ComponentUtility.GetCssTag(bootstrap_tagsinput_typeahead_css, bootstrap_tagsinput_typeahead_css_cdn));
                htmlHelper.ScriptOnce(ComponentUtility.GetJsTag(typeahead_bundle_js, typeahead_bundle_js_cdn));
            }

            htmlHelper.ScriptOnce(ComponentUtility.GetJsTag(bootstrap_tagsinput_js, bootstrap_tagsinput_js_cdn));

            htmlHelper.Script(@"
            <script>
                $(function(){
                    " + bloodhound + @"
                    $(""#" + id + @""").tagsinput(" + this.RenderOptions() + @");
                });
            </script>");
            return element.ToHtmlString();
        }
    }
}
