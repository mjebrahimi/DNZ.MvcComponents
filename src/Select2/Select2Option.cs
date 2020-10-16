using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using DNZ.MvcComponents;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.AspNetCore.Mvc
{
    public class Select2Option : IOptionBuilder
    {
        public Dictionary<string, object> Attributes { get; set; }

        public Select2Option(bool isLtr = false)
        {
            Attributes = new Dictionary<string, object>();
            if (isLtr)
                Dir(Select2Direction.ltr).Language(Select2Language.en);
            else
                Dir(Select2Direction.rtl).Language(Select2Language.fa);
        }

        public Select2Option Tags(bool value)
        {
            Attributes["tags"] = value.ToString().ToLower();
            return this;
        }

        public Select2Option AllowClear(bool value)
        {
            Attributes["allowClear"] = value.ToString().ToLower();
            return this;
        }

        public Select2Option CreateSearchChoice(string value)
        {
            Attributes["createSearchChoice"] = value;
            return this;
        }

        public Select2Option CloseOnSelect(bool value)
        {
            Attributes["closeOnSelect"] = value.ToString().ToLower();
            return this;
        }

        public Select2Option MinimumSelectionLength(int value)
        {
            Attributes["minimumSelectionLength"] = value;
            return this;
        }

        public Select2Option MaximumSelectionLength(int value)
        {
            Attributes["maximumSelectionLength"] = value;
            return this;
        }

        public Select2Option MinimumInputLength(int value)
        {
            Attributes["minimumInputLength"] = value;
            return this;
        }

        public Select2Option MaximumInputLength(int value)
        {
            Attributes["maximumInputLength"] = value;
            return this;
        }

        public Select2Option MinimumResultsForSearch(int value)
        {
            Attributes["minimumResultsForSearch"] = value;
            return this;
        }

        public Select2Option DisableSearchInfinity()
        {
            Attributes["minimumResultsForSearch"] = "Infinity";
            return this;
        }

        public Select2Option Placeholder(string value)
        {
            Attributes["placeholder"] = string.Format("'{0}'", value);
            return this;
        }

        /// <summary>
        /// { id: "-1", text: "Select a repository" }
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Select2Option Placeholder(object value)
        {
            Attributes["placeholder"] = ComponentUtility.ToJsonStringWithoutQuotes(value);
            return this;
        }

        public Select2Option Ajax(Select2AjaxOption value)
        {
            Attributes["ajax"] = value.RenderOptions();
            return this;
        }

        public Select2Option EscapeMarkup(string value)
        {
            Attributes["escapeMarkup"] = value;
            return this;
        }

        public Select2Option Matcher(string value)
        {
            Attributes["matcher"] = value;
            return this;
        }

        /// <summary>
        /// function (repo) {
        ///     return repo.id || repo.text;
        /// }
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Select2Option TemplateResult(string value)
        {
            Attributes["templateResult"] = value;
            return this;
        }

        public Select2Option TemplateResult(HanderBarTemplate template)
        {
            var value = @"function (context) {
	                    return " + template.Render("context").ToHtmlString() + @";
                    }";
            return TemplateResult(value);
        }

        public Select2Option TemplateResultHanderBarTemplate(IHtmlHelper helper, string template)
        {
            var handlebars = helper.CreateHandlebarsTemplate(template);
            return TemplateResult(handlebars);
        }

        public Select2Option TemplateResultHanderBarTemplate(IHtmlHelper helper, Func<object, HelperResult> template)
        {
            var handlebars = helper.CreateHandlebarsTemplate(template);
            return TemplateResult(handlebars);
        }

        public Select2Option TemplateResultHanderBarTemplateInlineHelper(IHtmlHelper helper, HelperResult template)
        {
            var handlebars = helper.CreateHandlebarsTemplateInlineHelper(template);
            return TemplateResult(handlebars);
        }

        public Select2Option TemplateResultHanderBarTemplate(IHtmlHelper helper, string id, string template)
        {
            var handlebars = helper.CreateHandlebarsTemplate(id, template);
            return TemplateResult(handlebars);
        }

        public Select2Option TemplateResultHanderBarTemplate(IHtmlHelper helper, string id, Func<object, HelperResult> template)
        {
            var handlebars = helper.CreateHandlebarsTemplate(id, template);
            return TemplateResult(handlebars);
        }

        public Select2Option TemplateResultHanderBarTemplateInlineHelper(IHtmlHelper helper, string id, HelperResult template)
        {
            var handlebars = helper.CreateHandlebarsTemplateInlineHelper(id, template);
            return TemplateResult(handlebars);
        }

        public Select2Option TemplateSelection(string value)
        {
            Attributes["templateSelection"] = value;
            return this;
        }

        public Select2Option Data(string value)
        {
            Attributes["data"] = value;
            return this;
        }

        /// <summary>
        /// new[] { new { id = 1, name = "ali1" }, new { id = 2, name = "ali2" }, new { id = 3, name = "ali3" } }
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Select2Option Data(IEnumerable value)
        {
            Attributes["data"] = ComponentUtility.ToJsonStringWithoutQuotes(value);
            return this;
        }

        public Select2Option TokenSeparators(string value = "[',', ' ']")
        {
            Attributes["tokenSeparators"] = value;
            return this;
        }

        public Select2Option Dir(Select2Direction value)
        {
            Attributes["dir"] = string.Format("'{0}'", value);
            return this;
        }

        public Select2Option Language(Select2Language value)
        {
            Attributes["language"] = string.Format("'{0}'", value.ToString().Replace('_', '-'));
            return this;
        }
    }
}