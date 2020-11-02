using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using DNZ.MvcComponents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.AspNetCore.Mvc
{
    public class BsDialog : MessageBoxResult
    {
        //http://nakupanda.github.io/bootstrap3-dialog
        //https://cdnjs.com/libraries/bootstrap3-dialog
        private const string BsDialog_css_cdn = "<link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/bootstrap3-dialog/1.35.4/css/bootstrap-dialog.min.css\" integrity=\"sha512-PvZCtvQ6xGBLWHcXnyHD67NTP+a+bNrToMsIdX/NUqhw+npjLDhlMZ/PhSHZN4s9NdmuumcxKHQqbHlGVqc8ow==\" crossorigin=\"anonymous\" />";
        private const string BsDialog_js_cdn = "<script src=\"https://cdnjs.cloudflare.com/ajax/libs/bootstrap3-dialog/1.35.4/js/bootstrap-dialog.min.js\" integrity=\"sha512-LbO5ZwEjd9FPp4KVKsS6fBk2RRvKcXYcsHatEapmINf8bMe9pONiJbRWTG9CF/WDzUig99yvvpGb64dNQ27Y4g==\" crossorigin=\"anonymous\"></script>";
        private const string BsDialog_min_css = "DNZ.MvcComponents.BsDialog.css.bootstrap-dialog.min.css";
        private const string BsDialog_min_js = "DNZ.MvcComponents.BsDialog.js.bootstrap-dialog.min.js";
        private string method = "";

        public Dictionary<string, object> ButtonAttributes { get; set; }

        public BsDialog(IHtmlHelper helper = null) : base(helper)
        {
            ButtonAttributes = new Dictionary<string, object>();
            RenderScriptAndStyle.StyleOnce(ComponentUtility.GetCssTag(BsDialog_min_css, BsDialog_css_cdn));
            RenderScriptAndStyle.ScriptOnce(ComponentUtility.GetJsTag(BsDialog_min_js, BsDialog_js_cdn));
            Method(BsMethod.Show);
        }

        public BsDialog Type(DialogType type)
        {
            Attributes["type"] = string.Format("BootstrapDialog.TYPE_{0}", type.ToString().ToUpper());
            SetScript();
            return this;
        }

        public BsDialog Size(BsDialogSize size)
        {
            Attributes["size"] = string.Format("BootstrapDialog.SIZE_{0}", size.ToString().ToUpper());
            SetScript();
            return this;
        }

        public BsDialog Title(string value)
        {
            Attributes["title"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public BsDialog Message(string value)
        {
            Attributes["message"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public BsDialog Message(Func<object, HelperResult> template)
        {
            Attributes["message"] = template(null).ToHtmlString().ToJavaScriptString();
            SetScript();
            return this;
        }

        public BsDialog MessageByUrl(string url)
        {
            Attributes["message"] = string.Format("$('<div></div>').load('{0}')", url);
            SetScript();
            return this;
        }

        public BsDialog MessageById(string id)
        {
            Attributes["message"] = string.Format("$('<div>').append($('#{0}').clone()).html();", id);
            SetScript();
            return this;
        }

        public BsDialog MessageByFunc(string value)
        {
            Attributes["message"] = value;
            SetScript();
            return this;
        }

        public BsDialog OnShow(string value)
        {
            Attributes["onshow"] = value;
            SetScript();
            return this;
        }

        public BsDialog OnShown(string value)
        {
            Attributes["onshown"] = value;
            SetScript();
            return this;
        }

        public BsDialog OnHide(string value)
        {
            Attributes["onhide"] = value;
            SetScript();
            return this;
        }

        public BsDialog OnHidden(string value)
        {
            Attributes["onhidden"] = value;
            SetScript();
            return this;
        }

        public BsDialog SpinIcon(string value)
        {
            Attributes["spinicon"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public BsDialog Data(object value)
        {
            Attributes["data"] = ComponentUtility.ToJsonString(value);
            SetScript();
            return this;
        }

        public BsDialog CssClass(string value)
        {
            Attributes["cssClass"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public BsDialog ButtonLabel(string value)
        {
            Attributes["buttonLabel"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public BsDialog BtnCancelLabel(string value)
        {
            Attributes["btnCancelLabel"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public BsDialog BtnOKLabel(string value)
        {
            Attributes["btnOKLabel"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public BsDialog ButtonClass(string value)
        {
            Attributes["buttonClass"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public BsDialog BtnCancelClass(string value)
        {
            Attributes["btnCancelClass"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public BsDialog BtnOKClass(string value)
        {
            Attributes["btnOKClass"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public BsDialog CallBack(string value)
        {
            Attributes["callback"] = value;
            SetScript();
            return this;
        }

        public BsDialog Closable(bool value)
        {
            Attributes["closable"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public BsDialog Draggable(bool value)
        {
            Attributes["draggable"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public BsDialog Method(BsMethod value)
        {
            method = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public BsDialog AddButton(string label, string action, string cssClass = null, int hotkey = 0, string icon = null, bool? autospin = null)
        {
            var str = @"{
            label: '" + label + @"',
            " + (hotkey == 0 ? "" : "hotkey: " + hotkey + ",") + @"
            " + (string.IsNullOrEmpty(cssClass) ? "" : "cssClass: '" + cssClass + "',") + @"
            " + (string.IsNullOrEmpty(icon) ? "" : "icon: '" + icon + "',") + @"
            " + (autospin == null ? "" : "autospin: '" + autospin + "',") + @"
            action: " + action + @"
        }";
            ButtonAttributes.Add("", str);
            SetScript();
            return this;
        }

        protected void SetScript()
        {
            if (ButtonAttributes.Count > 0)
                Attributes["buttons"] = "[\n" + string.Join(", \n", ButtonAttributes.Select(p => p.Value)) + "\n]";

            Script = $"BootstrapDialog.{method}({this.RenderOptions()})";
            if (!ComponentUtility.GetHttpContext().Request.IsAjaxRequest() && HtmlHelper == null)
                SetScriptTag();
        }
    }
}
