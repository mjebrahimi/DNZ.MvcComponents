using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using DNZ.MvcComponents;
using System;

namespace Microsoft.AspNetCore.Mvc
{
    public class SweetAlert : MessageBoxResult
    {
        //https://sweetalert.js.org/
        //https://cdnjs.com/libraries/sweetalert
        //sweetalert2
        //https://sweetalert2.github.io/
        //https://cdnjs.com/libraries/limonte-sweetalert2
        private const string sweetalert_js_cdn = "<script src=\"https://cdnjs.cloudflare.com/ajax/libs/sweetalert/2.1.2/sweetalert.min.js\" integrity=\"sha512-AA1Bzp5Q0K1KanKKmvN/4d3IRKVlv9PYgwFPvm32nPO6QS8yH1HO7LbgB1pgiOxPtfeg5zEn2ba64MUcqJx6CA==\" crossorigin=\"anonymous\"></script>";
        //private const string sweetalert_css = "DNZ.MvcComponents.SweetAlert.sweetalert.css";
        private const string sweetalert_js = "DNZ.MvcComponents.SweetAlert.sweetalert-dev.js";

        private string function;

        public SweetAlert(IHtmlHelper helper = null) : base(helper)
        {
            //RenderScriptAndStyle.StyleFileSingle(ComponentUtility.GetCssTag(sweetalert_css, null));
            RenderScriptAndStyle.ScriptFileSingle(ComponentUtility.GetJsTag(sweetalert_js, sweetalert_js_cdn));
        }

        public SweetAlert Function(string value)
        {
            function = value;
            SetScript();
            return this;
        }

        public SweetAlert Title(string value)
        {
            Attributes["title"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public SweetAlert Title(Func<object, HelperResult> template)
        {
            var html = template(null).ToHtmlString().ToJavaScriptString();
            Attributes["title"] = string.Format("{0}", html);
            return Html(true);
        }

        public SweetAlert Text(string value)
        {
            Attributes["text"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public SweetAlert TextValue(string value)
        {
            Attributes["text"] = value;
            SetScript();
            return this;
        }

        public SweetAlert Text(Func<object, HelperResult> template)
        {
            var html = template(null).ToHtmlString().ToJavaScriptString();
            Attributes["text"] = string.Format("{0}", html);
            return Html(true);
        }

        public SweetAlert Type(string value)
        {
            Attributes["type"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public SweetAlert Type(SweetAlertType type)
        {
            if (type != SweetAlertType.Default)
            {
                Attributes["type"] = string.Format("'{0}'", type.ToString().ToLower());
            }

            SetScript();
            return this;
        }

        public SweetAlert ConfirmButtonText(string value)
        {
            Attributes["confirmButtonText"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public SweetAlert ConfirmButtonColor(string value)
        {
            Attributes["confirmButtonColor"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public SweetAlert CancelButtonText(string value)
        {
            Attributes["cancelButtonText"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public SweetAlert ImageUrl(string url)
        {
            Attributes["imageUrl"] = string.Format("'{0}'", url);
            SetScript();
            return this;
        }

        public SweetAlert ImageSize(int width, int height)
        {
            Attributes["imageSize"] = string.Format("'{0}x{1}'", width, height);
            SetScript();
            return this;
        }

        public SweetAlert Timer(int milisecond)
        {
            Attributes["timer"] = milisecond;
            SetScript();
            return this;
        }

        public SweetAlert Animation(SweetAlertAnimation value)
        {
            switch (value)
            {
                case SweetAlertAnimation.SlideFromTop:
                    Attributes["animation"] = string.Format("'{0}'", "slide-from-top");
                    break;
                case SweetAlertAnimation.SlideFromBootom:
                    Attributes["animation"] = string.Format("'{0}'", "slide-from-bottom");
                    break;
                case SweetAlertAnimation.PopDefault:
                    Animation(true);
                    break;
            }
            SetScript();
            return this;
        }

        public SweetAlert InputType(string value)
        {
            Attributes["inputType"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public SweetAlert InputPlaceholder(string value)
        {
            Attributes["inputPlaceholder"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public SweetAlert InputValue(string value)
        {
            Attributes["inputValue"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public SweetAlert AllowEscapeKey(bool value)
        {
            Attributes["allowEscapeKey"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public SweetAlert AllowOutsideClick(bool value)
        {
            Attributes["allowOutsideClick"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public SweetAlert ShowCancelButton(bool value)
        {
            Attributes["showCancelButton"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public SweetAlert ShowConfirmButton(bool value)
        {
            Attributes["showConfirmButton"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public SweetAlert CloseOnConfirm(bool value)
        {
            Attributes["closeOnConfirm"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public SweetAlert CloseOnCancel(bool value)
        {
            Attributes["closeOnCancel"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public SweetAlert Html(bool value)
        {
            Attributes["html"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public SweetAlert Animation(bool value)
        {
            Attributes["animation"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public SweetAlert ShowLoaderOnConfirm(bool value)
        {
            Attributes["showLoaderOnConfirm"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        protected void SetScript()
        {
            Script = "swal(" + this.RenderOptions() + (string.IsNullOrEmpty(function) ? "" : ", " + function) + ")";

            if (!ComponentUtility.GetHttpContext().Request.IsAjaxRequest() && HtmlHelper == null)
            {
                SetScriptTag();
            }
        }
    }
}