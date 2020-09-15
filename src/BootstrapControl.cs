using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using DNZ.MvcComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Microsoft.AspNetCore.Mvc
{
    public static class BootstrapControl
    {
        public static IHtmlContent BsCheckBoxFor<TModel>(this IHtmlHelper<TModel> html, Expression<Func<TModel, bool>> expression, string icon = null, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4, object htmlAttribute = null)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out _, lable_col, dir);
            Dictionary<string, object> attributes = ComponentUtility.MergeAttributes(htmlAttribute, new { @class = "form-control", placeholder = displayName, dir = dirName, style });
            IHtmlContent editor = html.ICheckCheckBoxFor(expression, displayName, icon: icon);
            string result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }

        public static IHtmlContent BsTextBoxFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string icon = null, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4, object htmlAttribute = null)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out _, lable_col, dir);
            Dictionary<string, object> attributes = ComponentUtility.MergeAttributes(htmlAttribute, new { @class = "form-control", placeholder = displayName, dir = dirName, style });
            IHtmlContent editor = html.TextBoxFor(expression, attributes);
            string result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }
        public static IHtmlContent BsEmailTextBoxFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string icon = null, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4, object htmlAttribute = null)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out _, lable_col, dir);
            Dictionary<string, object> attributes = ComponentUtility.MergeAttributes(htmlAttribute,
                new { @class = "form-control", placeholder = displayName, dir = dirName, style, type = "email" });
            IHtmlContent editor = html.TextBoxFor(expression, attributes);
            string result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }
        public static IHtmlContent BsNumberTextBoxFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string icon = null, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4, object htmlAttribute = null)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out _, lable_col, dir);
            Dictionary<string, object> attributes = ComponentUtility.MergeAttributes(htmlAttribute,
                new { @class = "form-control", placeholder = displayName, dir = dirName, style, type = "number" });
            IHtmlContent editor = html.TextBoxFor(expression, attributes);
            string result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }
        public static IHtmlContent BsPhoneTextBoxFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string icon = null, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4, object htmlAttribute = null)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out _, lable_col, dir);
            Dictionary<string, object> attributes = ComponentUtility.MergeAttributes(htmlAttribute,
                new { @class = "form-control", placeholder = displayName, dir = dirName, style, type = "tel" });
            IHtmlContent editor = html.TextBoxFor(expression, attributes);
            string result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }

        public static IHtmlContent BsEditorFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string icon = null, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4, object htmlAttribute = null)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out _, lable_col, dir);
            Dictionary<string, object> attributes = ComponentUtility.MergeAttributes(htmlAttribute, new { @class = "form-control", placeholder = displayName, dir = dirName, style });
            IHtmlContent editor = html.EditorFor(expression, new { htmlAttributes = attributes });
            string result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }

        public static IHtmlContent BsCheckboxEditorFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string icon = null, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4, object htmlAttribute = null)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out _, lable_col, dir);
            Dictionary<string, object> attributes = ComponentUtility.MergeAttributes(htmlAttribute, new { placeholder = displayName, dir = dirName, style });
            IHtmlContent editor = html.EditorFor(expression, new { htmlAttributes = attributes });
            string result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }

        public static IHtmlContent BsInputMaskFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string regex, string icon = null, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4, object htmlAttribute = null)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out _, lable_col, dir);
            Dictionary<string, object> attributes = ComponentUtility.MergeAttributes(htmlAttribute, new { @class = "form-control", placeholder = displayName, dir = dirName, style });
            InputMaskOption<TModel, TValue> editor = html.InputMaskRegexFor(expression, regex, attributes);
            string result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }

        public static IHtmlContent BsInputMaskFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, InputMaskType type, string icon = null, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4, object htmlAttribute = null)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out _, lable_col, dir);
            Dictionary<string, object> attributes = ComponentUtility.MergeAttributes(htmlAttribute, new { @class = "form-control", placeholder = displayName, dir = dirName, style });
            InputMaskOption<TModel, TValue> editor = html.InputMaskFor(expression, type, attributes.ToAnonymousObject());
            string result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }

        public static IHtmlContent BsSelect2MultipleFor<TModel, TValue, T1, T2, T3, T4>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Dictionary<T1, T2> source1, Dictionary<T3, T4> source2, bool unique = true, int lable_col = 2, int editor_col = 4, string width = "100%", DropDownType type1 = DropDownType.Selec2DropDown, DropDownType type2 = DropDownType.Selec2DropDown)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out _, lable_col, ComponentDirection.RightToLeft);
            IHtmlContent editor = html.Select2MultipleFor(expression, source1, source2, unique, width, col2Style: "width: 35%", type1: type1, type2: type2);
            //var result = SetTemplate(label, icon, editor_col, validator, editor, dirName);
            string result =
                "<div class=\"form-group\">"
                    + label
                    + "<div class=\"col-sm-" + (editor_col / 2) + "\" style=\"padding: 0\">"
                         //+ validator
                         + editor
                    + "</div>"
                    + "<div class=\"col-sm-6\"></div>"
                + "</div>";
            return new HtmlString(result);
        }

        public static IHtmlContent BsPelakFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string pelak1Title = "", string pelak2Title = "پلاک", int lable_col = 2, int editor_col = 4)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out _, lable_col, ComponentDirection.RightToLeft);
            IHtmlContent editor = html.PelakFor(expression, new { placeholder = pelak1Title }, new { placeholder = pelak2Title });
            string result = SetTemplate(label, null, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }

        public static IHtmlContent BsTypeaheadFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Dictionary<int, string> source, TypeaheadOption option, string icon = null, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4, object htmlAttribute = null)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out _, lable_col, dir);
            Dictionary<string, object> attributes = ComponentUtility.MergeAttributes(htmlAttribute, new { @class = "form-control", placeholder = displayName, dir = dirName, style });
            IHtmlContent editor = html.TypeaheadFor(expression, source, option, attributes);
            string result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }

        public static IHtmlContent BsTypeaheadFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Dictionary<int, string> source, string icon = null, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4, object htmlAttribute = null)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out _, lable_col, dir);
            Dictionary<string, object> attributes = ComponentUtility.MergeAttributes(htmlAttribute, new { @class = "form-control", placeholder = displayName, dir = dirName, style });
            IHtmlContent editor = html.TypeaheadFor(expression, source, attributes);
            string result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }

        public static IHtmlContent BsTextAreaFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string icon = null, int row = 3, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4, object htmlAttribute = null)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out _, lable_col, dir);
            Dictionary<string, object> attributes = ComponentUtility.MergeAttributes(htmlAttribute, new { @class = "form-control", placeholder = displayName, rows = row, dir = dirName, style });
            IHtmlContent editor = html.TextAreaFor(expression, attributes);
            string result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }

        public static IHtmlContent BsPasswordFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string icon = null, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4, object htmlAttribute = null)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out _, lable_col, dir);
            Dictionary<string, object> attributes = ComponentUtility.MergeAttributes(htmlAttribute, new { @class = "form-control", placeholder = displayName, dir = dirName, style });
            IHtmlContent editor = html.PasswordFor(expression, attributes);
            string result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }

        public static IHtmlContent BsDropDownFor<TModel, TValue, T1, T2>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Dictionary<T1, T2> source, string defaultValue = null, string icon = null, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4, object htmlAttribute = null)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out var value, lable_col, dir);
            SelectList selectList = new SelectList(source, "Key", "Value", value);
            List<SelectListItem> items = selectList.Cast<SelectListItem>().ToList();
            if (defaultValue.HasValue())
            {
                items.Insert(0, new SelectListItem { Value = "", Text = defaultValue });
            }

            Dictionary<string, object> attributes = ComponentUtility.MergeAttributes(htmlAttribute, new { @class = "form-control", placeholder = displayName, dir = dirName, style });
            IHtmlContent editor = html.DropDownListFor(expression, items, attributes);
            string result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }

        public static IHtmlContent BsListBoxFor<TModel, TValue, T1, T2>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Dictionary<T1, T2> source, string defaultValue = null, string icon = null, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4, object htmlAttribute = null)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out var value, lable_col, dir);
            SelectList selectList = new SelectList(source, "Key", "Value", value);
            List<SelectListItem> items = selectList.Cast<SelectListItem>().ToList();
            if (!string.IsNullOrEmpty(defaultValue))
            {
                items.Insert(0, new SelectListItem { Value = null, Text = defaultValue });
            }

            Dictionary<string, object> attributes = ComponentUtility.MergeAttributes(htmlAttribute, new { @class = "form-control", placeholder = displayName, dir = dirName, style });
            IHtmlContent editor = html.ListBoxFor(expression, items, attributes);
            string result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }

        public static IHtmlContent BsSelect2DropDown<TModel, T1, T2>(this IHtmlHelper<TModel> html, string name, T1 value, string displayName, Dictionary<T1, T2> source, string defaultValue = null, string icon = null, string validator = null, int lable_col = 2, int editor_col = 4, object htmlAttribute = null)
        {
            ComponentDirection? dir = null;
            SetVariables<TModel, object>(html, null, ref displayName, out var style, out var dirName, out var label, out _, out _, lable_col, dir);
            IHtmlContent editor = html.Select2DropDown(name, value, source, defaultValue, htmlAttribute);
            string result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
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

            IHtmlContent editor = html.Select2DropDownFor(expression, source, defaultValue, htmlAttribute, option);
            string result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
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

            IHtmlContent editor = html.Select2DropDownFor(expression, selectList, option: option);
            string result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
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

            IHtmlContent editor = html.Select2DropDownFor(expression, selectList, option: option);
            string result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }

        public static IHtmlContent BsSelect2ListBoxFor<TModel, TValue, T1, T2>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Dictionary<T1, T2> source, string defaultValue = null, string icon = null, Select2Option option = null, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out var value, lable_col, dir);
            SelectList selectList = new SelectList(source, "Key", "Value", value);
            IHtmlContent editor = html.Select2ListBoxFor(expression, source, defaultValue, option);
            string result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }

        public static IHtmlContent BsPersianDatePickerFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string icon = null, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4, object htmlAttribute = null)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out _, lable_col, dir);
            Dictionary<string, object> attributes = ComponentUtility.MergeAttributes(htmlAttribute, new { @class = "form-control", placeholder = displayName, dir = dirName, style });
            IHtmlContent editor = html.TarikhFarsiFor(expression, attributes, false);
            string result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }

        public static IHtmlContent BsPersianDateTimePickerFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string icon = null, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4, object htmlAttribute = null)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out _, lable_col, dir);
            Dictionary<string, object> attributes = ComponentUtility.MergeAttributes(htmlAttribute, new { @class = "form-control", placeholder = displayName, dir = dirName, style });
            IHtmlContent editor = html.TarikhFarsiFor(expression, attributes, true);
            string result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }

        public static IHtmlContent BsPersianDatePicker3PartFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, int lowYear = -5, int highYear = +5, string icon = null, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var style, out var dirName, out var label, out var validator, out _, lable_col, dir);
            IHtmlContent editor = html.DatePicker3Part(expression, lowYear, highYear);
            string result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }

        public static IHtmlContent BsICheckRadioButtonsFor<TModel>(this IHtmlHelper<TModel> html, Expression<Func<TModel, bool>> expression, List<Tuple<string, string, string>> values, ICheckStyle style = ICheckStyle.Flat_Blue, string icon = null, ComponentDirection? dir = null, int lable_col = 2, int editor_col = 4)
        {
            string displayName = null;
            SetVariables(html, expression, ref displayName, out var aaa, out var dirName, out var label, out var validator, out _, lable_col, dir);
            IHtmlContent editor = html.ICheckRadioButtonsFor(expression, values, style, icon);
            string result = SetTemplate(label, icon, editor_col, validator, editor.ToHtmlString(), dirName);
            return new HtmlString(result);
        }

        public static IHtmlContent BsJasnyUploaderFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string action = null, string controller = null, object routeValues = null, string urlImage = "", int lable_col = 2, int editor_col = 4/*, string cssClass = "default"*/, bool justPartial = false)
        {
            ModelExplorer metadata = html.GetModelExplorer(expression);
            string htmlFieldName = html.FieldNameFor(expression);
            string displayName = metadata.Metadata.DisplayName ?? metadata.Metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            JasnyUploaderOption<TModel, TValue> options = new JasnyUploaderOption<TModel, TValue>(html, expression) { JustPartial = justPartial };
            JasnyUploaderOption<TModel, TValue> editor = options.UploadUrlAction(action, controller, routeValues).UrlImage(urlImage);
            IHtmlContent validator = html.ValidationMessageFor(expression);
            string result = @"
                <div class=""form-group"">
                    <label class=""control-label col-sm-" + lable_col + @"""></label>
                    <div class=""input-group col-sm-" + editor_col + @""">
                        " + editor.ToHtmlString() + @"
                        <div>" + validator + @"</div>
                    </div>
                    <div class=""col-sm-6""></div>
                </div>";
            return new HtmlString(result);
        }

        public static IEnumerable<SelectListItem> GetDropDownList<T>(this IEnumerable<T> source, string textField = "Name", string valueField = "Id", string selectedValue = null) where T : class
        {
            List<SelectListItem> list = new List<SelectListItem>();// { new SelectListItem { Text = "-انتخاب کنید-", Value = string.Empty } };
            List<SelectListItem> lisData = source.Select(m => new SelectListItem
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
            ModelExplorer metadata = expression == null ? null : html.GetModelExplorer(expression);
            string htmlFieldName = expression == null ? null : html.FieldNameFor(expression);
            if (expression != null)
            {
                displayName = metadata.Metadata.DisplayName ?? metadata.Metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            }

            value = expression == null ? null : metadata.Model;

            ComponentDirection direction = dir ?? (Thread.CurrentThread.CurrentCulture.TextInfo.IsRightToLeft ? ComponentDirection.RightToLeft : ComponentDirection.LeftToRight);
            direction = ComponentDirection.RightToLeft;

            bool isRtl = direction == ComponentDirection.RightToLeft;
            dirName = direction.ToDescription();
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
            string cssClass = (string.IsNullOrEmpty(icon) ? "no-feedback" : "with-feedback");
            string iconElement = (string.IsNullOrEmpty(icon) ? "" : $@"<span class=""input-group-addon""><i class=""{icon}""></i></span>");
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
