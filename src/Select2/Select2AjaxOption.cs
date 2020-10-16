using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using DNZ.MvcComponents;
using System.Collections.Generic;

namespace Microsoft.AspNetCore.Mvc
{
    public class Select2AjaxOption : IOptionBuilder
    {
        public Dictionary<string, object> Attributes { get; set; }

        private readonly IHtmlHelper _htmlHelper;

        public Select2AjaxOption(IHtmlHelper htmlHelper)
        {
            Attributes = new Dictionary<string, object>();
            _htmlHelper = htmlHelper;
        }

        public Select2AjaxOption Delay(int value)
        {
            Attributes["delay"] = value;
            return this;
        }

        public Select2AjaxOption Data(string value = "function (params) { return { term: params.term, page: params.page }; }")
        {
            Attributes["data"] = value;
            return this;
        }

        public Select2AjaxOption Cache(bool value)
        {
            Attributes["cache"] = value.ToString().ToLower();
            return this;
        }

        public Select2AjaxOption DataType(AjaxDataType value)
        {
            Attributes["dataType"] = string.Format("'{0}'", value.ToString().ToLower());
            return this;
        }

        public Select2AjaxOption ProcessResults(string value)
        {
            Attributes["processResults"] = value;
            return this;
        }

        public Select2AjaxOption Url(string value)
        {
            Attributes["url"] = string.Format("'{0}'", value);
            return this;
        }

        public Select2AjaxOption UrlAction(string action)
        {
            var urlHelper = _htmlHelper.GetUrlHelper();
            var url = urlHelper.Action(new UrlActionContext { Action = action });
            Url(url);
            return this;
        }

        public Select2AjaxOption UrlAction(string action, object routeValues)
        {
            var urlHelper = _htmlHelper.GetUrlHelper();
            var url = urlHelper.Action(new UrlActionContext { Action = action, Values = routeValues });
            Url(url);
            return this;
        }

        public Select2AjaxOption UrlAction(string action, RouteValueDictionary routeValues)
        {
            var urlHelper = _htmlHelper.GetUrlHelper();
            var url = urlHelper.Action(new UrlActionContext { Action = action, Values = routeValues });
            Url(url);
            return this;
        }

        public Select2AjaxOption UrlAction(string action, string controller)
        {
            var urlHelper = _htmlHelper.GetUrlHelper();
            var url = urlHelper.Action(new UrlActionContext { Action = action, Controller = controller });
            Url(url);
            return this;
        }

        public Select2AjaxOption UrlAction(string action, string controller, object routeValues)
        {
            var urlHelper = _htmlHelper.GetUrlHelper();
            var url = urlHelper.Action(new UrlActionContext { Action = action, Controller = controller, Values = routeValues });
            Url(url);
            return this;
        }

        public Select2AjaxOption UrlAction(string action, string controller, RouteValueDictionary routeValues)
        {
            var urlHelper = _htmlHelper.GetUrlHelper();
            var url = urlHelper.Action(new UrlActionContext { Action = action, Controller = controller, Values = routeValues });
            Url(url);
            return this;
        }
    }
}