using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using DNZ.MvcComponents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.AspNetCore.Mvc
{
    public class Tooltip : MessageBoxResult
    {
        private string id;
        private string method;
        public Dictionary<string, object> Options { get; set; }

        public Tooltip(string id = null, IHtmlHelper helper = null) : base(helper)
        {
            this.id = string.IsNullOrEmpty(id) ? System.Guid.NewGuid().ToString() : id;
            Options = new Dictionary<string, object>();
        }

        public Tooltip Id(string value)
        {
            id = value;
            SetScript();
            return this;
        }

        public Tooltip Show()
        {
            method = "show";
            SetScript();
            return this;
        }

        public Tooltip Toggle()
        {
            method = "toggle";
            SetScript();
            return this;
        }

        public Tooltip Hide()
        {
            method = "hide";
            SetScript();
            return this;
        }

        public Tooltip Destroy()
        {
            method = "destroy";
            SetScript();
            return this;
        }

        public Tooltip OnShow(string value)
        {
            Attributes["show.bs.tooltip"] = value;
            SetScript();
            return this;
        }

        public Tooltip OnShown(string value)
        {
            Attributes["shown.bs.tooltip"] = value;
            SetScript();
            return this;
        }

        public Tooltip OnHide(string value)
        {
            Attributes["hide.bs.tooltip"] = value;
            SetScript();
            return this;
        }

        public Tooltip OnHidden(string value)
        {
            Attributes["hidden.bs.tooltip"] = value;
            SetScript();
            return this;
        }

        public Tooltip OnLoaded(string value)
        {
            Attributes["inserted.bs.tooltip"] = value;
            SetScript();
            return this;
        }

        public Tooltip Animation(bool value)
        {
            Options["animation"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public Tooltip Container(string value)
        {
            Options["container"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public Tooltip Delay(int value)
        {
            Options["delay"] = value;
            SetScript();
            return this;
        }

        public Tooltip Html(bool value)
        {
            Options["html"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public Tooltip Placement(Placement value)
        {
            Options["placement"] = string.Format("'{0}'", value.ToString().ToLower());
            SetScript();
            return this;
        }

        public Tooltip Selector(bool value)
        {
            Options["selector"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public Tooltip Template(string value)
        {
            Options["template"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public Tooltip Template(Func<object, HelperResult> template)
        {
            Options["template"] = template(null).ToHtmlString().ToJavaScriptString();
            SetScript();
            return this;
        }

        public Tooltip Trigger(Trigger value)
        {
            var list = new List<string>();
            if (value.HasFlag(Mvc.Trigger.Click))
            {
                list.Add("click");
            }

            if (value.HasFlag(Mvc.Trigger.Focus))
            {
                list.Add("focus");
            }

            if (value.HasFlag(Mvc.Trigger.Hover))
            {
                list.Add("hover");
            }

            if (value.HasFlag(Mvc.Trigger.MouseOver))
            {
                list.Add("mouseover");
            }

            Options["trigger"] = string.Format("'{0}'", string.Join(" ", list));
            SetScript();
            return this;
        }

        public Tooltip Viewport(string value)
        {
            Options["viewport"] = value;
            SetScript();
            return this;
        }

        protected void SetScript()
        {
            var script = "";
            if (Options.Count > 0)
            {
                script += ".tooltip(" + Options.RenderOptions() + ")";
            }

            if (method.HasValue())
            {
                script += ".tooltip('" + method + "')";
            }

            script += string.Concat(Attributes.Select(p => ".on('" + p.Key + "', " + p.Value + ")"));
            Script = script == "" ? "" : "$('#" + id + "')" + script;
            if (!ComponentUtility.GetHttpContext().Request.IsAjaxRequest() && HtmlHelper == null)
            {
                SetScriptTag();
            }
        }
    }
}