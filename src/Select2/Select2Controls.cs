using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using DNZ.MvcComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Microsoft.AspNetCore.Mvc
{
    public static class Select2Controls
    {
        private const string select2_css = "DNZ.MvcComponents.Select2.select2.css";
        private const string select2_custom_css = "DNZ.MvcComponents.Select2.select2.custom.css";
        private const string select2_js = "DNZ.MvcComponents.Select2.select2.full.js";

        public static IHtmlContent Select2DropDownFor<TModel, TValue, T1, T2>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Dictionary<T1, T2> source, string defaultValue = null, object htmlAttribute = null, Select2Option option = null)
        {
            option = option ?? new Select2Option();
            ViewFeatures.ModelExplorer metadata = ExpressionMetadataProvider.FromLambdaExpression(expression, html.ViewData, html.MetadataProvider);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string id = html.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName);
            string displayName = metadata.Metadata.DisplayName ?? metadata.Metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            object value = metadata.Model;// == null ? null : Convert.ChangeType(metadata.Model, typeof(T1));
            SelectList selectList = new SelectList(source, "Key", "Value", value);
            List<SelectListItem> items = selectList.Cast<SelectListItem>().ToList();
            if (defaultValue.HasValue())
            {
                items.Insert(0, new SelectListItem { Value = "", Text = defaultValue });
            }

            Dictionary<string, object> attributes = ComponentUtility.MergeAttributes(htmlAttribute, new { @class = "form-control", placeholder = displayName, style = "width: 100%" });
            IHtmlContent editor = html.DropDownListFor(expression, items, attributes);
            string result =
                editor.ToHtmlString() +
                html.StyleFileSingle(@"<link href=""" + ComponentUtility.GetWebResourceUrl(select2_css) + @""" rel=""stylesheet"" />").ToHtmlString() +
                html.StyleFileSingle(@"<link href=""" + ComponentUtility.GetWebResourceUrl(select2_custom_css) + @""" rel=""stylesheet"" />").ToHtmlString() +
                (option.Attributes["language"] == null ? "" : html.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(string.Format("DNZ.MvcComponents.Select2.i18n.{0}.js", option.Attributes["language"].ToString().Trim('\''))) + @"""></script>").ToHtmlString()) +
                html.ScriptFileSingle(@" <script src=""" + ComponentUtility.GetWebResourceUrl(select2_js) + @"""></script>").ToHtmlString() +
                html.Script(@"
            <script>
                $(function(){
                    $(""#" + id + @""").select2(" + option.RenderOptions() + @").change(function () { 
                        $(this).valid();
                    });
                });
            </script>").ToHtmlString();
            return new HtmlString(result);
        }

        public static IHtmlContent Select2DropDownFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression,
            SelectList selectList,string defaultValue = null,
            object htmlAttribute = null, Select2Option option = null, bool isLtr = false)
        {
            option = option ?? new Select2Option(isLtr);
            ViewFeatures.ModelExplorer metadata = ExpressionMetadataProvider.FromLambdaExpression(expression, html.ViewData, html.MetadataProvider);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string id = html.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName);
            string displayName = metadata.Metadata.DisplayName ?? metadata.Metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            object value = metadata.Model;
            List<SelectListItem> items = selectList.Cast<SelectListItem>().ToList();
            if (defaultValue.HasValue())
            {
                items.Insert(0, new SelectListItem { Value = "", Text = defaultValue });
            }

            Dictionary<string, object> attributes = ComponentUtility.MergeAttributes(htmlAttribute, new { @class = "form-control", placeholder = displayName, style = "width: 100%" });
            IHtmlContent editor = html.DropDownListFor(expression, items, attributes);
            string result =
                editor.ToHtmlString() +
                html.StyleFileSingle(@"<link href=""" + ComponentUtility.GetWebResourceUrl(select2_css) + @""" rel=""stylesheet"" />").ToHtmlString() +
                html.StyleFileSingle(@"<link href=""" + ComponentUtility.GetWebResourceUrl(select2_custom_css) + @""" rel=""stylesheet"" />").ToHtmlString() +
                (option.Attributes["language"] == null ? "" : html.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(string.Format("DNZ.MvcComponents.Select2.i18n.{0}.js", option.Attributes["language"].ToString().Trim('\''))) + @"""></script>").ToHtmlString()) +
                html.ScriptFileSingle(@" <script src=""" + ComponentUtility.GetWebResourceUrl(select2_js) + @"""></script>").ToHtmlString() +
                html.Script(@"
            <script>
                $(function(){
                    $(""#" + id + @""").select2(" + option.RenderOptions() + @").change(function () { 
                        $(this).valid();
                    });
                });
            </script>").ToHtmlString();
            return new HtmlString(result);
        }

        public static IHtmlContent Select2DropDownFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, List<SelectListItem> selectList, string defaultValue = null, object htmlAttribute = null, Select2Option option = null)
        {
            option = option ?? new Select2Option();
            ViewFeatures.ModelExplorer metadata = ExpressionMetadataProvider.FromLambdaExpression(expression, html.ViewData, html.MetadataProvider);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string id = html.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName);
            string displayName = metadata.Metadata.DisplayName ?? metadata.Metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            object value = metadata.Model;
            List<SelectListItem> items = selectList.Cast<SelectListItem>().ToList();
            if (defaultValue.HasValue())
            {
                items.Insert(0, new SelectListItem { Value = "", Text = defaultValue });
            }

            Dictionary<string, object> attributes = ComponentUtility.MergeAttributes(htmlAttribute, new { @class = "form-control", placeholder = displayName, style = "width: 100%" });
            IHtmlContent editor = html.DropDownListFor(expression, items, attributes);
            string result =
                editor.ToHtmlString() +
                html.StyleFileSingle(@"<link href=""" + ComponentUtility.GetWebResourceUrl(select2_css) + @""" rel=""stylesheet"" />").ToHtmlString() +
                html.StyleFileSingle(@"<link href=""" + ComponentUtility.GetWebResourceUrl(select2_custom_css) + @""" rel=""stylesheet"" />").ToHtmlString() +
                (option.Attributes["language"] == null ? "" : html.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(string.Format("DNZ.MvcComponents.Select2.i18n.{0}.js", option.Attributes["language"].ToString().Trim('\''))) + @"""></script>").ToHtmlString()) +
                html.ScriptFileSingle(@" <script src=""" + ComponentUtility.GetWebResourceUrl(select2_js) + @"""></script>").ToHtmlString() +
                html.Script(@"
            <script>
                $(function(){
                    $(""#" + id + @""").select2(" + option.RenderOptions() + @").change(function () { 
                        $(this).valid();
                    });
                });
            </script>").ToHtmlString();
            return new HtmlString(result);
        }

        public static IHtmlContent Select2DropDown<T1, T2>(this IHtmlHelper html, string name, T1 value, Dictionary<T1, T2> source, string defaultValue = null, object htmlAttribute = null, Select2Option option = null)
        {
            option = option ?? new Select2Option();
            string id = html.ViewData.TemplateInfo.GetFullHtmlFieldId(name);
            SelectList selectList = new SelectList(source, "Key", "Value", value);
            List<SelectListItem> items = selectList.Cast<SelectListItem>().ToList();
            //if (defaultValue.HasValue())
            //    items.Insert(0, new SelectListItem { Value = null, Text = defaultValue });
            Dictionary<string, object> attributes = ComponentUtility.MergeAttributes(htmlAttribute, new { @class = "form-control", style = "width: 100%" });
            IHtmlContent editor = html.DropDownList(name, items, defaultValue, attributes);
            string result =
                editor.ToHtmlString() +
                html.StyleFileSingle(@"<link href=""" + ComponentUtility.GetWebResourceUrl(select2_css) + @""" rel=""stylesheet"" />").ToHtmlString() +
                html.StyleFileSingle(@"<link href=""" + ComponentUtility.GetWebResourceUrl(select2_custom_css) + @""" rel=""stylesheet"" />").ToHtmlString() +
                (option.Attributes["language"] == null ? "" : html.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(string.Format("DNZ.MvcComponents.Select2.i18n.{0}.js", option.Attributes["language"].ToString().Trim('\''))) + @"""></script>").ToHtmlString()) +
                html.ScriptFileSingle(@" <script src=""" + ComponentUtility.GetWebResourceUrl(select2_js) + @"""></script>").ToHtmlString() +
                html.Script(@"
            <script>
                $(function(){
                    $(""#" + id + @""").select2(" + option.RenderOptions() + @").change(function () { 
                        $(this).valid();
                    });
                });
            </script>").ToHtmlString();
            return new HtmlString(result);
        }

        public static IHtmlContent Select2ListBoxFor<TModel, TValue, T1, T2>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Dictionary<T1, T2> source, string defaultValue = null, object htmlAttribute = null, Select2Option option = null)
        {
            option = option ?? new Select2Option();
            ViewFeatures.ModelExplorer metadata = ExpressionMetadataProvider.FromLambdaExpression(expression, html.ViewData, html.MetadataProvider);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string id = html.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName);
            string displayName = metadata.Metadata.DisplayName ?? metadata.Metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            object value = metadata.Model;// == null ? null : Convert.ChangeType(metadata.Model, typeof(T1));
            SelectList selectList = new SelectList(source, "Key", "Value", value);
            List<SelectListItem> items = selectList.Cast<SelectListItem>().ToList();
            if (defaultValue.HasValue())
            {
                items.Insert(0, new SelectListItem { Value = null, Text = defaultValue });
            }

            Dictionary<string, object> attributes = ComponentUtility.MergeAttributes(htmlAttribute, new { @class = "form-control", style = "width: 100%", placeholder = displayName });
            IHtmlContent editor = html.ListBoxFor(expression, items, attributes);
            string result =
                editor.ToHtmlString() +
                html.StyleFileSingle(@"<link href=""" + ComponentUtility.GetWebResourceUrl(select2_css) + @""" rel=""stylesheet"" />") +
                html.StyleFileSingle(@"<link href=""" + ComponentUtility.GetWebResourceUrl(select2_custom_css) + @""" rel=""stylesheet"" />") +
                html.ScriptFileSingle(@" <script src=""" + ComponentUtility.GetWebResourceUrl(select2_js) + @"""></script>") +
                (option.Attributes["language"] == null ? "" : html.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(string.Format("DNZ.MvcComponents.Select2.i18n.{0}.js", option.Attributes["language"].ToString().Trim('\''))) + @"""></script>").ToHtmlString()) +
                html.Script(@"
            <script>
                $(function(){
                    $(""#" + id + @""").select2(" + option.RenderOptions() + @");
                });
            </script>");
            return new HtmlString(result);
        }

        public static IHtmlContent Select2MultipleFor<TModel, TValue, T1, T2, T3, T4>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Dictionary<T1, T2> source1, Dictionary<T3, T4> source2, bool unique = true, string width = "100%", string col1Style = "", string col2Style = "", DropDownType type1 = DropDownType.Selec2DropDown, DropDownType type2 = DropDownType.Selec2DropDown)
        {
            ViewFeatures.ModelExplorer metadata = ExpressionMetadataProvider.FromLambdaExpression(expression, html.ViewData, html.MetadataProvider);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string id = html.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName);
            string name = html.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName);
            string displayName = metadata.Metadata.DisplayName ?? metadata.Metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            //var value = metadata.Model == null ? new List<KeyValuePair<string,string>>() : (IEnumerable<KeyValuePair<string, string>>)metadata.Model ;
            KeyValuePair<T1, T3>[] value = (((IEnumerable<KeyValuePair<T1, T3>>)metadata.Model) ?? new List<KeyValuePair<T1, T3>>()).ToArray();
            string id1 = id + "_Select1";
            string id2 = id + "_Select2";
            string divId = id + "_MultipleSelect";
            string template =
                @"<tr class=""row-multipleSelect"">
                <td style='" + col1Style + @"'>
                    {0}
                </td>
                <td style='" + col2Style + @"'>
                    {1}
                </td>
                <td style=""width: 35px; text-align: center;vertical-align: top; padding-top: 13px;"">
                    {2}
                </td>
            </tr>";
            const string imgPlus = @"<button class=""btn btn-primary btn-xs add-item""><i class=""fa fa-plus fa-lg""></i></button>";
            const string imgMinus = @"<button class=""btn btn-danger btn-xs remove-item"" style=""opacity: 0.8;""><i class=""fa fa-minus fa-lg""></i></button>";
            string item1 = "";
            string item2 = "";
            switch (type1)
            {
                case DropDownType.DropDownList:
                    item1 = html.DropDownList(id1, new SelectList(source1, "Key", "Value"), new { @class = "form-control", style = "width: 100%" }).ToHtmlString();
                    break;
                case DropDownType.Selec2DropDown:
                    item1 = html.Select2DropDown(id1, default, source1).ToHtmlString();
                    break;
            }
            switch (type2)
            {
                case DropDownType.DropDownList:
                    item2 = html.DropDownList(id2, new SelectList(source2, "Key", "Value"), new { @class = "form-control", style = "width: 100%" }).ToHtmlString();
                    break;
                case DropDownType.Selec2DropDown:
                    item2 = html.Select2DropDown(id2, default, source2).ToHtmlString();
                    break;
            }
            string result = string.Format(template,
                item1 +
                html.HiddenFor(expression, new { Name = id + "_HiddenInput" }).ToHtmlString() +
                html.ValidationMessageFor(expression, null, new Dictionary<string, object> { ["data-valmsg-for"] = id + "_HiddenInput" }).ToHtmlString(),
                item2,
                imgPlus);
            for (int i = 0; i < value.Length; i++)
            {
                KeyValuePair<T1, T3> item = value[i];
                string name1 = name + string.Format("[{0}].Key", i);
                string name2 = name + string.Format("[{0}].Value2", i);
                string text1 = source1[item.Key].ConvertTo<string>();
                string text2 = source2[item.Value].ConvertTo<string>();
                result += string.Format(template,
                html.Label("", text1, new { style = "color: black;" }).ToHtmlString() + "\n" +
                html.Hidden(name1, item.Key).ToHtmlString(),
                html.Label("", text2, new { style = "color: black;" }).ToHtmlString() + "\n" +
                html.Hidden(name2, item.Value).ToHtmlString(),
                imgMinus);
            }
            string values = string.Join(", \n", value.Select(p => string.Format("{{ value1: {0}, value2: {1} }}", p.Key, p.Value)));
            html.Script(@"
            <script>
                $(function(){
                    var index = " + value.Length + @";
                    var array = [ " + values + @" ];
                    $(""#" + divId + @" .add-item"").click(function (e) {
                        e.preventDefault();
                        var select1 = $(""#" + id1 + @""");
                        var select2 = $(""#" + id2 + @""");
                        var text1 = select1.find(""option:selected"").text();
                        var value1 = select1.val();
                        var text2 = select2.find(""option:selected"").text();
                        var value2 = select2.val();
                        var item = { value1: value1, value2: value2 };
                        var isUnique = true;
                        " + (unique ? @"array.forEach(function(entry) {
                            if (entry.value1 == value1 && entry.value2 == value2)
                                isUnique = false
                        });" : "") + @"
                        if (isUnique) {
                            array.push(item);
                            var htmlString = '<tr class=""row-multipleSelect"">' +
                            '    <td>' +
                            '        <label style=""color: black;"">' + text1 + '</label>' +
                            '        <input type=""hidden"" name=""" + name + "[' + index + '].Key" + @""" value=""' + value1 + '"" />' +
                            '    </td>' +
                            '    <td>' +
                            '        <label style=""color: black;"">' + text2 + '</label>' +
                            '        <input type=""hidden"" name=""" + name + "[' + index + '].Value" + @""" value=""' + value2 + '"" />' +
                            '    </td>' +
                            '    <td style=""width: 35px; text-align: center;vertical-align: middle;"">' +
                            '        " + imgMinus + @"' +
                            '    </td>' +
                            '</tr>';
                            var newItem = $(htmlString);
                            $(this).closest(""#" + divId + @""").append(newItem);
                            $(""input[name=" + id + @"_HiddenInput]"").val(""HasValue"").trigger('change').valid();
                            $(""#" + divId + @" .remove-item"").click(function (e) {
                                e.preventDefault();
                                var hid = $(this).closest("".row-multipleSelect"").find(""input:hidden"");
                                var value1 = hid.eq(0).val();
                                var value2 = hid.eq(1).val();
                                $(this).closest("".row-multipleSelect"").remove();
                                index--;
                                " + (unique ? @"array.forEach(function(entry, ii) {
                                    if (entry.value1 == value1 && entry.value2 == value2) {
                                        array.splice(ii, 1);
                                        if (array.length == 0)
                                            $(""input[name=" + id + @"_HiddenInput]"").val('').trigger('change').valid();
                                    }
                                });" : "") + @"
                            });
                            index++;
                        }
                    });
                    $(""#" + divId + @" .remove-item"").click(function (e) {
                        e.preventDefault();
                        var hid = $(this).closest("".row-multipleSelect"").find(""input:hidden"");
                        var value1 = hid.eq(0).val();
                        var value2 = hid.eq(1).val();
                        $(this).closest("".row-multipleSelect"").remove();
                        index--;
                        " + (unique ? @"array.forEach(function(entry, ii) {
                            if (entry.value1 == value1 && entry.value2 == value2) {
                                array.splice(ii, 1);
                                if (array.length == 0)
                                    $(""input[name=" + id + @"_HiddenInput]"").val('').trigger('change').valid();
                            }
                        });" : "") + @"
                    });
                });
            </script>");
            return new HtmlString(@"<table id=""" + divId + @""" style=""width: " + width + @""" class=""table table-hover"">
                                    " + result + @"
                                    </table>");
        }
    }
}