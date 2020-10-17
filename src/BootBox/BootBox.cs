using Microsoft.AspNetCore.Mvc.Rendering;
using DNZ.MvcComponents;
using System.Collections.Generic;

namespace Microsoft.AspNetCore.Mvc
{
    public class BootBox : MessageBoxResult
    {
        //http://bootboxjs.com/
        //https://cdnjs.com/libraries/bootbox.js
        private const string bootbox_js_cdn = "<script src=\"https://cdnjs.cloudflare.com/ajax/libs/bootbox.js/5.4.1/bootbox.min.js\" integrity=\"sha512-eoo3vw71DUo5NRvDXP/26LFXjSFE1n5GQ+jZJhHz+oOTR4Bwt7QBCjsgGvuVMQUMMMqeEvKrQrNEI4xQMXp3uA==\" crossorigin=\"anonymous\"></script>";
        private const string bootbox_js = "DNZ.MvcComponents.BootBox.bootbox.js";
        private int indexButton;
        private BootBoxType type;
        public Dictionary<string, object> ButtonAttributes { get; set; }

        public BootBox(IHtmlHelper helper = null) : base(helper)
        {
            RenderScriptAndStyle.ScriptFileSingle(ComponentUtility.GetJsTag(bootbox_js, bootbox_js_cdn));
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
            var str = @"{
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

            Script = $"bootbox.{type.ToString().ToLower()}({this.RenderOptions()});";
            if (!ComponentUtility.GetHttpContext().Request.IsAjaxRequest() && HtmlHelper == null)
            {
                SetScriptTag();
            }
        }
    }
}