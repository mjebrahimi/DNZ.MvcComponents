using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using DNZ.MvcComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Microsoft.AspNetCore.Mvc
{
    public static class BootstrapUploadHelper
    {
        private const string fileinput_css = "DNZ.MvcComponents.FileUploader.css.fileinput.css";
        private const string custom_fileinput_css = "DNZ.MvcComponents.FileUploader.css.custom-fileinput.css";
        private const string fileinput_js = "DNZ.MvcComponents.FileUploader.js.fileinput.js";
        private const string fileinput_locale_fa_js = "DNZ.MvcComponents.FileUploader.js.fileinput_locale_fa.js";

        public static IHtmlContent BsUploadFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string action = null, string controller = null, object routeValues = null, string urlImages = null)
        {
            var setting = new BsUploadSetting(html);
            var metadata = html.GetModelExplorer(expression);
            var htmlFieldName = html.FieldNameFor(expression);
            var displayName = metadata.Metadata.DisplayName ?? metadata.Metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            var value = metadata.Model;
            var id = html.GenerateIdFromName(htmlFieldName);
            var name = html.FieldNameFor(expression);
            var label = html.LabelFor(expression, new { @class = "control-label" });
            var input = new TagBuilder("input");
            input.Attributes.Add("type", "file");
            input.Attributes.Add("id", id);
            input.Attributes.Add("name", "file");
            input.Attributes.Add("multiple", "");
            input.Attributes.Add("class", "file-loading");
            var file = new HtmlString(input.ToHtmlString());
            var urlHelper = html.GetUrlHelper();
            if (action != null && controller != null)
            {
                var url = urlHelper.Action(new UrlActionContext { Action = action, Controller = controller, Values = routeValues });
                setting.UploadUrl(url);
                if (urlImages.HasValue())
                {
                    //compatible url: "/home/images" or queryString: "/home/images/?image_id="
                    if (!urlImages.Contains("{0}"))
                    {
                        urlImages = urlImages.Contains("?") ? urlImages : urlImages.TrimEnd('/') + '/';
                    }

                    var initialPreview = new BsUploadInitialPreview();
                    var initialPreviewConfig = new BsUploadInitialPreviewConfig();
                    foreach (var item in (value as IEnumerable<int>))
                    {
                        var imgSrc = urlImages.Contains("{0}") ? string.Format(urlImages, item) : (urlImages + item);
                        initialPreview.Add(imgSrc, new { key = item });
                        initialPreviewConfig.Add("", url, item);
                    }
                    setting.InitialPreview(initialPreview);
                    setting.InitialPreviewConfig(initialPreviewConfig);
                }
            }

            var result = @"
<div id=""" + id + @"_fileuploader_container"">
    " + label.ToHtmlString() + @"
    " + file.ToHtmlString() + @"
    <div id=""" + id + @"_hidden""></div>
</div>

" + html.StyleFileSingle(@"<link href=""" + ComponentUtility.GetWebResourceUrl(fileinput_css) + @""" rel=""stylesheet"" />").ToHtmlString() + @"
" + html.StyleFileSingle(@"<link href=""" + ComponentUtility.GetWebResourceUrl(custom_fileinput_css) + @""" rel=""stylesheet"" />").ToHtmlString() + @"

" + html.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(fileinput_js) + @"""></script>").ToHtmlString() + @"
" + html.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(fileinput_locale_fa_js) + @"""></script>").ToHtmlString() + @"

" + html.Script(@"
<script>
        $(function () {
            $(""#" + id + @""").fileinput(" + setting.RenderOptions() + ")"
            +
            (Convert.ToBoolean(setting.Attributes["uploadAsync"]) ?
            @".on('filebatchselected', function (event, files) {
                $(this).fileinput('upload');
            }).on('filedeleted', function (event, key) {
                $('#" + id + @"_fileuploader_hidden_' + key).remove();
            }).on('fileuploaded', function (event, data, previewId, index) {
                var key = data.response
                $(""#" + id + @"_hidden"").append($('<input/>', { type: 'hidden', id: '" + id + "_fileuploader_hidden_' + key, value: key, name: '" + name + @"' }));
                $(""#" + id + @"_fileuploader_container div.file-preview-thumbnails #"" + previewId + "" button.kv-file-remove"").attr(""data-key"", key);
            }).on('filesuccessremove', function (event, id) {
                var key = $('#' + id + '  button.kv-file-remove').attr(""data-key"")
                $('#" + id + @"_fileuploader_hidden_' + key).remove();
            });
            $(""#" + id + @"_fileuploader_container .file-preview-frame.file-preview-initial img"").each(function () {
                var previewkey = $(this).attr(""key"");
                $(""#" + id + @"_hidden"").append($('<input/>', { type: 'hidden', id: '" + id + "_fileuploader_hidden_' + previewkey, value: previewkey, name: '" + name + @"' }))
            });" : "")
            +
        @"})
    </script>
");
            return new HtmlString(result);
        }
    }
}

