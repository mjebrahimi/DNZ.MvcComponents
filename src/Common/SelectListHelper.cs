using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.AspNetCore.Mvc.Rendering
{
    public static class SelectListHelper
    {
        public static IEnumerable<SelectListItem> GetSelectListItems<T>(this IEnumerable<T> source, string valueField = "Id", string textField = "Name", object selectedValue = null, string defaultText = "-انتخاب کنید-", string defaultValue = "")
        {
            //new SelectList(source, valueField, textField, selectedValue)

            var typeofT = typeof(T);
            var textProp = typeofT.GetProperty(textField);
            var valueProp = typeofT.GetProperty(valueField);
            var list = new List<SelectListItem> { new SelectListItem { Text = defaultText, Value = defaultValue } };
            var lisData = source.Select(p => new SelectListItem
            {
                Text = textProp.GetValue(p, null).ToString(),
                Value = valueProp.GetValue(p, null).ToString(),
                Selected = selectedValue?.Equals(valueProp.GetValue(p, null)) == true
            });
            list.AddRange(lisData);
            return list;
        }

        public static IEnumerable<SelectListItem> GetSelectListItems<T>(this IEnumerable<T> source, string valueField = "Id", string textField = "Name", IEnumerable<object> selectedValues = null, string defaultText = "-انتخاب کنید-", string defaultValue = "")
        {
            //new MultiSelectList(source, valueField, textField, selectedValues)

            var typeofT = typeof(T);
            var textProp = typeofT.GetProperty(textField);
            var valueProp = typeofT.GetProperty(valueField);
            var list = new List<SelectListItem> { new SelectListItem { Text = defaultText, Value = defaultValue } };
            var lisData = source.Select(p => new SelectListItem
            {
                Text = textProp.GetValue(p, null).ToString(),
                Value = valueProp.GetValue(p, null).ToString(),
                Selected = selectedValues?.Contains(valueProp.GetValue(p, null)) == true,
            }).ToList();
            list.AddRange(lisData);
            return list;
        }

        public static IEnumerable<SelectListItem> GetSelectListItems<T>(this T selectedValue) where T : struct, Enum
        {
            //Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper.GetEnumSelectList<TEnum>() where TEnum : struct;
            //Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper.GetEnumSelectList(Type enumType);

            var list = new List<SelectListItem>();
            var lisData = Enum.GetValues(selectedValue.GetType()).Cast<T>().Select(p => new SelectListItem
            {
                Text = p.ToString(),
                Value = Convert.ToInt32(p).ToString(),
                Selected = p.Equals(selectedValue),
            }).ToList();
            list.AddRange(lisData);
            return list;
        }
    }
}
