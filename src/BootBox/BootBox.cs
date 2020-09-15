using Microsoft.AspNetCore.Mvc.Rendering;
using DNZ.MvcComponents;
using System.Collections.Generic;

namespace Microsoft.AspNetCore.Mvc
{
    public class BootBox : MessageBoxResult
    {
        private const string bootbox_js = "DNZ.MvcComponents.BootBox.bootbox.js";
        private int indexButton;
        private BootBoxType type;
        public Dictionary<string, object> ButtonAttributes { get; set; }

        public BootBox(IHtmlHelper helper = null) : base(helper)
        {
            RenderScriptAndStyle.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(bootbox_js) + @"""></script>");
            ButtonAttributes = new Dictionary<string, object>();
        }

        public BootBox Message(string value)
        {
            Attributes["message"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public BootBox Title(string value)
        {
            Attributes["title"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public BootBox Value(string value)
        {
            Attributes["value"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public BootBox AddButton(string label, string callback, string className = null)
        {
            indexButton++;
            string str = @"{
                    label: '" + label + @"',
                    " + (string.IsNullOrEmpty(className) ? "" : "className: '" + className + "',") + @"
                    callback: " + callback + @"
                }";
            ButtonAttributes.Add("button" + indexButton, str);
            SetScript();
            return this;
        }

        public BootBox Callback(string value)
        {
            Attributes["callback"] = value;
            SetScript();
            return this;
        }

        public BootBox Type(BootBoxType type)
        {
            if (!Attributes.ContainsKey("message"))
            {
                Message("Message");
            }

            if (!Attributes.ContainsKey("callback"))
            {
                Callback("function(result) { }");
            }

            this.type = type;
            SetScript();
            return this;
        }

        protected void SetScript()
        {
            if (ButtonAttributes.Count > 0)
            {
                Attributes["buttons"] = ButtonAttributes.RenderOptions();
            }

            Script = @"bootbox." + type.ToString().ToLower() + "(" + this.RenderOptions() + ");";
            if (!ComponentUtility.GetHttpContext().Request.IsAjaxRequest() && HtmlHelper == null)
            {
                SetScriptTag();
            }
        }
    }
}