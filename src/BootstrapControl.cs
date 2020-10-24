using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using DNZ.MvcComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Globalization;

namespace Microsoft.AspNetCore.Mvc
{
    public static class BootstrapControl
    {
        public static IHtmlContent BsCheckBoxFor<TModel>(this IHtmlHelper<TModel> html, Expression<Func<TModel, bool>> expression, string icon = null, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4, object htmlAttribute = null)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out _, lable_col, dir);
            var attributes = ComponentUtility.MergeAttributes(htmlAttribute, new { @class = "form-control", placeholder = displayName, dir = dirName, style });
            var editor = html.ICheckCheckBoxFor(expression, displayName, icon: icon);
            var result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }

        public static IHtmlContent BsTextBoxFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string icon = null, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4, object htmlAttribute = null)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out _, lable_col, dir);
            var attributes = ComponentUtility.MergeAttributes(htmlAttribute, new { @class = "form-control", placeholder = displayName, dir = dirName, style });
            var editor = html.TextBoxFor(expression, attributes);
            var result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }
        public static IHtmlContent BsEmailTextBoxFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string icon = null, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4, object htmlAttribute = null)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out _, lable_col, dir);
            var attributes = ComponentUtility.MergeAttributes(htmlAttribute,
                new { @class = "form-control", placeholder = displayName, dir = dirName, style, type = "email" });
            var editor = html.TextBoxFor(expression, attributes);
            var result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }
        public static IHtmlContent BsNumberTextBoxFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string icon = null, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4, object htmlAttribute = null)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out _, lable_col, dir);
            var attributes = ComponentUtility.MergeAttributes(htmlAttribute,
                new { @class = "form-control", placeholder = displayName, dir = dirName, style, type = "number" });
            var editor = html.TextBoxFor(expression, attributes);
            var result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }
        public static IHtmlContent BsPhoneTextBoxFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string icon = null, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4, object htmlAttribute = null)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out _, lable_col, dir);
            var attributes = ComponentUtility.MergeAttributes(htmlAttribute,
                new { @class = "form-control", placeholder = displayName, dir = dirName, style, type = "tel" });
            var editor = html.TextBoxFor(expression, attributes);
            var result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }

        public static IHtmlContent BsEditorFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string icon = null, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4, object htmlAttribute = null)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out _, lable_col, dir);
            var attributes = ComponentUtility.MergeAttributes(htmlAttribute, new { @class = "form-control", placeholder = displayName, dir = dirName, style });
            var editor = html.EditorFor(expression, new { htmlAttributes = attributes });
            var result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }

        public static IHtmlContent BsCheckboxEditorFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string icon = null, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4, object htmlAttribute = null)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out _, lable_col, dir);
            var attributes = ComponentUtility.MergeAttributes(htmlAttribute, new { placeholder = displayName, dir = dirName, style });
            var editor = html.EditorFor(expression, new { htmlAttributes = attributes });
            var result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }

        public static IHtmlContent BsInputMaskFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string regex, string icon = null, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4, object htmlAttribute = null)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out _, lable_col, dir);
            var attributes = ComponentUtility.MergeAttributes(htmlAttribute, new { @class = "form-control", placeholder = displayName, dir = dirName, style });
            var editor = html.InputMaskRegexFor(expression, regex, attributes);
            var result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }

        public static IHtmlContent BsInputMaskFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, InputMaskType type, string icon = null, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4, object htmlAttribute = null)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out _, lable_col, dir);
            var attributes = ComponentUtility.MergeAttributes(htmlAttribute, new { @class = "form-control", placeholder = displayName, dir = dirName, style });
            var editor = html.InputMaskFor(expression, type, attributes.ToAnonymousObject());
            var result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }

        public static IHtmlContent BsSelect2MultipleFor<TModel, TValue, T1, T2, T3, T4>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Dictionary<T1, T2> source1, Dictionary<T3, T4> source2, bool unique = true, int lable_col = 2, int editor_col = 4, string width = "100%", DropDownType type1 = DropDownType.Selec2DropDown, DropDownType type2 = DropDownType.Selec2DropDown)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out _, lable_col, ComponentDirection.RightToLeft);
            var editor = html.Select2MultipleFor(expression, source1, source2, unique, width, col2Style: "width: 35%", type1: type1, type2: type2);
            //var result = SetTemplate(label, icon, editor_col, validator, editor, dirName);
            var result =
                "<div class=\"form-group\">"
                    + label
                    + "<div class=\"col-sm-" + (editor_col / 2) + "\" style=\"padding: 0\">"
                         //+ validator
                         + editor.ToHtmlString()
                    + "</div>"
                    + "<div class=\"col-sm-6\"></div>"
                + "</div>";
            return new HtmlString(result);
        }

        public static IHtmlContent BsPelakFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string pelak1Title = "", string pelak2Title = "پلاک", int lable_col = 2, int editor_col = 4)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out _, lable_col, ComponentDirection.RightToLeft);
            var editor = html.PelakFor(expression, new { placeholder = pelak1Title }, new { placeholder = pelak2Title });
            var result = SetTemplate(label, null, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }

        public static IHtmlContent BsTypeaheadFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Dictionary<int, string> source, TypeaheadOption option, string icon = null, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4, object htmlAttribute = null)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out _, lable_col, dir);
            var attributes = ComponentUtility.MergeAttributes(htmlAttribute, new { @class = "form-control", placeholder = displayName, dir = dirName, style });
            var editor = html.TypeaheadFor(expression, source, option, attributes);
            var result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }

        public static IHtmlContent BsTypeaheadFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Dictionary<int, string> source, string icon = null, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4, object htmlAttribute = null)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out _, lable_col, dir);
            var attributes = ComponentUtility.MergeAttributes(htmlAttribute, new { @class = "form-control", placeholder = displayName, dir = dirName, style });
            var editor = html.TypeaheadFor(expression, source, attributes);
            var result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }

        public static IHtmlContent BsTextAreaFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string icon = null, int row = 3, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4, object htmlAttribute = null)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out _, lable_col, dir);
            var attributes = ComponentUtility.MergeAttributes(htmlAttribute, new { @class = "form-control", placeholder = displayName, rows = row, dir = dirName, style });
            var editor = html.TextAreaFor(expression, attributes);
            var result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }

        public static IHtmlContent BsPasswordFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string icon = null, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4, object htmlAttribute = null)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out _, lable_col, dir);
            var attributes = ComponentUtility.MergeAttributes(htmlAttribute, new { @class = "form-control", placeholder = displayName, dir = dirName, style });
            var editor = html.PasswordFor(expression, attributes);
            var result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }

        public static IHtmlContent BsDropDownFor<TModel, TValue, T1, T2>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Dictionary<T1, T2> source, string defaultValue = null, string icon = null, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4, object htmlAttribute = null)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out var value, lable_col, dir);
            var selectList = new SelectList(source, "Key", "Value", value);
            var items = selectList.Cast<SelectListItem>().ToList();
            if (defaultValue.HasValue())
            {
                items.Insert(0, new SelectListItem { Value = "", Text = defaultValue });
            }

            var attributes = ComponentUtility.MergeAttributes(htmlAttribute, new { @class = "form-control", placeholder = displayName, dir = dirName, style });
            var editor = html.DropDownListFor(expression, items, attributes);
            var result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }

        public static IHtmlContent BsListBoxFor<TModel, TValue, T1, T2>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Dictionary<T1, T2> source, string defaultValue = null, string icon = null, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4, object htmlAttribute = null)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out var value, lable_col, dir);
            var selectList = new SelectList(source, "Key", "Value", value);
            var items = selectList.Cast<SelectListItem>().ToList();
            if (!string.IsNullOrEmpty(defaultValue))
            {
                items.Insert(0, new SelectListItem { Value = null, Text = defaultValue });
            }

            var attributes = ComponentUtility.MergeAttributes(htmlAttribute, new { @class = "form-control", placeholder = displayName, dir = dirName, style });
            var editor = html.ListBoxFor(expression, items, attributes);
            var result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }

        public static IHtmlContent BsSelect2DropDown<TModel, T1, T2>(this IHtmlHelper<TModel> html, string name, T1 value, string displayName, Dictionary<T1, T2> source, string defaultValue = null, string icon = null, string validator = null, int lable_col = 2, int editor_col = 4, object htmlAttribute = null)
        {
            ComponentDirection? dir = null;
            SetVariables<TModel, object>(html, null, ref displayName, out var style, out var dirName, out var label, out _, out _, lable_col, dir);
            var editor = html.Select2DropDown(name, value, source, defaultValue, htmlAttribute);
            var result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }

        public static IHtmlContent BsSelect2DropDownFor<TModel, TValue, T1, T2>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression,
            Dictionary<T1, T2> source, string defaultValue = null, string icon = null,
            Select2Option option = null, ComponentDirection? dir = null,
            int lable_col = 2, int editor_col = 4, object htmlAttribute = null, bool isLtr = false)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out _, lable_col, dir);
            if (option == null)
            {
                option = new Select2Option(isLtr);
            }

            var editor = html.Select2DropDownFor(expression, source, defaultValue, htmlAttribute, option);
            var result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }

        public static IHtmlContent BsSelect2DropDownFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, List<SelectListItem> selectList, string icon = null, Select2Option option = null, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out _, lable_col, dir);
            if (option == null)
            {
                option = new Select2Option();
            }

            var editor = html.Select2DropDownFor(expression, selectList, option: option);
            var result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }

        public static IHtmlContent BsSelect2DropDownFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, SelectList selectList, string icon = null, Select2Option option = null, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out _, lable_col, dir);
            if (option == null)
            {
                option = new Select2Option();
            }

            var editor = html.Select2DropDownFor(expression, selectList, option: option);
            var result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }

        public static IHtmlContent BsSelect2ListBoxFor<TModel, TValue, T1, T2>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Dictionary<T1, T2> source, string defaultValue = null, string icon = null, Select2Option option = null, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out var value, lable_col, dir);
            var selectList = new SelectList(source, "Key", "Value", value);
            var editor = html.Select2ListBoxFor(expression, source, defaultValue, option);
            var result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }

        public static IHtmlContent BsPersianDatePickerFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string icon = null, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4, object htmlAttribute = null)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out _, lable_col, dir);
            var model = html.GetModelExplorer(expression).Model as IFormattable;
            var value = model?.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("fa-IR"));
            var attributes = ComponentUtility.MergeAttributes(htmlAttribute, new { @class = "form-control", placeholder = displayName, dir = dirName, style });
            var editor = html.PersianDateTimePickerFor(expression, value, attributes).Theme(DateRangePickerTheme.RTL_Blue);
            var result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }

        public static IHtmlContent BsPersianDateTimePickerFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string icon = null, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4, object htmlAttribute = null)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out _, lable_col, dir);
            var model = html.GetModelExplorer(expression).Model as IFormattable;
            var value = model?.ToString("yyyy/MM/dd HH:mm", CultureInfo.GetCultureInfo("fa-IR"));
            var attributes = ComponentUtility.MergeAttributes(htmlAttribute, new { @class = "form-control", placeholder = displayName, dir = dirName, style });
            var editor = html.PersianDateTimePickerFor(expression, value, attributes).Theme(DateRangePickerTheme.RTL_Blue);
            var result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }

        //public static IHtmlContent BsPersianDatePickerFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string icon = null, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4, object htmlAttribute = null)
        //{
        //    string displayName = null;
        //    SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out _, lable_col, dir);
        //    var attributes = ComponentUtility.MergeAttributes(htmlAttribute, new { @class = "form-control", placeholder = displayName, dir = dirName, style });
        //    var editor = html.TarikhFarsiFor(expression, attributes, false);
        //    var result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
        //    return new HtmlString(result);
        //}

        //public static IHtmlContent BsPersianDateTimePickerFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string icon = null, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4, object htmlAttribute = null)
        //{
        //    string displayName = null;
        //    SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out _, lable_col, dir);
        //    var attributes = ComponentUtility.MergeAttributes(htmlAttribute, new { @class = "form-control", placeholder = displayName, dir = dirName, style });
        //    var editor = html.TarikhFarsiFor(expression, attributes, true);
        //    var result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
        //    return new HtmlString(result);
        //}

        //public static IHtmlContent BsPersianDatePicker3PartFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, int lowYear = -5, int highYear = +5, string icon = null, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4)
        //{
        //    string displayName = null;
        //    SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out _, lable_col, dir);
        //    var editor = html.DatePicker3Part(expression, lowYear, highYear);
        //    var result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
        //    return new HtmlString(result);
        //}

        public static IHtmlContent BsICheckRadioButtonsFor<TModel>(this IHtmlHelper<TModel> html, Expression<Func<TModel, bool>> expression, List<Tuple<string, string, string>> values, ICheckStyle style = ICheckStyle.Flat_Blue, string icon = null, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var aaa, out var dirName, out var label, out var validator, out _, lable_col, dir);
            var editor = html.ICheckRadioButtonsFor(expression, values, style, icon);
            var result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }

        public static IHtmlContent BsJasnyUploaderFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string action = null, string controller = null, object routeValues = null, string urlImage = "", int lable_col = 2, int editor_col = 4/*, string cssClass = "default"*/, bool justPartial = false)
        {
            var metadata = html.GetModelExplorer(expression);
            var htmlFieldName = html.FieldNameFor(expression);
            var displayName = metadata.Metadata.DisplayName ?? metadata.Metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            var options = new JasnyUploaderOption<TModel, TValue>(html, expression) { JustPartial = justPartial };
            var editor = options.UploadUrlAction(action, controller, routeValues).UrlImage(urlImage);
            var validator = html.ValidationMessageFor(expression);
            var result = @"
                <div class=""form-group"">
                    <label class=""control-label col-sm-" + lable_col + @"""></label>
                    <div class=""input-group col-sm-" + editor_col + @""">
                        " + editor.ToHtmlString() + @"
                        <div>" + validator.ToHtmlString() + @"</div>
                    </div>
                    <div class=""col-sm-6""></div>
                </div>";
            return new HtmlString(result);
        }

        public static IEnumerable<SelectListItem> GetDropDownList<T>(this IEnumerable<T> source, string textField = "Name", string valueField = "Id", string selectedValue = null) where T : class
        {
            var list = new List<SelectListItem>();// { new SelectListItem { Text = "-انتخاب کنید-", Value = string.Empty } };
            var lisData = source.Select(m => new SelectListItem
            {
                Text = m.GetType().GetProperty(textField).GetValue(m, null).ToString(),
                Value = m.GetType().GetProperty(valueField).GetValue(m, null).ToString(),
                Selected = (selectedValue != null) && ((string)m.GetType().GetProperty(valueField).GetValue(m, null) == selectedValue),
            }).ToList();
            list.AddRange(lisData);
            return list;
        }

        private static void SetVariables<TModel, TValue>(this IHtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression,
            ref string displayName,
            out string style,
            out string dirName,
            out string label,
            out string validator,
            out object value,
            int lable_col,
            ComponentDirection? dir = null)
        {
            var metadata = expression == null ? null : html.GetModelExplorer(expression);
            var htmlFieldName = expression == null ? null : html.FieldNameFor(expression);
            if (expression != null)
            {
                displayName = metadata.Metadata.DisplayName ?? metadata.Metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            }

            value = expression == null ? null : metadata.Model;

            var direction =
                //dir ?? (Thread.CurrentThread.CurrentCulture.TextInfo.IsRightToLeft ? ComponentDirection.RightToLeft : ComponentDirection.LeftToRight);
                ComponentDirection.RightToLeft;

            var isRtl = direction == ComponentDirection.RightToLeft;
            dirName = direction.ToDisplayName();
            style = $"direction: {dirName}; text-align: {(isRtl ? "right" : "left")};";
            if (expression == null)
            {
                label = html.Label(displayName, displayName, new { @class = "control-label col-sm-" + lable_col }).ToHtmlString();
            }
            else
            {
                label = html.LabelFor(expression, new { @class = "control-label col-sm-" + lable_col }).ToHtmlString();
            }

            validator = expression == null ? null : html.ValidationMessageFor(expression, null, new { style = "display: table-footer-group;" }).ToHtmlString();
        }

        private static string SetTemplate(string label, string icon, int editor_col, string validator, string editor, string dirName)
        {
            var cssClass = (string.IsNullOrEmpty(icon) ? "no-feedback" : "with-feedback");
            var iconElement = (string.IsNullOrEmpty(icon) ? "" : $@"<span class=""input-group-addon""><i class=""{icon}""></i></span>");
            return
                $@"<div class=""form-group"">
                {label}
                <div class=""input-group {cssClass} component-{dirName} col-sm-{editor_col} addOn"">
                    {validator}
                    {editor}
                    {iconElement}
                </div>
            </div>";
        }
    }
}
