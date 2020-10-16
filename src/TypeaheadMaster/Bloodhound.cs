using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using DNZ.MvcComponents;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;

namespace Microsoft.AspNetCore.Mvc
{
    public class Bloodhound : IOptionBuilder, IHtmlContent, IScript
    {
        public Dictionary<string, object> Attributes { get; set; }

        private readonly HttpContext _httpContext;

        public Bloodhound()
        {
            _httpContext = ComponentUtility.GetHttpContext();
            Attributes = new Dictionary<string, object>();
            DatumTokenizer();
            QueryTokenizer();
        }

        public Bloodhound DatumTokenizer(string value = "whitespace")
        {
            Attributes["datumTokenizer"] = "Bloodhound.tokenizers." + value;
            return this;
        }

        public Bloodhound QueryTokenizer(string value = "whitespace")
        {
            Attributes["queryTokenizer"] = "Bloodhound.tokenizers." + value;
            return this;
        }

        public Bloodhound Local(string value)
        {
            Attributes["local"] = value;
            return this;
        }

        public Bloodhound Local(IEnumerable<string> source)
        {
            var value = ComponentUtility.ToJsonString(source);
            Attributes["local"] = value;
            return this;
        }

        public Bloodhound Prefetch(string url)
        {
            Attributes["prefetch"] = "\"" + url + "\"";
            return this;
        }

        public Bloodhound RemoteUrl(string url)
        {
            var urlWithQuery = "";
            if (url.Contains("{0}")) //compatibel with "../%QUERY.json"
            {
                urlWithQuery = string.Format(url, "%QUERY");
            }
            else
            {
                urlWithQuery = url.Contains("?") ? url : url.TrimEnd('/') + '/' + "%QUERY";
            }

            var result = @"{
                    url: """ + urlWithQuery + @""",
                    wildcard: '%QUERY'
                }";
            Attributes["remote"] = result;
            return this;
        }

        public Bloodhound RemoteUrlAction(string action)
        {
            var urlHelper = _httpContext.GetUrlHelper();
            var url = urlHelper.Action(new UrlActionContext { Action = action });
            RemoteUrl(url);
            return this;
        }

        public Bloodhound RemoteUrlAction(string action, object routeValues)
        {
            var urlHelper = _httpContext.GetUrlHelper();
            var url = urlHelper.Action(new UrlActionContext { Action = action, Values = routeValues });
            RemoteUrl(url);
            return this;
        }

        public Bloodhound RemoteUrlAction(string action, RouteValueDictionary routeValues)
        {
            var urlHelper = _httpContext.GetUrlHelper();
            var url = urlHelper.Action(new UrlActionContext { Action = action, Values = routeValues });
            RemoteUrl(url);
            return this;
        }

        public Bloodhound RemoteUrlAction(string action, string controller)
        {
            var urlHelper = _httpContext.GetUrlHelper();
            var url = urlHelper.Action(new UrlActionContext { Action = action, Controller = controller });
            RemoteUrl(url);
            return this;
        }

        public Bloodhound RemoteUrlAction(string action, string controller, object routeValues)
        {
            var urlHelper = _httpContext.GetUrlHelper();
            var url = urlHelper.Action(new UrlActionContext { Action = action, Controller = controller, Values = routeValues });
            RemoteUrl(url);
            return this;
        }

        public Bloodhound RemoteUrlAction(string action, string controller, RouteValueDictionary routeValues)
        {
            var urlHelper = _httpContext.GetUrlHelper();
            var url = urlHelper.Action(new UrlActionContext { Action = action, Controller = controller, Values = routeValues });
            RemoteUrl(url);
            return this;
        }

        public string ToHtmlString()
        {
            return "";
        }

        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            writer.Write(ToHtmlString());
        }

        public string Script => string.Format("new Bloodhound({0})", this.RenderOptions());
    }
}