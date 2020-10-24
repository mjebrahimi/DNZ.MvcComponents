using DNZ.MvcComponents;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Microsoft.AspNetCore.Mvc
{
    public class DateRangePickerOption<TModel, TValue> : DateRangePickerOption
    {
        public new IHtmlHelper<TModel> HtmlHelper { get; set; }
        public new Expression<Func<TModel, TValue>> Expression { get; set; }

        public DateRangePickerOption(IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, string format, object htmlAttributes = null) : base()
        {
            base.HtmlHelper = HtmlHelper = htmlHelper.NotNull(nameof(htmlHelper));
            Expression = expression.NotNull(nameof(expression));
            Format = format;
            HtmlAttributes = htmlAttributes;
        }

        protected override (string Id, IHtmlContent Editor) GetIdAndHtmlContent()
        {
            var id = HtmlHelper.FieldIdFor(Expression);
            var editor = HtmlHelper.TextBoxFor(Expression, Format, HtmlAttributes);
            return (id, editor);
        }
    }

    public class DateRangePickerOption : BaseComponent, IOptionBuilder
    {
        //http://www.daterangepicker.com/
        //https://cdnjs.com/libraries/bootstrap-daterangepicker
        //https://cdnjs.com/libraries/moment.js
        //https://www.jsdelivr.com/package/npm/moment-jalaali
        //https://github.com/saeidrnb/Persian-DateRangePicker (Jalaali Example)

        #region Constants
#pragma warning disable S125 // Sections of code should not be commented out
        //-------------- ltr cdn
        private const string ltr_daterangepicker_css_cdn = "<link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/bootstrap-daterangepicker/3.0.5/daterangepicker.min.css\" integrity=\"sha512-rBi1cGvEdd3NmSAQhPWId5Nd6QxE8To4ADjM2a6n0BrqQdisZ/RPUlm0YycDzvNL1HHAh1nKZqI0kSbif+5upQ==\" crossorigin=\"anonymous\" />";
        private const string ltr_moment_js_cdn = "<script src=\"https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.29.1/moment.min.js\" integrity=\"sha512-qTXRIMyZIFb8iQcfjXWCO8+M5Tbc38Qi5WzdPOYZHIlZpzBHG3L3by84BBBOiRGiEb7KKtAOAs5qYdUiZiQNNQ==\" crossorigin=\"anonymous\"></script>";
        //private const string ltr_moment2_js_cdn = "<script src=\"https://cdnjs.cloudflare.com/ajax/libs/bootstrap-daterangepicker/3.0.5/moment.min.js\" integrity=\"sha512-i2CVnAiguN6SnJ3d2ChOOddMWQyvgQTzm0qSgiKhOqBMGCx4fGU5BtzXEybnKatWPDkXPFyCI0lbG42BnVjr/Q==\" crossorigin=\"anonymous\"></script>";
        private const string ltr_moment_jalaali_js_cdn = "<script src=\"https://cdn.jsdelivr.net/npm/moment-jalaali@0.9.2/build/moment-jalaali.js\" integrity=\"sha256-4Zsz2GPWeHkOl+U+rP9kuC5inOSepVzqzit8W6FjtaY=\" crossorigin=\"anonymous\"></script>";
        private const string ltr_daterangepicker_js_cdn = "<script src=\"https://cdnjs.cloudflare.com/ajax/libs/bootstrap-daterangepicker/3.0.5/daterangepicker.min.js\" integrity=\"sha512-mh+AjlD3nxImTUGisMpHXW03gE6F4WdQyvuFRkjecwuWLwD2yCijw4tKA3NsEFpA1C3neiKhGXPSIGSfCYPMlQ==\" crossorigin=\"anonymous\"></script>";
        //-------------- ltr locale
        private const string ltr_daterangepicker_css = "DNZ.MvcComponents.DateRangePicker.ltr.css.daterangepicker.min.css";
        private const string ltr_moment_js = "DNZ.MvcComponents.DateRangePicker.ltr.js.moment.min.js";
        //private const string ltr_moment2_js = "DNZ.MvcComponents.DateRangePicker.ltr.js.moment2.min.js";
        private const string ltr_moment_jalaali_js = "DNZ.MvcComponents.DateRangePicker.ltr.js.moment-jalaali.js";
        private const string ltr_daterangepicker_js = "DNZ.MvcComponents.DateRangePicker.ltr.js.daterangepicker.min.js";
        //-------------- rtl
        private const string rtl_daterangepicker_css = "DNZ.MvcComponents.DateRangePicker.rtl.css.daterangepicker.css";
        private const string rtl_datepicker_theme_css = "DNZ.MvcComponents.DateRangePicker.rtl.css.datepicker-theme.css";
        //private const string rtl_moment_js = "DNZ.MvcComponents.DateRangePicker.rtl.js.moment.min.js";
        //private const string rtl_moment_jalaali_js = "DNZ.MvcComponents.DateRangePicker.rtl.js.moment-jalaali.js";
        private const string rtl_daterangepicker_js = "DNZ.MvcComponents.DateRangePicker.rtl.js.daterangepicker.js";
        //-------------- rtl2
        private const string rtl2_datepicker_theme_css = "DNZ.MvcComponents.DateRangePicker.rtl2.css.datepicker-theme.css";
#pragma warning restore S125 // Sections of code should not be commented out
        #endregion

        public Dictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();
        public Dictionary<string, object> LocaleAttributes { get; set; } = new Dictionary<string, object>();
        public IHtmlHelper HtmlHelper { get; set; }
        public string Expression { get; set; }
        public object Value { get; set; }
        public string Format { get; set; }
        public object HtmlAttributes { get; set; }
        public bool JalaaliRTL { get; set; }
        public DateRangePickerTheme Theme { get; set; }

        protected DateRangePickerOption()
        {
        }

        public DateRangePickerOption(IHtmlHelper htmlHelper, string expression, object value, string format, object htmlAttributes)
        {
            HtmlHelper = htmlHelper.NotNull(nameof(htmlHelper));
            Expression = expression.NotNull(nameof(expression));
            Value = value;
            Format = format;
            HtmlAttributes = htmlAttributes;
        }

        public override string ToHtmlString()
        {
            if (JalaaliRTL)
                HtmlHelper.StyleFileSingle(ComponentUtility.GetCssTag(rtl_daterangepicker_css, null));
            else
                HtmlHelper.StyleFileSingle(ComponentUtility.GetCssTag(ltr_daterangepicker_css, ltr_daterangepicker_css_cdn));

            switch (Theme)
            {
                case DateRangePickerTheme.RTL_Red:
                    HtmlHelper.StyleFileSingle(ComponentUtility.GetCssTag(rtl_datepicker_theme_css, null));
                    break;
                case DateRangePickerTheme.RTL_Blue:
                    HtmlHelper.StyleFileSingle(ComponentUtility.GetCssTag(rtl2_datepicker_theme_css, null));
                    break;
            }

            //HtmlHelper.ScriptFileSingle(ComponentUtility.GetJsTag(rtl_moment_js, null));                          //momentjs rtl
            //HtmlHelper.ScriptFileSingle(ComponentUtility.GetJsTag(ltr_moment2_js, ltr_moment2_js_cdn));                   //momentjs daterangepicker
            HtmlHelper.ScriptFileSingle(ComponentUtility.GetJsTag(ltr_moment_js, ltr_moment_js_cdn));                       //momentjs orginal

            if (JalaaliRTL)
            {
                //HtmlHelper.ScriptFileSingle(ComponentUtility.GetJsTag(rtl_moment_jalaali_js, null));              //moment-jalaali rtl
                HtmlHelper.ScriptFileSingle(ComponentUtility.GetJsTag(ltr_moment_jalaali_js, ltr_moment_jalaali_js_cdn));   //moment-jalaali orginal
                HtmlHelper.ScriptFileSingle(ComponentUtility.GetJsTag(rtl_daterangepicker_js, null));
            }
            else
            {
                HtmlHelper.ScriptFileSingle(ComponentUtility.GetJsTag(ltr_daterangepicker_js, ltr_daterangepicker_js_cdn));
            }

            var (id, editor) = GetIdAndHtmlContent();
            HtmlHelper.Script(@"
            <script>
                $(function(){
                    $(""#" + id + @""").daterangepicker(" + RenderOptions() + @");
                });
            </script>");
            return editor.ToHtmlString();
        }

        protected virtual (string Id, IHtmlContent Editor) GetIdAndHtmlContent()
        {
            var id = HtmlHelper.GenerateIdFromName(Expression);
            var editor = HtmlHelper.TextBox(Expression, Value, Format, HtmlAttributes);
            return (id, editor);
        }

        private string RenderOptions()
        {
            if (LocaleAttributes.Count > 0)
            {
                var result = string.Join(", \n", LocaleAttributes.Select(p => p.Key + ": " + p.Value));
                Attributes["locale"] = "{\n" + result + "\n}";
            }

            return ComponentUtility.RenderOptions(this);
        }
    }
}
