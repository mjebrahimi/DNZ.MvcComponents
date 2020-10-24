using DNZ.MvcComponents;
using System;
using System.Linq;

namespace Microsoft.AspNetCore.Mvc
{
    public static class DateRangePickerOptionExtensions
    {
        /// <summary>
        /// (Date or string) The beginning date of the initially selected date range. If you provide a string, it must match the date format string set in your locale setting. (format: 'MM/dd/yyyy')
        /// </summary>
        public static TOption StartDate<TOption>(this TOption option, string dateTime) where TOption : DateRangePickerOption
        {
            option.Attributes["startDate"] = dateTime;
            return option;
        }

        /// <summary>
        /// (Date or string) The beginning date of the initially selected date range. If you provide a string, it must match the date format string set in your locale setting.
        /// </summary>
        public static TOption StartDate<TOption>(this TOption option, DateTime dateTime) where TOption : DateRangePickerOption
        {
            option.Attributes["startDate"] = string.Format("'{0}'", dateTime.ToString("MM/dd/yyyy"));
            return option;
        }

        /// <summary>
        /// (Date or string) The end date of the initially selected date range. (format: 'MM/dd/yyyy')
        /// </summary>
        public static TOption EndDate<TOption>(this TOption option, string dateTime) where TOption : DateRangePickerOption
        {
            option.Attributes["endDate"] = dateTime;
            return option;
        }

        /// <summary>
        /// (Date or string) The end date of the initially selected date range.
        /// </summary>
        public static TOption EndDate<TOption>(this TOption option, DateTime dateTime) where TOption : DateRangePickerOption
        {
            option.Attributes["endDate"] = string.Format("'{0}'", dateTime.ToString("MM/dd/yyyy"));
            return option;
        }

        /// <summary>
        /// (Date or string) The earliest date a user may select.(format: 'MM/dd/yyyy')
        /// </summary>
        public static TOption MinDate<TOption>(this TOption option, string dateTime) where TOption : DateRangePickerOption
        {
            option.Attributes["minDate"] = dateTime;
            return option;
        }

        /// <summary>
        /// (Date or string) The earliest date a user may select.
        /// </summary>
        public static TOption MinDate<TOption>(this TOption option, DateTime dateTime) where TOption : DateRangePickerOption
        {
            option.Attributes["minDate"] = string.Format("'{0}'", dateTime.ToString("MM/dd/yyyy"));
            return option;
        }

        /// <summary>
        /// (Date or string) The latest date a user may select.(format: 'MM/dd/yyyy')
        /// </summary>
        public static TOption MaxDate<TOption>(this TOption option, string dateTime) where TOption : DateRangePickerOption
        {
            option.Attributes["maxDate"] = dateTime;
            return option;
        }

        /// <summary>
        /// (Date or string) The latest date a user may select.
        /// </summary>
        public static TOption MaxDate<TOption>(this TOption option, DateTime dateTime) where TOption : DateRangePickerOption
        {
            option.Attributes["maxDate"] = string.Format("'{0}'", dateTime.ToString("MM/dd/yyyy"));
            return option;
        }

        /// <summary>
        /// (number) The minimum year shown in the dropdowns when showDropdowns is set to true.
        /// </summary>
        public static TOption MinYear<TOption>(this TOption option, int year) where TOption : DateRangePickerOption
        {
            option.Attributes["minYear"] = year;
            return option;
        }

        /// <summary>
        /// (number) The maximum year shown in the dropdowns when showDropdowns is set to true.
        /// </summary>
        public static TOption MaxYear<TOption>(this TOption option, int year) where TOption : DateRangePickerOption
        {
            option.Attributes["maxYear"] = year;
            return option;
        }

        /// <summary>
        /// (true/false) Show localized week numbers at the start of each week on the calendars.
        /// </summary>
        public static TOption ShowWeekNumbers<TOption>(this TOption option, bool show) where TOption : DateRangePickerOption
        {
            option.Attributes["showWeekNumbers"] = show.ToString().ToLower();
            return option;
        }

        /// <summary>
        /// (true/false) Show ISO week numbers at the start of each week on the calendars.
        /// </summary>
        public static TOption ShowISOWeekNumbers<TOption>(this TOption option, bool show) where TOption : DateRangePickerOption
        {
            option.Attributes["showISOWeekNumbers"] = show.ToString().ToLower();
            return option;
        }

        /// <summary>
        /// (true/false) Adds select boxes to choose times in addition to dates.
        /// </summary>
        public static TOption TimePicker<TOption>(this TOption option, bool enabled) where TOption : DateRangePickerOption
        {
            option.Attributes["timePicker"] = enabled.ToString().ToLower();
            return option;
        }

        /// <summary>
        /// (number) Increment of the minutes selection list for times (i.e. 30 to allow only selection of times ending in 0 or 30).
        /// </summary>
        public static TOption TimePickerIncrement<TOption>(this TOption option, int number) where TOption : DateRangePickerOption
        {
            option.Attributes["timePickerIncrement"] = number;
            return option;
        }

        /// <summary>
        /// (true/false) Use 24-hour instead of 12-hour times, removing the AM/PM selection.
        /// </summary>
        public static TOption TimePicker24Hour<TOption>(this TOption option, bool enabled) where TOption : DateRangePickerOption
        {
            option.Attributes["timePicker24Hour"] = enabled.ToString().ToLower();
            return option;
        }

        /// <summary>
        /// (true/false) Show seconds in the timePicker.
        /// </summary>
        public static TOption TimePickerSeconds<TOption>(this TOption option, bool show) where TOption : DateRangePickerOption
        {
            option.Attributes["timePickerSeconds"] = show.ToString().ToLower();
            return option;
        }

        /// <summary>
        /// (true/false) Displays "Custom Range" at the end of the list of predefined ranges, when the ranges option is used.
        /// This option will be highlighted whenever the current date range selection does not match one of the predefined ranges.
        /// Clicking it will display the calendars to select a new range.
        /// </summary>
        public static TOption ShowCustomRangeLabel<TOption>(this TOption option, bool show) where TOption : DateRangePickerOption
        {
            option.Attributes["showCustomRangeLabel"] = show.ToString().ToLower();
            return option;
        }

        /// <summary>
        /// (true/false) Normally, if you use the ranges option to specify pre-defined date ranges, calendars for choosing a custom date range are not shown until the user clicks "Custom Range".
        /// When this option is set to true, the calendars for choosing a custom date range are always shown instead.
        /// </summary>
        public static TOption AlwaysShowCalendars<TOption>(this TOption option, bool show) where TOption : DateRangePickerOption
        {
            option.Attributes["alwaysShowCalendars"] = show.ToString().ToLower();
            return option;
        }

        /// <summary>
        /// (string) CSS class names that will be added to both the apply and cancel buttons.
        /// </summary>
        public static TOption ButtonClasses<TOption>(this TOption option, string classs) where TOption : DateRangePickerOption
        {
            option.Attributes["buttonClasses"] = string.Format("'{0}'", classs);
            return option;
        }

        /// <summary>
        /// (string) CSS class names that will be added only to the apply button.
        /// </summary>
        public static TOption ApplyButtonClasses<TOption>(this TOption option, string classs) where TOption : DateRangePickerOption
        {
            option.Attributes["applyButtonClasses"] = string.Format("'{0}'", classs);
            return option;
        }

        /// <summary>
        /// (string) CSS class names that will be added only to the cancel button.
        /// </summary>
        public static TOption CancelButtonClasses<TOption>(this TOption option, string classs) where TOption : DateRangePickerOption
        {
            option.Attributes["cancelButtonClasses"] = string.Format("'{0}'", classs);
            return option;
        }

        /// <summary>
        /// (true/false) Show only a single calendar to choose one date, instead of a range picker with two calendars.
        /// The start and end dates provided to your callback will be the same single date chosen.
        /// </summary>
        public static TOption SingleDatePicker<TOption>(this TOption option, bool enabled) where TOption : DateRangePickerOption
        {
            option.Attributes["singleDatePicker"] = enabled.ToString().ToLower();
            return option;
        }

        /// <summary>
        /// (true/false) Hide the apply and cancel buttons, and automatically apply a new date range as soon as two dates are clicked.
        /// </summary>
        public static TOption AutoApply<TOption>(this TOption option, bool enabled) where TOption : DateRangePickerOption
        {
            option.Attributes["autoApply"] = enabled.ToString().ToLower();
            return option;
        }

        /// <summary>
        /// (true/false) When enabled, the two calendars displayed will always be for two sequential months (i.e. January and February), and both will be advanced when clicking the left or right arrows above the calendars.
        /// When disabled, the two calendars can be individually advanced and display any month/year.
        /// </summary>
        public static TOption LinkedCalendars<TOption>(this TOption option, bool enabled) where TOption : DateRangePickerOption
        {
            option.Attributes["linkedCalendars"] = enabled.ToString().ToLower();
            return option;
        }

        /// <summary>
        /// (true/false) Indicates whether the date range picker should automatically update the value of the <input> element it's attached to at initialization and when the selected dates change.
        /// </summary>
        public static TOption AutoUpdateInput<TOption>(this TOption option, bool enabled) where TOption : DateRangePickerOption
        {
            option.Attributes["autoUpdateInput"] = enabled.ToString().ToLower();
            return option;
        }

        /// <summary>
        /// (string) jQuery selector of the parent element that the date range picker will be added to, if not provided this will be 'body'
        /// </summary>
        public static TOption ParentEl<TOption>(this TOption option, string selector) where TOption : DateRangePickerOption
        {
            option.Attributes["parentEl"] = string.Format("'{0}'", selector);
            return option;
        }

        /// <summary>
        /// The maximum span between the selected start and end dates. Check off maxSpan in the configuration generator for an example of how to use this.
        /// You can provide any object the moment library would let you add to a date.
        /// </summary>
        public static TOption MaxSpan<TOption>(this TOption option, TimeSpan timeSpan) where TOption : DateRangePickerOption
        {
            option.Attributes["maxSpan"] = "{ 'seconds': " + timeSpan.TotalSeconds + " }";
            return option;
        }

        /// <summary>
        /// Set predefined date ranges the user can select from. Each key is the label for the range, and its value an array with two dates representing the bounds of the range.
        /// Click ranges in the configuration generator for examples.
        /// </summary>
        public static TOption Ranges<TOption>(this TOption option, string ranges) where TOption : DateRangePickerOption
        {
            option.Attributes["ranges"] = ranges;
            return option;
        }

        /// <summary>
        /// Set predefined date ranges the user can select from. Each key is the label for the range, and its value an array with two dates representing the bounds of the range.
        /// Click ranges in the configuration generator for examples.
        /// </summary>
        public static TOption RangesEn<TOption>(this TOption option, string ranges =
            @"{
	            'Today': [moment(), moment()],
	            'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
	            'Last 7 Days': [moment().subtract(6, 'days'), moment()],
	            'Last 30 Days': [moment().subtract(29, 'days'), moment()],
	            'This Month': [moment().startOf('month'), moment().endOf('month')],
	            'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
            }") where TOption : DateRangePickerOption
        {
            option.Attributes["ranges"] = ranges;
            return option;
        }

        /// <summary>
        /// Set predefined date ranges the user can select from. Each key is the label for the range, and its value an array with two dates representing the bounds of the range.
        /// Click ranges in the configuration generator for examples.
        /// </summary>
        public static TOption RangesFa<TOption>(this TOption option, string ranges =
            @"{
	            'امروز': [moment(), moment()],
	            'دیروز': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
	            '7 روز اخیر': [moment().subtract(6, 'days'), moment()],
	            '30 روز اخیر': [moment().subtract(29, 'days'), moment()],
	            'ماه جاری': [moment().startOf('month'), moment().endOf('month')],
	            'ماه قبل': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
            }") where TOption : DateRangePickerOption
        {
            option.Attributes["ranges"] = ranges;
            return option;
        }

        /// <summary>
        /// ('left'/'right'/'center') Whether the picker appears aligned to the left, to the right, or centered under the HTML element it's attached to.
        /// </summary>
        public static TOption Opens<TOption>(this TOption option, OpensDirection opens) where TOption : DateRangePickerOption
        {
            option.Attributes["opens"] = string.Format("'{0}'", opens.ToString().ToLower());
            return option;
        }

        /// <summary>
        /// ('down'/'up'/'auto') Whether the picker appears below (default) or above the HTML element it's attached to.
        /// </summary>
        public static TOption Drops<TOption>(this TOption option, DropsDirection drops) where TOption : DateRangePickerOption
        {
            option.Attributes["drops"] = string.Format("'{0}'", drops.ToString().ToLower());
            return option;
        }


        #region Locale Attributes
        public static TOption LocaleDirection<TOption>(this TOption option, ComponentDirection direction) where TOption : DateRangePickerOption
        {

            option.LocaleAttributes["direction"] = string.Format("'{0}'", direction.ToDisplayName());
            return option;
        }

        /// <summary>
        /// ----------- regular -----------
        /// "YYYY/MM/DD"
        /// "YYYY/MM/DD HH:mm"
        /// ----------- ignore quotes -----------
        /// moment.localeData().longDateFormat('L')
        /// ----------- jalaali -----------
        /// "jYYYY/jMM/jDD"
        /// "jYYYY/jMM/jDD HH:mm"
        /// </summary>
        public static TOption LocaleFormat<TOption>(this TOption option, string format, bool ignoreQuotes = false) where TOption : DateRangePickerOption
        {
            option.LocaleAttributes["format"] = ignoreQuotes ? format : string.Format("'{0}'", format);
            return option;
        }

        /// <summary>
        /// " - "
        /// </summary>
        public static TOption LocaleSeparator<TOption>(this TOption option, string separator) where TOption : DateRangePickerOption
        {

            option.LocaleAttributes["separator"] = string.Format("'{0}'", separator);
            return option;
        }

        /// <summary>
        /// "Apply"
        /// "ثبت"
        /// </summary>
        public static TOption LocaleApplyLabel<TOption>(this TOption option, string applyLabel) where TOption : DateRangePickerOption
        {

            option.LocaleAttributes["applyLabel"] = string.Format("'{0}'", applyLabel);
            return option;
        }

        /// <summary>
        /// "Cancel"
        /// "لغو"
        /// </summary>
        public static TOption LocaleCancelLabel<TOption>(this TOption option, string cancelLabel) where TOption : DateRangePickerOption
        {

            option.LocaleAttributes["cancelLabel"] = string.Format("'{0}'", cancelLabel);
            return option;
        }

        /// <summary>
        /// "From"
        /// "از"
        /// </summary>
        public static TOption LocaleFromLabel<TOption>(this TOption option, string fromLabel) where TOption : DateRangePickerOption
        {

            option.LocaleAttributes["fromLabel"] = string.Format("'{0}'", fromLabel);
            return option;
        }

        /// <summary>
        /// "To"
        /// "تا"
        /// </summary>
        public static TOption LocaleToLabel<TOption>(this TOption option, string toLabel) where TOption : DateRangePickerOption
        {

            option.LocaleAttributes["toLabel"] = string.Format("'{0}'", toLabel);
            return option;
        }

        /// <summary>
        /// "W"
        /// "هفته"
        /// </summary>
        public static TOption LocaleWeekLabel<TOption>(this TOption option, string weekLabel) where TOption : DateRangePickerOption
        {

            option.LocaleAttributes["weekLabel"] = string.Format("'{0}'", weekLabel);
            return option;
        }

        /// <summary>
        /// "Custom Range"
        /// "بازه دلخواه"
        /// </summary>
        /// <typeparam name="TOption"></typeparam>
        /// <param name="option"></param>
        /// <param name="customRangeLabel"></param>
        /// <returns></returns>
        public static TOption LocaleCustomRangeLabel<TOption>(this TOption option, string customRangeLabel) where TOption : DateRangePickerOption
        {

            option.LocaleAttributes["customRangeLabel"] = string.Format("'{0}'", customRangeLabel);
            return option;
        }

        /// <summary>
        /// moment.weekdaysMin()
        /// "[ 'Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa' ]"
        /// "[ 'ی' ,'د' ,'س' ,'چ' ,'پ' ,'ج' ,'ش' ]"
        /// </summary>
        public static TOption LocaleDaysOfWeek<TOption>(this TOption option, string daysOfWeek) where TOption : DateRangePickerOption
        {

            option.LocaleAttributes["daysOfWeek"] = daysOfWeek;
            return option;
        }


        /// <summary>
        /// new[] { "Su", "Mo", "Tu", "We", "Th", "Fr", "Sa" }
        /// new[] { "ی" ,"د" ,"س" ,"چ" ,"پ" ,"ج" ,"ش" }
        /// </summary>
        public static TOption LocaleDaysOfWeek<TOption>(this TOption option, string[] daysOfWeek) where TOption : DateRangePickerOption
        {

            option.LocaleAttributes["daysOfWeek"] = $"[ {string.Join(", ", daysOfWeek.Select(p => $"'{p}'"))} ]";
            return option;
        }

        /// <summary>
        /// moment.monthsShort()
        /// "[ 'January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December' ]"
        /// "[ 'فروردین' ,'اردیبهشت' ,'خرداد' ,'تیر' ,'مرداد' ,'شهریور' ,'مهر' ,'آبان' ,'آذر' ,'دی' ,'بهمن' ,'اسفند' ]"
        /// </summary>
        public static TOption LocaleMonthNames<TOption>(this TOption option, string monthNames) where TOption : DateRangePickerOption
        {
            option.LocaleAttributes["monthNames"] = monthNames;
            return option;
        }

        /// <summary>
        /// new[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" }
        /// new[] { "فروردین" ,"اردیبهشت" ,"خرداد" ,"تیر" ,"مرداد" ,"شهریور" ,"مهر" ,"آبان" ,"آذر" ,"دی" ,"بهمن" ,"اسفند" }
        /// </summary>
        public static TOption LocaleMonthNames<TOption>(this TOption option, string[] monthNames) where TOption : DateRangePickerOption
        {

            option.LocaleAttributes["daysOfWeek"] = $"[ {string.Join(", ", monthNames.Select(p => $"'{p}'"))} ]";
            return option;
        }

        /// <summary>
        /// moment.localeData().firstDayOfWeek()
        /// </summary>
        public static TOption LocaleFirstDay<TOption>(this TOption option, string firstDay) where TOption : DateRangePickerOption
        {

            option.LocaleAttributes["separator"] = firstDay;
            return option;
        }

        /// <summary>
        /// 1
        /// 6
        /// </summary>
        public static TOption LocaleFirstDay<TOption>(this TOption option, int firstDay) where TOption : DateRangePickerOption
        {
            option.LocaleAttributes["separator"] = firstDay;
            return option;
        }

        /// <summary>
        /// (object) Allows you to provide localized strings for buttons and labels, customize the date format, and change the first day of week for the calendars.
        /// Check off locale in the configuration generator to see how to customize these options.
        /// </summary>
        public static TOption Locale<TOption>(this TOption option, string locale) where TOption : DateRangePickerOption
        {
            option.Attributes["locale"] = locale;
            return option;
        }

        /// <summary>
        /// (object) Allows you to provide localized strings for buttons and labels, customize the date format, and change the first day of week for the calendars.
        /// Check off locale in the configuration generator to see how to customize these options.
        /// </summary>
        public static TOption LocaleEn<TOption>(this TOption option, string locale =
            @"{
	            'direction': 'ltr',
	            'format': moment.localeData().longDateFormat('L'),
	            'separator': ' - ',
	            'applyLabel': 'Apply',
	            'cancelLabel': 'Cancel',
                'fromLabel': 'From',
                'toLabel': 'To',
	            'weekLabel': 'W',
	            'customRangeLabel': 'Custom Range',
	            'daysOfWeek': moment.weekdaysMin(),
	            'monthNames': moment.monthsShort(),
	            'firstDay': moment.localeData().firstDayOfWeek()
            }") where TOption : DateRangePickerOption
        {
            #region LocaleEN
            //@"{
            //    'direction': 'ltr',
            //    'format': 'MM/DD/YYYY',
            //    'separator': ' - ',
            //    'applyLabel': 'Apply',
            //    'cancelLabel': 'Cancel',
            //    'fromLabel': 'From',
            //    'toLabel': 'To',
            //    'weekLabel': 'W',
            //    'customRangeLabel': 'Custom',
            //    'daysOfWeek': [ 'Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa' ],
            //    'monthNames': [ 'January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December' ],
            //    'firstDay': 1
            //}";
            #endregion
            option.Attributes["locale"] = locale;
            return option;
        }

        /// <summary>
        /// (object) Allows you to provide localized strings for buttons and labels, customize the date format, and change the first day of week for the calendars.
        /// Check off locale in the configuration generator to see how to customize these options.
        /// </summary>
        public static TOption LocaleFa<TOption>(this TOption option, string locale =
            @"{
	            'direction': 'rtl',
                'format': 'jYYYY/jMM/jDD',
                'separator': ' - ',
                'applyLabel': 'ثبت',
                'cancelLabel': 'لغو',
                'fromLabel': 'از',
                'toLabel': 'تا',
                'customRangeLabel': 'بازه دلخواه',
                'weekLabel': 'هفته',
                'daysOfWeek': ['ی', 'د', 'س', 'چ', 'پ', 'ج', 'ش'],
                'monthNames': ['فروردین', 'اردیبهشت', 'خرداد', 'تیر', 'مرداد', 'شهریور', 'مهر', 'آبان', 'آذر', 'دی', 'بهمن', 'اسفند'],
                'firstDay': 6
            }") where TOption : DateRangePickerOption
        {
            option.Attributes["locale"] = locale;
            return option;
        }
        #endregion

        public static TOption JalaaliRTL<TOption>(this TOption option, bool jalaaliRtl) where TOption : DateRangePickerOption
        {
            option.JalaaliRTL = jalaaliRtl;
            option.Attributes["jalaali"] = jalaaliRtl.ToString().ToLower();
            return option;
        }

        public static TOption Theme<TOption>(this TOption option, DateRangePickerTheme theme) where TOption : DateRangePickerOption
        {
            option.Theme = theme;
            return option;
        }

        #region Not Implemented Items (Maybe TODO)
        //------- options -------
        //isInvalidDate
        //isCustomDate
        //------- methods -------
        //setStartDate
        //setEndDate
        //------- event -------
        //show.daterangepicker
        //hide.daterangepicker
        //showCalendar.daterangepicker
        //hideCalendar.daterangepicker
        //apply.daterangepicker
        //cancel.daterangepicker
        #endregion
    }

    public enum OpensDirection
    {
        Left,
        Right,
        Center
    }

    public enum DropsDirection
    {
        Down,
        Up,
        Auto
    }

    public enum DateRangePickerTheme
    {
        Default,
        RTL_Red,
        RTL_Blue
    }
}
