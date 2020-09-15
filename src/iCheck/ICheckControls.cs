using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using DNZ.MvcComponents;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

//[assembly: WebResource("DNZ.MvcComponents.iCheck.all.css", "text/css", PerformSubstitution = true)]
namespace Microsoft.AspNetCore.Mvc
{
    public static class ICheckControls
    {
        private const string iCheck_all_css = "DNZ.MvcComponents.iCheck.all.css";
        private const string iCheck_js = "DNZ.MvcComponents.iCheck.icheck.min.js";
        private const string iCheck_custom_js = "DNZ.MvcComponents.iCheck.icheck.custom.js";

        public static IHtmlContent ICheckRadioButtonFor<TModel>(this IHtmlHelper<TModel> html, Expression<Func<TModel, bool>> expression, string label = null, object value = null, ICheckStyle style = ICheckStyle.Flat_Blue, string icon = null)
        {
            ViewFeatures.ModelExplorer metadata = ExpressionMetadataProvider.FromLambdaExpression(expression, html.ViewData, html.MetadataProvider);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            //var displayName = metadata.Metadata.DisplayName ?? metadata.Metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            //var name = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName);
            string id = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName);
            string cssClass = " " + style.ToString().ToLower().Replace('_', '-');
            if (value == null)
            {
                value = "";
            }

            string result =
    html.StyleFileSingle(@"<link href=""" + ComponentUtility.GetWebResourceUrl(iCheck_all_css) + @""" rel=""stylesheet"" />").ToHtmlString()
    + @"
<label for=""" + id + "_" + Guid.NewGuid() + @""">
    " + html.RadioButtonFor(expression, value, new { @class = "icheck" + cssClass, id = id + "_" + Guid.NewGuid() }).ToHtmlString() + @"
    " + (string.IsNullOrEmpty(icon) ? "" : @"<i class=""fa " + icon + @""" style=""font-size: large;""></i>") + " " + label + @"
</label>"
     + html.ScriptFileSingle(@" <script src=""" + ComponentUtility.GetWebResourceUrl(iCheck_js) + @"""></script>").ToHtmlString()
     + html.ScriptFileSingle(@" <script src=""" + ComponentUtility.GetWebResourceUrl(iCheck_custom_js) + @"""></script>").ToHtmlString();
            return new HtmlString(result);
        }

        public static IHtmlContent ICheckRadioButtonsFor<TModel>(this IHtmlHelper<TModel> html, Expression<Func<TModel, bool>> expression, List<Tuple<string, string, string>> values, ICheckStyle style = ICheckStyle.Flat_Blue, string icon = null)
        {
            decimal col = Math.Floor(12 / (decimal)values.Count);
            string result = "";
            foreach (Tuple<string, string, string> item in values)
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
            ViewFeatures.ModelExplorer metadata = ExpressionMetadataProvider.FromLambdaExpression(expression, html.ViewData, html.MetadataProvider);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            //var displayName = metadata.Metadata.DisplayName ?? metadata.Metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            //var name = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName);
            string id = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName);
            string cssClass = " " + style.ToString().ToLower().Replace('_', '-');
            Dictionary<string, object> attributes = ComponentUtility.MergeAttributes(htmlAttributes, new { @class = "icheck" + cssClass, id = id + "_" + Guid.NewGuid() });

            string result =
    html.StyleFileSingle(@"<link href=""" + ComponentUtility.GetWebResourceUrl(iCheck_all_css) + @""" rel=""stylesheet"" />").ToHtmlString()
    + @"
<label for=""" + id + "_" + Guid.NewGuid() + @""">
    " + html.CheckBoxFor(expression, attributes).ToHtmlString() + @"
    " + (string.IsNullOrEmpty(icon) ? "" : @"<i class=""fa " + icon + @""" style=""font-size: large;""></i>") + " " + label + @"
</label>"
     + html.ScriptFileSingle(@" <script src=""" + ComponentUtility.GetWebResourceUrl(iCheck_js) + @"""></script> ").ToHtmlString()
     + html.ScriptFileSingle(@" <script src=""" + ComponentUtility.GetWebResourceUrl(iCheck_custom_js) + @"""></script> ").ToHtmlString();
            return new HtmlString(result);
        }

        public static IHtmlContent ICheckCheckBox<TModel>(this IHtmlHelper<TModel> html, string name, string label = null, bool value = false, ICheckStyle style = ICheckStyle.Flat_Blue, string icon = null, object htmlAttributes = null)
        {
            string id = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(name);
            string cssClass = style.ToString().ToLower().Replace('_', '-');

            html.StyleFileSingle(@"<link href=""" + ComponentUtility.GetWebResourceUrl(iCheck_all_css) + @""" rel=""stylesheet"" />");
            html.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(iCheck_js) + @"""></script>");
            html.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(iCheck_custom_js) + @"""></script>");

            Dictionary<string, object> attributes = ComponentUtility.MergeAttributes(new { @class = $"icheck {cssClass}", id }, htmlAttributes);
            IHtmlContent radioButton = html.CheckBox(name, value, attributes);
            string iconTag = string.IsNullOrEmpty(icon) ? "" : $@"<i class=""fa {icon}"" style=""font-size: large;""></i>";
            string result = $@"
            <label for=""{id}"">
                {radioButton.ToHtmlString()}
                {iconTag}
                {label}
            </label>";
            return new HtmlString(result);
        }
    }
}
