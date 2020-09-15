using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using DNZ.MvcComponents;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Microsoft.AspNetCore.Mvc
{
    public static class BootstrapDateTimePicker
    {
        private const string PersianDateTimePicker_css = "DNZ.MvcComponents.MdBootstrapPersianDateTimePicker.css.jquery.Bootstrap-PersianDateTimePicker.css";
        private const string Jalali_js = "DNZ.MvcComponents.MdBootstrapPersianDateTimePicker.js.jalaali.js";
        private const string PersianDateTimePicker_js = "DNZ.MvcComponents.MdBootstrapPersianDateTimePicker.js.jquery.Bootstrap-PersianDateTimePicker.js";

        public static IHtmlContent TarikhFarsiFor<TModel, TValue>(this IHtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, bool enableTimePicker = false)
        {
            ModelExplorer metadata = helper.GetModelExplorer(expression);

            string value = "";
            DateTime? castedValue = metadata.Model as DateTime?;
            if (castedValue?.Equals(default) == false)
            {
                value = helper.DisplayFor(expression).ToHtmlString();
            }

            Dictionary<string, object> attributes = new Dictionary<string, object>() {
                { "Value", value },
                { "data-targetselector", "#" + helper.FieldIdFor(expression) },
                { "data-mdpersiandatetimepickershowing", "false" },
                { "data-mdpersiandatetimepicker", "true" },
                { "style", "cursor: pointer;" },
                { "data-mddatetimepicker", "true" },
                { "data-trigger", "focus" },
                { "data-enabletimepicker", enableTimePicker.ToString().ToLower() },
                { "data-placement", "left" },
                { "data-englishnumber", "true" },
                { "data-mdformat", enableTimePicker ? "yyyy/MM/dd HH:mm" : "yyyy/MM/dd" },
                //{ "data-todate", "true" },
                //{ "data-fromdate", "true" },
                //{ "data-disabled", "false" },
                //{ "data-disablebeforetoday", "false" },
                //{ "data-isgregorian", "false" },
            };

            //Supported format
            //yyyy: سال چهار رقمی
            //yy: سال دو رقمی
            //MMMM: نام فارسی ماه
            //MM: عدد دو رقمی ماه
            //M: عدد یک رقمی ماه
            //dddd: نام فارسی روز هفته
            //dd: عدد دو رقمی روز ماه
            //d: عدد یک رقمی روز ماه
            //HH: ساعت دو رقمی با فرمت 00 تا 24
            //H: ساعت یک رقمی با فرمت 0 تا 24
            //hh: ساعت دو رقمی با فرمت 00 تا 12
            //h: ساعت یک رقمی با فرمت 0 تا 12
            //mm: عدد دو رقمی دقیقه
            //m: عدد یک رقمی دقیقه
            //ss: ثانیه دو رقمی
            //s: ثانیه یک رقمی
            //fff: میلی ثانیه 3 رقمی
            //ff: میلی ثانیه 2 رقمی
            //f: میلی ثانیه یک رقمی
            //tt: ب.ظ یا ق.ظ
            //t: حرف اول از ب.ظ یا ق.ظ

            Dictionary<string, object> mergAttr = ComponentUtility.MergeAttributes(htmlAttributes, attributes);
            string result = helper.TextBoxFor(expression, mergAttr).ToHtmlString(); //input.RenderSelfClosingTag();

            helper.StyleFileSingle(@"<link href=""" + ComponentUtility.GetWebResourceUrl(PersianDateTimePicker_css) + @""" rel=""stylesheet"" />");
            helper.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(Jalali_js) + @"""></script>");
            helper.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(PersianDateTimePicker_js) + @"""></script>");

            return new HtmlString(result);
        }

        public static IHtmlContent DatePicker3Part<TModel, TValue>(this IHtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, int lowYear = -5, int highYear = +5)
        {
            ModelExplorer metadata = helper.GetModelExplorer(expression);
            object value = metadata.Model;
            string id = helper.FieldIdFor(expression);
            string name = helper.FieldNameFor(expression);
            DateTime? datetime = null;
            PersianCalendar pc = new PersianCalendar();
            if (value != null && value.ToString() != "")
            {
                datetime = Convert.ToDateTime(value);
            }

            List<SelectListItem> listDay = new List<SelectListItem> { new SelectListItem { Text = "روز", Value = null, Selected = !datetime.HasValue } };
            for (int i = 1; i <= 31; i++)
            {
                listDay.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString("00"), Selected = datetime.HasValue && i == Convert.ToInt32(datetime.Value.ToString("dd")) });
            }

            List<SelectListItem> listMonth = new List<SelectListItem> { new SelectListItem { Text = "ماه", Value = null, Selected = !datetime.HasValue } };
            for (int i = 1; i <= 12; i++)
            {
                listMonth.Add(new SelectListItem { Text = i + " - " + GetMonthName(i), Value = i.ToString("00"), Selected = datetime.HasValue && i == Convert.ToInt32(datetime.Value.ToString("MM")) });
            }

            List<SelectListItem> listYear = new List<SelectListItem> { new SelectListItem { Text = "سال", Value = null, Selected = !datetime.HasValue } };
            for (int i = pc.GetYear(DateTime.Now) + lowYear; i <= pc.GetYear(DateTime.Now) + highYear; i++)
            {
                listYear.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString(), Selected = datetime.HasValue && i == Convert.ToInt32(datetime.Value.ToString("yyyy")) });
            }

            IHtmlContent drpDay = helper.DropDownList(id + "_day", listDay, new { @class = "form-control" });
            IHtmlContent drpMonth = helper.DropDownList(id + "_month", listMonth, new { @class = "form-control"/*, style = "padding: 6px 12px 6px 0 !important"*/ });
            IHtmlContent drpYear = helper.DropDownList(id + "_year", listYear, new { @class = "form-control" });
            IHtmlContent hidden = helper.HiddenFor(expression);
            string result = string.Format(@"
<div class='col-sm-3' style='padding:0'>{0}</div>
<div class='col-sm-5' style='padding:0'>{1}</div>
<div class='col-sm-4' style='padding:0'>{2}</div>{3}", drpDay.ToHtmlString(), drpMonth.ToHtmlString(), drpYear.ToHtmlString(), hidden.ToHtmlString())
     + helper.Script(@"
<script>
    $(function () {
        function IsNumeric (n) {
          return !isNaN(parseFloat(n)) && isFinite(n);
        }
        function DDLValidation () {
            var day = $(""#" + id + @"_day"").val();
            var month = $(""#" + id + @"_month"").val();
            var year = $(""#" + id + @"_year"").val();
            if (IsNumeric(day) && IsNumeric(month) && IsNumeric(year)){
                $(""#" + id + @""").val(year + '/' + month + '/' + day).trigger('change');
            }
            else{
                $(""#" + id + @""").val('').trigger('change');
            }
            $(""#" + id + @""").valid();
        }
        var isFirst = true;
        $(""#" + id + "_day, #" + id + "_month, #" + id + @"_year"").blur(function () {
                var aa = $(""#" + id + @"_day"").is(':active');
                var bb = $(""#" + id + @"_month"").is(':active');
                var cc = $(""#" + id + @"_year"").is(':active');
                if (aa == false && bb == false && cc == false) {
                    if (isFirst) {
                        DDLValidation();
                        isFirst = false;
                    }
                }
        });
        $(""#" + id + "_day, #" + id + "_month, #" + id + @"_year"").change(function () {
            if (isFirst == false) {
                DDLValidation()
            }
        });
    })
</script>
");
            return new HtmlString(result);
        }

        private static string GetMonthName(int value)
        {
            switch (value)
            {
                case 1:
                    return "فروردین";
                case 2:
                    return "اردیبهشت";
                case 3:
                    return "خرداد";
                case 4:
                    return "تیر";
                case 5:
                    return "مرداد";
                case 6:
                    return "شهریور";
                case 7:
                    return "مهر";
                case 8:
                    return "آبان";
                case 9:
                    return "آذر";
                case 10:
                    return "دی";
                case 11:
                    return "بهمن";
                case 12:
                    return "اسفند";
                default:
                    return "";
            }
        }
    }
}