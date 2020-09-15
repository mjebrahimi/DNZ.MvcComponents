using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using DNZ.MvcComponents;
using System;
using System.Collections.Generic;

namespace Microsoft.AspNetCore.Mvc
{
    public class TypeaheadMasterTemplate : IOptionBuilder
    {
        public Dictionary<string, object> Attributes { get; set; }

        public TypeaheadMasterTemplate()
        {
            Attributes = new Dictionary<string, object>();
        }

        public TypeaheadMasterTemplate NotFound(string value)
        {
            Attributes["notFound"] = string.Format("'{0}'", value);
            return this;
        }

        public TypeaheadMasterTemplate Empty(string value)
        {
            Attributes["empty"] = string.Format("'{0}'", value);
            return this;
        }

        public TypeaheadMasterTemplate Pending(string value)
        {
            Attributes["pending"] = string.Format("'{0}'", value);
            return this;
        }

        public TypeaheadMasterTemplate Header(string value)
        {
            Attributes["header"] = string.Format("'{0}'", value);
            return this;
        }

        public TypeaheadMasterTemplate Footer(string value)
        {
            Attributes["footer"] = string.Format("'{0}'", value);
            return this;
        }

        public TypeaheadMasterTemplate NotFound(Func<object, HelperResult> template)
        {
            Attributes["notFound"] = template(null).ToHtmlString().ToJavaScriptString();
            return this;
        }

        public TypeaheadMasterTemplate Empty(Func<object, HelperResult> template)
        {
            Attributes["empty"] = template(null).ToHtmlString().ToJavaScriptString();
            return this;
        }

        public TypeaheadMasterTemplate Pending(Func<object, HelperResult> template)
        {
            Attributes["pending"] = template(null).ToHtmlString().ToJavaScriptString();
            return this;
        }

        public TypeaheadMasterTemplate Header(Func<object, HelperResult> template)
        {
            Attributes["header"] = template(null).ToHtmlString().ToJavaScriptString();
            return this;
        }

        public TypeaheadMasterTemplate Footer(Func<object, HelperResult> template)
        {
            Attributes["footer"] = template(null).ToHtmlString().ToJavaScriptString();
            return this;
        }

        public TypeaheadMasterTemplate NotFound(HelperResult template)
        {
            Attributes["notFound"] = template.ToHtmlString().ToJavaScriptString();
            return this;
        }

        public TypeaheadMasterTemplate Empty(HelperResult template)
        {
            Attributes["empty"] = template.ToHtmlString().ToJavaScriptString();
            return this;
        }

        public TypeaheadMasterTemplate Pending(HelperResult template)
        {
            Attributes["pending"] = template.ToHtmlString().ToJavaScriptString();
            return this;
        }

        public TypeaheadMasterTemplate Header(HelperResult template)
        {
            Attributes["header"] = template.ToHtmlString().ToJavaScriptString();
            return this;
        }

        public TypeaheadMasterTemplate Footer(HelperResult template)
        {
            Attributes["footer"] = template.ToHtmlString().ToJavaScriptString();
            return this;
        }

        public TypeaheadMasterTemplate Suggestion(string value)
        {
            Attributes["suggestion"] = value;
            return this;
        }

        public TypeaheadMasterTemplate Suggestion(HanderBarTemplate template)
        {
            string value = template.Script;
            return Suggestion(value);
        }

        public TypeaheadMasterTemplate SuggestionHanderBarTemplate(IHtmlHelper helper, string template)
        {
            HanderBarTemplate handlebars = helper.CreateHandlebarsTemplate(template);
            return Suggestion(handlebars);
        }

        public TypeaheadMasterTemplate SuggestionHanderBarTemplate(IHtmlHelper helper, Func<object, HelperResult> template)
        {
            HanderBarTemplate handlebars = helper.CreateHandlebarsTemplate(template);
            return Suggestion(handlebars);
        }

        public TypeaheadMasterTemplate SuggestionHanderBarTemplateInlineHelper(IHtmlHelper helper, HelperResult template)
        {
            HanderBarTemplate handlebars = helper.CreateHandlebarsTemplateInlineHelper(template);
            return Suggestion(handlebars);
        }

        public TypeaheadMasterTemplate SuggestionHanderBarTemplate(IHtmlHelper helper, string id, string template)
        {
            HanderBarTemplate handlebars = helper.CreateHandlebarsTemplate(id, template);
            return Suggestion(handlebars);
        }

        public TypeaheadMasterTemplate SuggestionHanderBarTemplate(IHtmlHelper helper, string id, Func<object, HelperResult> template)
        {
            HanderBarTemplate handlebars = helper.CreateHandlebarsTemplate(id, template);
            return Suggestion(handlebars);
        }

        public TypeaheadMasterTemplate SuggestionHanderBarTemplateInlineHelper(IHtmlHelper helper, string id, HelperResult template)
        {
            HanderBarTemplate handlebars = helper.CreateHandlebarsTemplateInlineHelper(id, template);
            return Suggestion(handlebars);
        }
    }
}