using System.Collections.Generic;

namespace Microsoft.AspNetCore.Mvc
{
    internal class MDPersianDatePicker
    {
    }

    public class MDPersianDatePickerOption : IOptionBuilder
    {
        public Dictionary<string, object> Attributes { get; set; }

        public MDPersianDatePickerOption Placement(Placement value)
        {
            Attributes["Placement"] = string.Format("'{0}'", value.ToString().ToLower());
            return this;
        }

        public MDPersianDatePickerOption Trigger(bool value)
        {
            Attributes["Trigger"] = string.Format("'{0}'", value);
            return this;
        }

        public MDPersianDatePickerOption TargetSelector(bool value)
        {
            Attributes["TargetSelector"] = string.Format("'{0}'", value);
            return this;
        }
        //public MDPersianDatePickerOption TargetSelector(bool value)
        //{
        //    Attributes["TargetSelector"] = string.Format("'{0}'", value);
        //    return this;
        //}
        //public MDPersianDatePickerOption TargetSelector(bool value)
        //{
        //    Attributes["TargetSelector"] = string.Format("'{0}'", value);
        //    return this;
        //}
        //public MDPersianDatePickerOption TargetSelector(bool value)
        //{
        //    Attributes["TargetSelector"] = string.Format("'{0}'", value);
        //    return this;
        //}
        //public MDPersianDatePickerOption TargetSelector(bool value)
        //{
        //    Attributes["TargetSelector"] = string.Format("'{0}'", value);
        //    return this;
        //}
        //public MDPersianDatePickerOption TargetSelector(bool value)
        //{
        //    Attributes["TargetSelector"] = string.Format("'{0}'", value);
        //    return this;
        //}
        //public MDPersianDatePickerOption TargetSelector(bool value)
        //{
        //    Attributes["TargetSelector"] = string.Format("'{0}'", value);
        //    return this;
        //}
        //public MDPersianDatePickerOption TargetSelector(bool value)
        //{
        //    Attributes["TargetSelector"] = string.Format("'{0}'", value);
        //    return this;
        //}
        //public MDPersianDatePickerOption TargetSelector(bool value)
        //{
        //    Attributes["TargetSelector"] = string.Format("'{0}'", value);
        //    return this;
        //}
        //public MDPersianDatePickerOption TargetSelector(bool value)
        //{
        //    Attributes["TargetSelector"] = string.Format("'{0}'", value);
        //    return this;
        //}
        //public MDPersianDatePickerOption TargetSelector(bool value)
        //{
        //    Attributes["TargetSelector"] = string.Format("'{0}'", value);
        //    return this;
        //}
        //public MDPersianDatePickerOption TargetSelector(bool value)
        //{
        //    Attributes["TargetSelector"] = string.Format("'{0}'", value);
        //    return this;
        //}
        //public MDPersianDatePickerOption TargetSelector(bool value)
        //{
        //    Attributes["TargetSelector"] = string.Format("'{0}'", value);
        //    return this;
        //}
        //public MDPersianDatePickerOption TargetSelector(bool value)
        //{
        //    Attributes["TargetSelector"] = string.Format("'{0}'", value);
        //    return this;
        //}
    }
}
