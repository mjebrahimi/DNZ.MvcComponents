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
        //https://plugins.krajee.com/file-input
        //https://cdnjs.com/libraries/bootstrap-fileinput
        private const string fileinput_css_cdn = "<link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/bootstrap-fileinput/5.1.2/css/fileinput.min.css\" integrity=\"sha512-KrsXJaSKHqHogNzPCOHPvkyvH4ZQGzUcR/Q6R3qywbdtrvOHPuPz9iRIoJoiKguuIgkDGsj+PwPh3QKnlwwQPA==\" crossorigin=\"anonymous\" />";
        private const string fileinput_rtl_css_cdn = "<link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/bootstrap-fileinput/5.1.2/css/fileinput-rtl.min.css\" integrity=\"sha512-4WMzB1hPkUhmbQGzhLBpnj/zOaKExiFge5OQ1O+2pOBABe8jxnvYxxGMMWwGBzsaTMg7m+qJ+5w+Kx00twTWjw==\" crossorigin=\"anonymous\" />";
        private const string fileinput_js_cdn = "<script src=\"https://cdnjs.cloudflare.com/ajax/libs/bootstrap-fileinput/5.1.2/js/fileinput.min.js\" integrity=\"sha512-wvbv0QlgtUZ1jkgRfB7HNUICt+27sqAUh2IwVJXfN9q7rtrmgbdI6LQjhzurdLo1+vxO645+GY+Kq8Vop0WA4w==\" crossorigin=\"anonymous\"></script>";
        private const string fileinput_locale_fa_js_cdn = "<script src=\"https://cdnjs.cloudflare.com/ajax/libs/bootstrap-fileinput/5.1.2/js/locales/fa.min.js\" integrity=\"sha512-y4nBJrp9k1LBB2NTZsVdtc92qR84xFSAQAMPOo64VZhN/f1nI3+6LbDUDcGTyzwB5Agqubeb8SeHKQnu/gRvOg==\" crossorigin=\"anonymous\"></script>";
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

" + html.StyleFileSingle(ComponentUtility.GetCssTag(fileinput_css, fileinput_css_cdn)).ToHtmlString() + @"
" + html.StyleFileSingle(ComponentUtility.GetCssTag(null, fileinput_rtl_css_cdn)).ToHtmlString() + @"
" + html.StyleFileSingle(ComponentUtility.GetCssTag(custom_fileinput_css, null)).ToHtmlString() + @"

" + html.ScriptFileSingle(ComponentUtility.GetJsTag(fileinput_js, fileinput_js_cdn)).ToHtmlString() + @"
" + html.ScriptFileSingle(ComponentUtility.GetJsTag(fileinput_locale_fa_js, fileinput_locale_fa_js_cdn)).ToHtmlString() + @"

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

