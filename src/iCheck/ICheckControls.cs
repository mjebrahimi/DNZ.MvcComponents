using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using DNZ.MvcComponents;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

//[assembly: WebResource("DNZ.MvcComponents.iCheck.all.css", "text/css", PerformSubstitution = true)]
namespace Microsoft.AspNetCore.Mvc
{
    public static class ICheckControls
    {
        //http://icheck.fronteed.com/
        //https://cdnjs.com/libraries/iCheck
        private const string iCheck_all_css_cdn = "<link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/iCheck/1.0.3/skins/all.min.css\" integrity=\"sha512-wcKDxok85zB8F9HzgUwzzzPKJhHG7qMfC7bSKrZcFTC2wZXVhmgKNXYuid02cHVnFSC8KOJCXQ8M83UVA7v5Bw==\" crossorigin=\"anonymous\" />";
        private const string iCheck_js_cdn = "<script src=\"https://cdnjs.cloudflare.com/ajax/libs/iCheck/1.0.3/icheck.min.js\" integrity=\"sha512-RGDpUuNPNGV62jwbX1n/jNVUuK/z/GRbasvukyOim4R8gUEXSAjB4o0gBplhpO8Mv9rr7HNtGzV508Q1LBGsfA==\" crossorigin=\"anonymous\"></script>";
        private const string iCheck_all_css = "DNZ.MvcComponents.iCheck.all.css";
        private const string iCheck_js = "DNZ.MvcComponents.iCheck.icheck.min.js";
        private const string iCheck_custom_js = "DNZ.MvcComponents.iCheck.icheck.custom.js";

        public static IHtmlContent ICheckRadioButtonFor<TModel>(this IHtmlHelper<TModel> html, Expression<Func<TModel, bool>> expression, string label = null, object value = null, ICheckStyle style = ICheckStyle.Flat_Blue, string icon = null)
        {
            //string htmlFieldName = html.FieldNameFor(expression);
            //ModelExplorer metadata = html.GetModelExplorer(expression);
            //var displayName = metadata.Metadata.DisplayName ?? metadata.Metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            //var name = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName);

            var id = html.FieldIdFor(expression);
            var cssClass = " " + style.ToString().ToLower().Replace('_', '-');
            if (value == null)
            {
                value = "";
            }

            var result =
    html.StyleFileSingle(ComponentUtility.GetCssTag(iCheck_all_css, iCheck_all_css_cdn)).ToHtmlString()
    + @"
<label for=""" + id + "_" + Guid.NewGuid() + @""">
    " + html.RadioButtonFor(expression, value, new { @class = "icheck" + cssClass, id = id + "_" + Guid.NewGuid() }).ToHtmlString() + @"
    " + (string.IsNullOrEmpty(icon) ? "" : @"<i class=""fa " + icon + @""" style=""font-size: large;""></i>") + " " + label + @"
</label>"
     + html.ScriptFileSingle(ComponentUtility.GetJsTag(iCheck_js, iCheck_js_cdn)).ToHtmlString()
     + html.ScriptFileSingle(ComponentUtility.GetJsTag(iCheck_custom_js, null)).ToHtmlString();
            return new HtmlString(result);
        }

        public static IHtmlContent ICheckRadioButtonsFor<TModel>(this IHtmlHelper<TModel> html, Expression<Func<TModel, bool>> expression, List<Tuple<string, string, string>> values, ICheckStyle style = ICheckStyle.Flat_Blue, string icon = null)
        {
            var col = Math.Floor(12 / (decimal)values.Count);
            var result = "";
            foreach (var item in values)
            {
                result += @"
<div class=""col-sm-" + col + @""" style=""padding: 0"">
" + html.ICheckRadioButtonFor(expression, item.Item1, item.Item2, style, item.Item3).ToHtmlString() + @"
</div>" + Environment.NewLine;
            }
            return new HtmlString(result);
        }

        public static IHtmlContent ICheckCheckBoxFor<TModel>(this IHtmlHelper<TModel> html, Expression<Func<TModel, bool>> expression, string label = null, ICheckStyle style = ICheckStyle.Flat_Blue, string icon = null, object htmlAttributes = null)
        {
            //string htmlFieldName = html.FieldNameFor(expression);
            //ModelExplorer metadata = html.GetModelExplorer(expression);
            //var displayName = metadata.Metadata.DisplayName ?? metadata.Metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            //var name = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName);

            var id = html.FieldIdFor(expression);
            var cssClass = " " + style.ToString().ToLower().Replace('_', '-');
            var attributes = ComponentUtility.MergeAttributes(htmlAttributes, new { @class = "icheck" + cssClass, id = id + "_" + Guid.NewGuid() });

            var result =
    html.StyleFileSingle(ComponentUtility.GetCssTag(iCheck_all_css, iCheck_all_css_cdn)).ToHtmlString()
    + @"
<label for=""" + id + "_" + Guid.NewGuid() + @""">
    " + html.CheckBoxFor(expression, attributes).ToHtmlString() + @"
    " + (string.IsNullOrEmpty(icon) ? "" : @"<i class=""fa " + icon + @""" style=""font-size: large;""></i>") + " " + label + @"
</label>"
     + html.ScriptFileSingle(ComponentUtility.GetJsTag(iCheck_js, iCheck_js_cdn)).ToHtmlString()
     + html.ScriptFileSingle(ComponentUtility.GetJsTag(iCheck_custom_js, null)).ToHtmlString();
            return new HtmlString(result);
        }

        public static IHtmlContent ICheckCheckBox<TModel>(this IHtmlHelper<TModel> html, string name, string label = null, bool value = false, ICheckStyle style = ICheckStyle.Flat_Blue, string icon = null, object htmlAttributes = null)
        {
            var id = html.GenerateIdFromName(name);
            var cssClass = style.ToString().ToLower().Replace('_', '-');

            html.StyleFileSingle(ComponentUtility.GetCssTag(iCheck_all_css, iCheck_all_css_cdn));
            html.ScriptFileSingle(ComponentUtility.GetJsTag(iCheck_js, iCheck_js_cdn));
            html.ScriptFileSingle(ComponentUtility.GetJsTag(iCheck_custom_js, null));

            var attributes = ComponentUtility.MergeAttributes(new { @class = $"icheck {cssClass}", id }, htmlAttributes);
            var radioButton = html.CheckBox(name, value, attributes);
            var iconTag = string.IsNullOrEmpty(icon) ? "" : $@"<i class=""fa {icon}"" style=""font-size: large;""></i>";
            var result = $@"
            <label for=""{id}"">
                {radioButton.ToHtmlString()}
                {iconTag}
                {label}
            </label>";
            return new HtmlString(result);
        }
    }
}
