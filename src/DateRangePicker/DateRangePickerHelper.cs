using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq.Expressions;

namespace Microsoft.AspNetCore.Mvc
{
    public static class DateRangePickerHelper
    {
        #region Reqular

        #region DateRangePicker/For
        public static DateRangePickerOption<TModel, TValue> DateRangePickerFor<TModel, TValue>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
        {
            return new DateRangePickerOption<TModel, TValue>(htmlHelper, expression, null, htmlAttributes).LocaleFormat("YYYY/MM/DD");
        }

        public static DateRangePickerOption<TModel, TValue> DateRangePickerFor<TModel, TValue>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, string format, object htmlAttributes = null)
        {
            return new DateRangePickerOption<TModel, TValue>(htmlHelper, expression, format, htmlAttributes).LocaleFormat("YYYY/MM/DD");
        }

        public static DateRangePickerOption DateRangePicker(this IHtmlHelper htmlHelper, string expression, object htmlAttributes = null)
        {
            return new DateRangePickerOption(htmlHelper, expression, null, null, htmlAttributes).LocaleFormat("YYYY/MM/DD");
        }

        public static DateRangePickerOption DateRangePicker(this IHtmlHelper htmlHelper, string expression, object value, object htmlAttributes = null)
        {
            return new DateRangePickerOption(htmlHelper, expression, value, null, htmlAttributes).LocaleFormat("YYYY/MM/DD");
        }

        public static DateRangePickerOption DateRangePicker(this IHtmlHelper htmlHelper, string expression, object value, string format, object htmlAttributes = null)
        {
            return new DateRangePickerOption(htmlHelper, expression, value, format, htmlAttributes).LocaleFormat("YYYY/MM/DD");
        }
        #endregion

        #region DateTimeRangePicker/For
        public static DateRangePickerOption<TModel, TValue> DateTimeRangePickerFor<TModel, TValue>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
        {
            return new DateRangePickerOption<TModel, TValue>(htmlHelper, expression, null, htmlAttributes).TimePicker(true).TimePicker24Hour(true).LocaleFormat("YYYY/MM/DD HH:mm");
        }

        public static DateRangePickerOption<TModel, TValue> DateTimeRangePickerFor<TModel, TValue>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, string format, object htmlAttributes = null)
        {
            return new DateRangePickerOption<TModel, TValue>(htmlHelper, expression, format, htmlAttributes).TimePicker(true).TimePicker24Hour(true).LocaleFormat("YYYY/MM/DD HH:mm");
        }

        public static DateRangePickerOption DateTimeRangePicker(this IHtmlHelper htmlHelper, string expression, object htmlAttributes = null)
        {
            return new DateRangePickerOption(htmlHelper, expression, null, null, htmlAttributes).TimePicker(true).TimePicker24Hour(true).LocaleFormat("YYYY/MM/DD HH:mm");
        }

        public static DateRangePickerOption DateTimeRangePicker(this IHtmlHelper htmlHelper, string expression, object value, object htmlAttributes = null)
        {
            return new DateRangePickerOption(htmlHelper, expression, value, null, htmlAttributes).TimePicker(true).TimePicker24Hour(true).LocaleFormat("YYYY/MM/DD HH:mm");
        }

        public static DateRangePickerOption DateTimeRangePicker(this IHtmlHelper htmlHelper, string expression, object value, string format, object htmlAttributes = null)
        {
            return new DateRangePickerOption(htmlHelper, expression, value, format, htmlAttributes).TimePicker(true).TimePicker24Hour(true).LocaleFormat("YYYY/MM/DD HH:mm");
        }
        #endregion

        #region DatePicker/For
        public static DateRangePickerOption<TModel, TValue> DatePickerFor<TModel, TValue>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
        {
            return new DateRangePickerOption<TModel, TValue>(htmlHelper, expression, null, htmlAttributes).SingleDatePicker(true).LocaleFormat("YYYY/MM/DD");
        }

        public static DateRangePickerOption<TModel, TValue> DatePickerFor<TModel, TValue>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, string format, object htmlAttributes = null)
        {
            return new DateRangePickerOption<TModel, TValue>(htmlHelper, expression, format, htmlAttributes).SingleDatePicker(true).LocaleFormat("YYYY/MM/DD");
        }

        public static DateRangePickerOption DatePicker(this IHtmlHelper htmlHelper, string expression, object htmlAttributes = null)
        {
            return new DateRangePickerOption(htmlHelper, expression, null, null, htmlAttributes).SingleDatePicker(true).LocaleFormat("YYYY/MM/DD");
        }

        public static DateRangePickerOption DatePicker(this IHtmlHelper htmlHelper, string expression, object value, object htmlAttributes = null)
        {
            return new DateRangePickerOption(htmlHelper, expression, value, null, htmlAttributes).SingleDatePicker(true).LocaleFormat("YYYY/MM/DD");
        }

        public static DateRangePickerOption DatePicker(this IHtmlHelper htmlHelper, string expression, object value, string format, object htmlAttributes = null)
        {
            return new DateRangePickerOption(htmlHelper, expression, value, format, htmlAttributes).SingleDatePicker(true).LocaleFormat("YYYY/MM/DD");
        }
        #endregion

        #region DateTimePicker/For
        public static DateRangePickerOption<TModel, TValue> DateTimePickerFor<TModel, TValue>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
        {
            return new DateRangePickerOption<TModel, TValue>(htmlHelper, expression, null, htmlAttributes).SingleDatePicker(true).TimePicker(true).TimePicker24Hour(true).LocaleFormat("YYYY/MM/DD HH:mm");
        }

        public static DateRangePickerOption<TModel, TValue> DateTimePickerFor<TModel, TValue>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, string format, object htmlAttributes = null)
        {
            return new DateRangePickerOption<TModel, TValue>(htmlHelper, expression, format, htmlAttributes).SingleDatePicker(true).TimePicker(true).TimePicker24Hour(true).LocaleFormat("YYYY/MM/DD HH:mm");
        }

        public static DateRangePickerOption DateTimePicker(this IHtmlHelper htmlHelper, string expression, object htmlAttributes = null)
        {
            return new DateRangePickerOption(htmlHelper, expression, null, null, htmlAttributes).SingleDatePicker(true).TimePicker(true).TimePicker24Hour(true).LocaleFormat("YYYY/MM/DD HH:mm");
        }

        public static DateRangePickerOption DateTimePicker(this IHtmlHelper htmlHelper, string expression, object value, object htmlAttributes = null)
        {
            return new DateRangePickerOption(htmlHelper, expression, value, null, htmlAttributes).SingleDatePicker(true).TimePicker(true).TimePicker24Hour(true).LocaleFormat("YYYY/MM/DD HH:mm");
        }

        public static DateRangePickerOption DateTimePicker(this IHtmlHelper htmlHelper, string expression, object value, string format, object htmlAttributes = null)
        {
            return new DateRangePickerOption(htmlHelper, expression, value, format, htmlAttributes).SingleDatePicker(true).TimePicker(true).TimePicker24Hour(true).LocaleFormat("YYYY/MM/DD HH:mm");
        }
        #endregion

        #endregion

        #region Persian

        #region PersianDateRangePicker/For
        public static DateRangePickerOption<TModel, TValue> PersianDateRangePickerFor<TModel, TValue>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
        {
            return new DateRangePickerOption<TModel, TValue>(htmlHelper, expression, null, htmlAttributes).JalaaliRTL(true).Opens(OpensDirection.Left).LocaleFormat("jYYYY/jMM/jDD").Theme(DateRangePickerTheme.RTL_Red);
        }

        public static DateRangePickerOption<TModel, TValue> PersianDateRangePickerFor<TModel, TValue>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, string format, object htmlAttributes = null)
        {
            return new DateRangePickerOption<TModel, TValue>(htmlHelper, expression, format, htmlAttributes).JalaaliRTL(true).Opens(OpensDirection.Left).LocaleFormat("jYYYY/jMM/jDD").Theme(DateRangePickerTheme.RTL_Red);
        }

        public static DateRangePickerOption PersianDateRangePicker(this IHtmlHelper htmlHelper, string expression, object htmlAttributes = null)
        {
            return new DateRangePickerOption(htmlHelper, expression, null, null, htmlAttributes).JalaaliRTL(true).Opens(OpensDirection.Left).LocaleFormat("jYYYY/jMM/jDD").Theme(DateRangePickerTheme.RTL_Red);
        }

        public static DateRangePickerOption PersianDateRangePicker(this IHtmlHelper htmlHelper, string expression, object value, object htmlAttributes = null)
        {
            return new DateRangePickerOption(htmlHelper, expression, value, null, htmlAttributes).JalaaliRTL(true).Opens(OpensDirection.Left).LocaleFormat("jYYYY/jMM/jDD").Theme(DateRangePickerTheme.RTL_Red);
        }

        public static DateRangePickerOption PersianDateRangePicker(this IHtmlHelper htmlHelper, string expression, object value, string format, object htmlAttributes = null)
        {
            return new DateRangePickerOption(htmlHelper, expression, value, format, htmlAttributes).JalaaliRTL(true).Opens(OpensDirection.Left).LocaleFormat("jYYYY/jMM/jDD").Theme(DateRangePickerTheme.RTL_Red);
        }
        #endregion

        #region PersianDateTimeRangePicker/For
        public static DateRangePickerOption<TModel, TValue> PersianDateTimeRangePickerFor<TModel, TValue>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
        {
            return new DateRangePickerOption<TModel, TValue>(htmlHelper, expression, null, htmlAttributes).TimePicker(true).TimePicker24Hour(true).JalaaliRTL(true).Opens(OpensDirection.Left).LocaleFormat("jYYYY/jMM/jDD HH:mm").Theme(DateRangePickerTheme.RTL_Red);
        }

        public static DateRangePickerOption<TModel, TValue> PersianDateTimeRangePickerFor<TModel, TValue>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, string format, object htmlAttributes = null)
        {
            return new DateRangePickerOption<TModel, TValue>(htmlHelper, expression, format, htmlAttributes).TimePicker(true).TimePicker24Hour(true).JalaaliRTL(true).Opens(OpensDirection.Left).LocaleFormat("jYYYY/jMM/jDD HH:mm").Theme(DateRangePickerTheme.RTL_Red);
        }

        public static DateRangePickerOption PersianDateTimeRangePicker(this IHtmlHelper htmlHelper, string expression, object htmlAttributes = null)
        {
            return new DateRangePickerOption(htmlHelper, expression, null, null, htmlAttributes).TimePicker(true).TimePicker24Hour(true).JalaaliRTL(true).Opens(OpensDirection.Left).LocaleFormat("jYYYY/jMM/jDD HH:mm").Theme(DateRangePickerTheme.RTL_Red);
        }

        public static DateRangePickerOption PersianDateTimeRangePicker(this IHtmlHelper htmlHelper, string expression, object value, object htmlAttributes = null)
        {
            return new DateRangePickerOption(htmlHelper, expression, value, null, htmlAttributes).TimePicker(true).TimePicker24Hour(true).JalaaliRTL(true).Opens(OpensDirection.Left).LocaleFormat("jYYYY/jMM/jDD HH:mm").Theme(DateRangePickerTheme.RTL_Red);
        }

        public static DateRangePickerOption PersianDateTimeRangePicker(this IHtmlHelper htmlHelper, string expression, object value, string format, object htmlAttributes = null)
        {
            return new DateRangePickerOption(htmlHelper, expression, value, format, htmlAttributes).TimePicker(true).TimePicker24Hour(true).JalaaliRTL(true).Opens(OpensDirection.Left).LocaleFormat("jYYYY/jMM/jDD HH:mm").Theme(DateRangePickerTheme.RTL_Red);
        }
        #endregion

        #region PersianDatePicker/For
        public static DateRangePickerOption<TModel, TValue> PersianDatePickerFor<TModel, TValue>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
        {
            return new DateRangePickerOption<TModel, TValue>(htmlHelper, expression, null, htmlAttributes).SingleDatePicker(true).JalaaliRTL(true).Opens(OpensDirection.Left).LocaleFormat("jYYYY/jMM/jDD");
        }

        public static DateRangePickerOption<TModel, TValue> PersianDatePickerFor<TModel, TValue>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, string format, object htmlAttributes = null)
        {
            return new DateRangePickerOption<TModel, TValue>(htmlHelper, expression, format, htmlAttributes).SingleDatePicker(true).JalaaliRTL(true).Opens(OpensDirection.Left).LocaleFormat("jYYYY/jMM/jDD");
        }

        public static DateRangePickerOption PersianDatePicker(this IHtmlHelper htmlHelper, string expression, object htmlAttributes = null)
        {
            return new DateRangePickerOption(htmlHelper, expression, null, null, htmlAttributes).SingleDatePicker(true).JalaaliRTL(true).Opens(OpensDirection.Left).LocaleFormat("jYYYY/jMM/jDD");
        }

        public static DateRangePickerOption PersianDatePicker(this IHtmlHelper htmlHelper, string expression, object value, object htmlAttributes = null)
        {
            return new DateRangePickerOption(htmlHelper, expression, value, null, htmlAttributes).SingleDatePicker(true).JalaaliRTL(true).Opens(OpensDirection.Left).LocaleFormat("jYYYY/jMM/jDD");
        }

        public static DateRangePickerOption PersianDatePicker(this IHtmlHelper htmlHelper, string expression, object value, string format, object htmlAttributes = null)
        {
            return new DateRangePickerOption(htmlHelper, expression, value, format, htmlAttributes).SingleDatePicker(true).JalaaliRTL(true).Opens(OpensDirection.Left).LocaleFormat("jYYYY/jMM/jDD");
        }
        #endregion

        #region DateTimePicker/For
        public static DateRangePickerOption<TModel, TValue> PersianDateTimePickerFor<TModel, TValue>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
        {
            return new DateRangePickerOption<TModel, TValue>(htmlHelper, expression, null, htmlAttributes).SingleDatePicker(true).TimePicker(true).TimePicker24Hour(true).JalaaliRTL(true).Opens(OpensDirection.Left).LocaleFormat("jYYYY/jMM/jDD HH:mm");
        }

        public static DateRangePickerOption<TModel, TValue> PersianDateTimePickerFor<TModel, TValue>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, string format, object htmlAttributes = null)
        {
            return new DateRangePickerOption<TModel, TValue>(htmlHelper, expression, format, htmlAttributes).SingleDatePicker(true).TimePicker(true).TimePicker24Hour(true).JalaaliRTL(true).Opens(OpensDirection.Left).LocaleFormat("jYYYY/jMM/jDD HH:mm");
        }

        public static DateRangePickerOption PersianDateTimePicker(this IHtmlHelper htmlHelper, string expression, object htmlAttributes = null)
        {
            return new DateRangePickerOption(htmlHelper, expression, null, null, htmlAttributes).SingleDatePicker(true).TimePicker(true).TimePicker24Hour(true).JalaaliRTL(true).Opens(OpensDirection.Left).LocaleFormat("jYYYY/jMM/jDD HH:mm");
        }

        public static DateRangePickerOption PersianDateTimePicker(this IHtmlHelper htmlHelper, string expression, object value, object htmlAttributes = null)
        {
            return new DateRangePickerOption(htmlHelper, expression, value, null, htmlAttributes).SingleDatePicker(true).TimePicker(true).TimePicker24Hour(true).JalaaliRTL(true).Opens(OpensDirection.Left).LocaleFormat("jYYYY/jMM/jDD HH:mm");
        }

        public static DateRangePickerOption PersianDateTimePicker(this IHtmlHelper htmlHelper, string expression, object value, string format, object htmlAttributes = null)
        {
            return new DateRangePickerOption(htmlHelper, expression, value, format, htmlAttributes).SingleDatePicker(true).TimePicker(true).TimePicker24Hour(true).JalaaliRTL(true).Opens(OpensDirection.Left).LocaleFormat("jYYYY/jMM/jDD HH:mm");
        }
        #endregion

        #endregion
    }
}
