using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using DNZ.MvcComponents;
using System;

namespace Microsoft.AspNetCore.Mvc
{
    public class Toastr : MessageBoxResult
    {
        private const string toastr_css = "DNZ.MvcComponents.Toastr.toastr.min.css";
        private const string toastr_js = "DNZ.MvcComponents.Toastr.toastr.min.js";
        private string type = string.Format("'{0}'", nameof(ToastrType.Info).ToLower());
        private string title = "''";
        private string text = "''";

        public Toastr(IHtmlHelper helper = null) : base(helper)
        {
            RenderScriptAndStyle.StyleFileSingle(@"<link href=""" + ComponentUtility.GetWebResourceUrl(toastr_css) + @""" rel=""stylesheet"" />");
            RenderScriptAndStyle.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(toastr_js) + @"""></script>");
        }

        public Toastr Title(string value)
        {
            title = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public Toastr Title(Func<object, HelperResult> template)
        {
            title = template(null).ToHtmlString().ToJavaScriptString();
            SetScript();
            return this;
        }

        public Toastr Text(string value)
        {
            text = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public Toastr Text(Func<object, HelperResult> template)
        {
            text = template(null).ToHtmlString().ToJavaScriptString();
            SetScript();
            return this;
        }

        public Toastr Type(ToastrType type)
        {
            this.type = string.Format("'{0}'", type.ToString().ToLower());
            SetScript();
            return this;
        }

        public Toastr CloseButton(bool value)
        {
            Attributes["closeButton"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public Toastr Debug(bool value)
        {
            Attributes["debug"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public Toastr NewestOnTop(bool value)
        {
            Attributes["newestOnTop"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public Toastr ProgressBar(bool value)
        {
            Attributes["progressBar"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public Toastr PreventDuplicates(bool value)
        {
            Attributes["preventDuplicates"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public Toastr TapToDismiss(bool value)
        {
            Attributes["tapToDismiss"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public Toastr PositionClass(ToastrAlignment value)
        {
            Attributes["positionClass"] = string.Format("'{0}'", value.ToDescription());
            SetScript();
            return this;
        }

        public Toastr OnClick(string value)
        {
            Attributes["onclick"] = value;
            SetScript();
            return this;
        }

        public Toastr OnShown(string value)
        {
            Attributes["onShown"] = value;
            SetScript();
            return this;
        }

        public Toastr OnHidden(string value)
        {
            Attributes["onHidden"] = value;
            SetScript();
            return this;
        }

        public Toastr ShowDuration(int value)
        {
            Attributes["showDuration"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public Toastr HideDuration(int value)
        {
            Attributes["hideDuration"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public Toastr TimeOut(int value)
        {
            Attributes["timeOut"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public Toastr ExtendedTimeOut(int value)
        {
            Attributes["extendedTimeOut"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public Toastr ShowEasing(string value)
        {
            Attributes["showEasing"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public Toastr HideEasing(string value)
        {
            Attributes["hideEasing"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public Toastr ShowMethod(string value)
        {
            Attributes["showMethod"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public Toastr HideMethod(string value)
        {
            Attributes["hideMethod"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public Toastr CloseMethod(string value)
        {
            Attributes["closeMethod"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public Toastr CloseEasing(string value)
        {
            Attributes["closeEasing"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        protected void SetScript()
        {
            Script = "toastr[" + type + "](" + text + ", " + title + ", " + this.RenderOptions() + ")";
            if (!ComponentUtility.GetHttpContext().Request.IsAjaxRequest() && HtmlHelper == null)
            {
                SetScriptTag();
            }
        }
    }
}