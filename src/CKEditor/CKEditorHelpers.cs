using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using DNZ.MvcComponents;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;

namespace Microsoft.AspNetCore.Mvc
{
    public static class CKEditorHelpers
    {
        /* The following values should be configured to your application/desires. */
        /// <summary>
        /// The CSS Class for CKEditor instances, for internal use by these helpers
        /// </summary>
        private const string CK_Ed_Class = "CkEditor";

        /// <summary>
        /// The virtual, rooted directory where CKEditor can be found. Should include trailing slash. eg /CKEditor/
        /// </summary>
        private const string CK_Ed_Location = "/Scripts/ckeditor4/";

        /// <summary>
        /// The default rows of textarea/em height of CKEditor
        /// </summary>
        private const int DefaultTextAreaRows = 20;

        /// <summary>
        /// The default columns of textarea/em width of CKEditor
        /// </summary>
        private const int DefaultTextAreaColumns = 50;
        /* The above values should be configured to your application/desires. */

        #region Weak-Typed Helpers CKEditor()
        /// <summary>
        /// Create a weak-typed CKEditor instance. Must use CKEditorHeaderScripts to enable, and CKEditorSubmitButtonUpdateFunction for client-side validation.
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="name">Field name</param>
        /// <returns>MvcHtmlString output of CKEditor instance</returns>
        public static IHtmlContent CKEditor(this IHtmlHelper htmlHelper, string name)
        {
            return CKEditor(htmlHelper, name, string.Empty, string.Empty, null);
        }

        /// <summary>
        /// Create a weak-typed CKEditor instance. Must use CKEditorHeaderScripts to enable, and CKEditorSubmitButtonUpdateFunction for client-side validation.
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="name">Field name</param>
        /// <param name="value">Field value</param>
        /// <returns>MvcHtmlString output of CKEditor instance</returns>
        public static IHtmlContent CKEditor(this IHtmlHelper htmlHelper, string name, string value)
        {
            return CKEditor(htmlHelper, name, value, string.Empty, null);
        }

        /// <summary>
        /// Create a weak-typed CKEditor instance. Must use CKEditorHeaderScripts to enable, and CKEditorSubmitButtonUpdateFunction for client-side validation.
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="name">Field name</param>
        /// <param name="value">Field value</param>
        /// <param name="ckEditorConfig">CKEditor Javascript config string eg: {height:20em, width:30em}</param>
        /// <returns>MvcHtmlString output of CKEditor instance</returns>
        public static IHtmlContent CKEditor(this IHtmlHelper htmlHelper, string name, string value, string ckEditorConfig)
        {
            return CKEditor(htmlHelper, name, value, ckEditorConfig, null);
        }

        /// <summary>
        /// Create a weak-typed CKEditor instance. Must use CKEditorHeaderScripts to enable, and CKEditorSubmitButtonUpdateFunction for client-side validation.
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="name">Field name</param>
        /// <param name="value">Field value</param>
        /// <param name="ckEditorConfig">CKEditor Javascript config string eg: {height:20em, width:30em}</param>
        /// <param name="htmlAttributesObj">Html Attributes for textarea</param>
        /// <returns>MvcHtmlString output of CKEditor instance</returns>
        public static IHtmlContent CKEditor(this IHtmlHelper htmlHelper, string name, string value, string ckEditorConfig, object htmlAttributesObj)
        {
            return CKEditor(htmlHelper, name, value, ckEditorConfig, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributesObj));
        }

        /// <summary>
        /// Create a weak-typed CKEditor instance. Must use CKEditorHeaderScripts to enable, and CKEditorSubmitButtonUpdateFunction for client-side validation.
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="name">Field name</param>
        /// <param name="value">Field value</param>
        /// <param name="uploadUrl"></param>
        /// <param name="ckEditorConfig">CKEditor Javascript config string eg: {height:20em, width:30em}</param>
        /// <param name="htmlAttributesDict">Html Attributes for textarea</param>
        /// <returns>MvcHtmlString output of CKEditor instance</returns>
        public static IHtmlContent CKEditor(this IHtmlHelper htmlHelper, string name, string value, string uploadUrl, string ckEditorConfig, IDictionary<string, object> htmlAttributesDict)
        {
            ModelExplorer metadata = htmlHelper.GetModelExplorerForString(name);
            if (value != null)
            {
                metadata.GetExplorerForModel(value);
            }

            return CKEditorHelper(htmlHelper, metadata, name, uploadUrl, implicitRowsAndColumns, htmlAttributesDict, ckEditorConfig);
        }

        /// <summary>
        /// Create a weak-typed CKEditor instance. Must use CKEditorHeaderScripts to enable, and CKEditorSubmitButtonUpdateFunction for client-side validation.
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="name">Field name</param>
        /// <param name="value">Field value</param>
        /// <param name="rows">Number of rows/em height</param>
        /// <param name="columns">Number of columns/em width</param>
        /// <returns>MvcHtmlString output of CKEditor instance</returns>
        public static IHtmlContent CKEditor(this IHtmlHelper htmlHelper, string name, string value, int rows, int columns)
        {
            return CKEditor(htmlHelper, name, value, rows, columns, string.Empty, null);
        }

        /// <summary>
        /// Create a weak-typed CKEditor instance. Must use CKEditorHeaderScripts to enable, and CKEditorSubmitButtonUpdateFunction for client-side validation.
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="name">Field name</param>
        /// <param name="value">Field value</param>
        /// <param name="rows">Number of rows/em height</param>
        /// <param name="columns">Number of columns/em width</param>
        /// <param name="ckEditorConfig">CKEditor Javascript config string eg: {height:20em, width:30em} Overrides rows/columns values for CKEditor</param>
        /// <returns>MvcHtmlString output of CKEditor instance</returns>
        public static IHtmlContent CKEditor(this IHtmlHelper htmlHelper, string name, string value, int rows, int columns, string ckEditorConfig)
        {
            return CKEditor(htmlHelper, name, value, rows, columns, ckEditorConfig, null);
        }

        /// <summary>
        /// Create a weak-typed CKEditor instance. Must use CKEditorHeaderScripts to enable, and CKEditorSubmitButtonUpdateFunction for client-side validation.
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="name">Field name</param>
        /// <param name="value">Field value</param>
        /// <param name="rows">Number of rows/em height</param>
        /// <param name="columns">Number of columns/em width</param>
        /// <param name="ckEditorConfig">CKEditor Javascript config string eg: {height:20em, width:30em}</param>
        /// <param name="htmlAttributesObj">Html Attributes for textarea</param>
        /// <returns>MvcHtmlString output of CKEditor instance</returns>
        public static IHtmlContent CKEditor(this IHtmlHelper htmlHelper, string name, string value, int rows, int columns, string ckEditorConfig, object htmlAttributesObj)
        {
            return CKEditor(htmlHelper, name, value, rows, columns, ckEditorConfig, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributesObj));
        }

        /// <summary>
        /// Create a weak-typed CKEditor instance. Must use CKEditorHeaderScripts to enable, and CKEditorSubmitButtonUpdateFunction for client-side validation.
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="name">Field name</param>
        /// <param name="value">Field value</param>
        /// <param name="uploadUrl"></param>
        /// <param name="rows">Number of rows/em height</param>
        /// <param name="columns">Number of columns/em width</param>
        /// <param name="ckEditorConfig">CKEditor Javascript config string eg: {height:20em, width:30em} Overrides rows/columns values for CKEditor</param>
        /// <param name="htmlAttributesDict">Html Attributes for textarea</param>
        /// <returns>MvcHtmlString output of CKEditor instance</returns>
        public static IHtmlContent CKEditor(this IHtmlHelper htmlHelper, string name, string value, string uploadUrl, int rows, int columns, string ckEditorConfig, IDictionary<string, object> htmlAttributesDict)
        {
            ModelExplorer metadata = htmlHelper.GetModelExplorerForString(name); ;
            if (value != null)
            {
                metadata.GetExplorerForModel(value);
            }

            return CKEditorHelper(htmlHelper, metadata, name, uploadUrl, GetRowsAndColumnsDictionary(rows, columns), htmlAttributesDict, ckEditorConfig);
        }

        #endregion

        #region Strong-Typed Helpers - CKEditorFor<TModel, TProperty>()
        /// <summary>
        /// Create a strong-typed CKEditor instance. Must use CKEditorHeaderScripts to enable, and CKEditorSubmitButtonUpdateFunction for client-side validation.
        /// </summary>
        /// <typeparam name="TModel">Model Class</typeparam>
        /// <typeparam name="TProperty">Property Value Type</typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">Binding Expression</param>
        /// <param name="uploadUrl"></param>
        /// <returns>MvcHtmlString output of CKEditor instance</returns>
        public static IHtmlContent CKEditorFor<TModel, TProperty>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string uploadUrl = null)
        {
            return CKEditorFor(htmlHelper, expression, uploadUrl, string.Empty, null);
        }

        /// <summary>
        /// Create a strong-typed CKEditor instance. Must use CKEditorHeaderScripts to enable, and CKEditorSubmitButtonUpdateFunction for client-side validation.
        /// </summary>
        /// <typeparam name="TModel">Model Class</typeparam>
        /// <typeparam name="TProperty">Property Value Type</typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">Binding Expression</param>
        /// <param name="uploadUrl"></param>
        /// <param name="ckEditorConfig">CKEditor Javascript config string eg: {height:20em, width:30em} Overrides rows/columns values for CKEditor</param>
        /// <returns>MvcHtmlString output of CKEditor instance</returns>
        public static IHtmlContent CKEditorFor<TModel, TProperty>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string uploadUrl, string ckEditorConfig)
        {
            return CKEditorFor(htmlHelper, expression, uploadUrl, ckEditorConfig, null);
        }

        /// <summary>
        /// Create a strong-typed CKEditor instance. Must use CKEditorHeaderScripts to enable, and CKEditorSubmitButtonUpdateFunction for client-side validation.
        /// </summary>
        /// <typeparam name="TModel">Model Class</typeparam>
        /// <typeparam name="TProperty">Property Value Type</typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">Binding Expression</param>
        /// <param name="uploadUrl"></param>
        /// <param name="ckEditorConfig">CKEditor Javascript config string eg: {height:20em, width:30em} Overrides rows/columns values for CKEditor</param>
        /// <param name="htmlAttributesObj">Html Attributes for textarea</param>
        /// <returns>MvcHtmlString output of CKEditor instance</returns>
        public static IHtmlContent CKEditorFor<TModel, TProperty>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string uploadUrl, string ckEditorConfig, object htmlAttributesObj)
        {
            return CKEditorFor(htmlHelper, expression, uploadUrl, ckEditorConfig, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributesObj));
        }

        /// <summary>
        /// Create a strong-typed CKEditor instance. Must use CKEditorHeaderScripts to enable, and CKEditorSubmitButtonUpdateFunction for client-side validation.
        /// </summary>
        /// <typeparam name="TModel">Model Class</typeparam>
        /// <typeparam name="TProperty">Property Value Type</typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">Binding Expression</param>
        /// <param name="uploadUrl"></param>
        /// <param name="ckEditorConfig">CKEditor Javascript config string eg: {height:20em, width:30em} Overrides rows/columns values for CKEditor</param>
        /// <param name="htmlAttributesDict">Html Attributes for textarea</param>
        /// <returns>MvcHtmlString output of CKEditor instance</returns>
        public static IHtmlContent CKEditorFor<TModel, TProperty>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string uploadUrl, string ckEditorConfig, IDictionary<string, object> htmlAttributesDict)
        {
            expression.NotNull(nameof(expression));

            return CKEditorHelper(htmlHelper,
                htmlHelper.GetModelExplorer(expression),
                htmlHelper.FieldNameFor(expression),
                uploadUrl,
                implicitRowsAndColumns,
                htmlAttributesDict,
                ckEditorConfig
                );
        }

        /// <summary>
        /// Create a strong-typed CKEditor instance. Must use CKEditorHeaderScripts to enable, and CKEditorSubmitButtonUpdateFunction for client-side validation.
        /// </summary>
        /// <typeparam name="TModel">Model Class</typeparam>
        /// <typeparam name="TProperty">Property Value Type</typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">Binding Expression</param>
        /// <param name="rows">Number of rows/em height</param>
        /// <param name="columns">Number of columns/em width</param>
        /// <returns>MvcHtmlString output of CKEditor instance</returns>
        public static IHtmlContent CKEditorFor<TModel, TProperty>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, int rows, int columns)
        {
            return CKEditorFor(htmlHelper, expression, rows, columns, string.Empty, null);
        }

        /// <summary>
        /// Create a strong-typed CKEditor instance. Must use CKEditorHeaderScripts to enable, and CKEditorSubmitButtonUpdateFunction for client-side validation.
        /// </summary>
        /// <typeparam name="TModel">Model Class</typeparam>
        /// <typeparam name="TProperty">Property Value Type</typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">Binding Expression</param>
        /// <param name="rows">Number of rows/em height</param>
        /// <param name="columns">Number of columns/em width</param>
        /// <param name="ckEditorConfig"></param>
        /// <returns>MvcHtmlString output of CKEditor instance</returns>
        public static IHtmlContent CKEditorFor<TModel, TProperty>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, int rows, int columns, string ckEditorConfig)
        {
            return CKEditorFor(htmlHelper, expression, rows, columns, ckEditorConfig, null);
        }

        /// <summary>
        /// Create a strong-typed CKEditor instance. Must use CKEditorHeaderScripts to enable, and CKEditorSubmitButtonUpdateFunction for client-side validation.
        /// </summary>
        /// <typeparam name="TModel">Model Class</typeparam>
        /// <typeparam name="TProperty">Property Value Type</typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">Binding Expression</param>
        /// <param name="rows">Number of rows/em height</param>
        /// <param name="columns">Number of columns/em width</param>
        /// <param name="ckEditorConfig">CKEditor Javascript config string eg: {height:20em, width:30em} Overrides rows/columns values for CKEditor</param>
        /// <param name="htmlAttributesObj">Html Attributes for textarea</param>
        /// <returns>MvcHtmlString output of CKEditor instance</returns>
        public static IHtmlContent CKEditorFor<TModel, TProperty>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, int rows, int columns, string ckEditorConfig, object htmlAttributesObj)
        {
            return CKEditorFor(htmlHelper, expression, rows, columns, ckEditorConfig, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributesObj));
        }

        /// <summary>
        /// Create a strong-typed CKEditor instance. Must use CKEditorHeaderScripts to enable, and CKEditorSubmitButtonUpdateFunction for client-side validation.
        /// </summary>
        /// <typeparam name="TModel">Model Class</typeparam>
        /// <typeparam name="TProperty">Property Value Type</typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">Binding Expression</param>
        /// <param name="uploadUrl"></param>
        /// <param name="rows">Number of rows/em height</param>
        /// <param name="columns">Number of columns/em width</param>
        /// <param name="ckEditorConfig">CKEditor Javascript config string eg: {height:20em, width:30em} Overrides rows/columns values for CKEditor</param>
        /// <param name="htmlAttributesDict">Html Attributes for textarea</param>
        /// <returns>MvcHtmlString output of CKEditor instance</returns>
        public static IHtmlContent CKEditorFor<TModel, TProperty>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string uploadUrl, int rows, int columns, string ckEditorConfig, IDictionary<string, object> htmlAttributesDict)
        {
            expression.NotNull(nameof(expression));
            return CKEditorHelper(htmlHelper,
                htmlHelper.GetModelExplorer(expression),
                htmlHelper.FieldNameFor(expression),
                uploadUrl,
                GetRowsAndColumnsDictionary(rows, columns),
                htmlAttributesDict,
                ckEditorConfig
                );
        }

        #endregion

        #region Related HTML Helpers
        /// <summary>
        /// Produces HTML to insert scripts needed to insert CKEditor instances. To be used once per page, toward the top of a view.
        /// </summary>
        public static IHtmlContent CKEditorHeaderScripts(this IHtmlHelper help)
        {
            RenderScriptAndStyle.Script(
@"<script src=""" + CK_Ed_Location + @"ckeditor.js"" type=""text/javascript""></script>
<script src=""" + CK_Ed_Location + @"adapters/jquery.js"" type=""text/javascript""></script>
<script	type=""text/javascript""> function UpdateCKEditors() { $('." + CK_Ed_Class + "').ckeditorGet().updateElement(); } </script>");

            return HtmlString.NewLine;

            //            return new HtmlString(@"<script src=""" + CK_Ed_Location + @"ckeditor.js"" type=""text/javascript""></script>
            //<script src=""" + CK_Ed_Location + @"adapters/jquery.js"" type=""text/javascript""></script>
            //<script	type=""text/javascript""> function UpdateCKEditors() { $('." + CK_Ed_Class + @"').ckeditorGet().updateElement(); } </script>");
        }

        /// <summary>
        /// Outputs simple call to function that updates CKEditors before client-side validators are called.
        /// </summary>
        /// <example>Razor View: &lt;input type="text" value="submit" onclick="@Html.CKEditorSubmitButtonUpdateFunction()"/&gt;</example>
        /// <returns>MvcHtmlString literal: javascript:UpdateCKEditors()</returns>
        public static IHtmlContent CKEditorSubmitButtonUpdateFunction(this IHtmlHelper help)
        {
            return new HtmlString("javascript:UpdateCKEditors()");
        }

        #endregion

        private static IHtmlContent CKEditorHelper(IHtmlHelper htmlHelper, ModelExplorer modelMetadata, string name, string uploadUrl, IDictionary<string, object> rowsAndColumns, IDictionary<string, object> htmlAttributes, string ckEditorConfigOptions)
        {
            string fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            string id = htmlHelper.GenerateIdFromName(name);

            TagBuilder textAreaBuilder = new TagBuilder("textarea");
            textAreaBuilder.GenerateId(fullName, "");
            textAreaBuilder.MergeAttributes(htmlAttributes, true);
            textAreaBuilder.MergeAttribute("name", fullName, true);
            string style = "";
            if (textAreaBuilder.Attributes.ContainsKey("style"))
            {
                style = textAreaBuilder.Attributes["style"];
            }
            if (string.IsNullOrWhiteSpace(style))
            {
                style = "";
            }
            //style += string.Format("height:{0}em; width:{1}em; margin-bottom: 20px !important;", rowsAndColumns["rows"], rowsAndColumns["cols"]);
            style += string.Format("height:{0}em; width:100%; margin-bottom: 20px !important;", rowsAndColumns["rows"], rowsAndColumns["cols"]);
            textAreaBuilder.MergeAttribute("style", style, true);
            // If there are any errors for a named field, we add the CSS attribute.
            if (htmlHelper.ViewData.ModelState.TryGetValue(fullName, out ModelStateEntry modelState) && modelState.Errors.Count > 0)
            {
                textAreaBuilder.AddCssClass(HtmlHelper.ValidationInputCssClassName);
            }

            //var modelExplorer = ExpressionMetadataProvider.FromStringExpression(expression, htmlHelper.ViewContext.ViewData, htmlHelper.MetadataProvider);
            //var validator = htmlHelper.ViewContext.HttpContext.RequestServices.GetService<ValidationHtmlAttributeProvider>();
            //validator?.AddAndTrackValidationAttributes(htmlHelper.ViewContext, modelExplorer, expression, tagBuilder.Attributes);
            //textAreaBuilder.MergeAttributes(htmlHelper.GetUnobtrusiveValidationAttributes(name));

            string value;
            if (modelState.AttemptedValue != null)
            {
                value = modelState.AttemptedValue;
            }
            else if (modelMetadata.Model != null)
            {
                value = modelMetadata.Model.ToString();
            }
            else
            {
                value = string.Empty;
            }

            // The first newline is always trimmed when a TextArea is rendered, so we add an extra one
            // in case the value being rendered is something like "\r\nHello".
            textAreaBuilder.InnerHtml.SetContent(Environment.NewLine + value);

            TagBuilder scriptBuilder = new TagBuilder("script");
            scriptBuilder.MergeAttribute("type", "text/javascript");
            if (string.IsNullOrEmpty(ckEditorConfigOptions))
            {
                ckEditorConfigOptions = string.Format("{{ width:'100%', height:'{1}em', filebrowserImageUploadUrl:'{2}' }}", rowsAndColumns["cols"], rowsAndColumns["rows"], uploadUrl);
            }
            if (!ckEditorConfigOptions.Trim().StartsWith("{"))
            {
                ckEditorConfigOptions = "{" + ckEditorConfigOptions;
            }

            if (!ckEditorConfigOptions.Trim().EndsWith("}"))
            {
                ckEditorConfigOptions += "}";
            }

            scriptBuilder.InnerHtml.SetHtmlContent(string.Format(" $('#{0}').ckeditor({1}).addClass('{2}'); ", id, ckEditorConfigOptions, CK_Ed_Class));

            //<script type=""text/javascript""> function UpdateCKEditors() { $('." + CK_Ed_Class + @"').ckeditorGet().updateElement(); } </script>"
            htmlHelper.ScriptFileSingle(@"<script src=""" + CK_Ed_Location + @"ckeditor.js""></script>");
            htmlHelper.ScriptFileSingle(@"<script src=""" + CK_Ed_Location + @"adapters/jquery.js""></script>");
            htmlHelper.Script(scriptBuilder.ToHtmlString());

            return new HtmlString(@"
<div class=""form-group"">
    <div class=""col-sm-12"">
    " + textAreaBuilder + @"
    </div>
</div>");
        }

        private static readonly Dictionary<string, object> implicitRowsAndColumns = new Dictionary<string, object>
        {
            ["rows"] = DefaultTextAreaRows.ToString(CultureInfo.InvariantCulture),
            ["cols"] = DefaultTextAreaColumns.ToString(CultureInfo.InvariantCulture)
        };

        private static Dictionary<string, object> GetRowsAndColumnsDictionary(int rows, int columns)
        {
            if (rows < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rows), "A text area parameter is out of range");
            }
            if (columns < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(columns), "A text area parameter is out of range");
            }

            Dictionary<string, object> result = new Dictionary<string, object>();
            if (rows > 0)
            {
                result.Add("rows", rows.ToString(CultureInfo.InvariantCulture));
            }
            if (columns > 0)
            {
                result.Add("cols", columns.ToString(CultureInfo.InvariantCulture));
            }

            return result;
        }
    }
}