using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using DNZ.MvcComponents;
using System.Collections.Generic;

namespace Microsoft.AspNetCore.Mvc
{
    public class BsUploadSetting : IOptionBuilder
    {
        public Dictionary<string, object> Attributes { get; set; }

        private readonly IHtmlHelper _htmlHelper;

        public BsUploadSetting(IHtmlHelper htmlHelper)
        {
            _htmlHelper = htmlHelper;
            Attributes = new Dictionary<string, object>();
            Language("fa")
                .PreviewFileType(BsUploadPreviewType.Image)
                .AllowedFileTypes(new BsUploadAllowedFileType().XImage())
                .BrowseLabel("انتخاب کنید...")
                .CancelLabel("لغو")
                .UploadLabel("آپلود")
                .RemoveLabel("حذف")
                .ShowCaption(false)
                .ShowRemove(false)
                .ShowUpload(false)
                .DropZoneEnabled(true)
                .OverwriteInitial(false)
                .UploadAsync(true);
            //.UploadExtraData()
            Attributes["layoutTemplates"] = @"{
                    main1: '{preview}\n' +
                        '<div class=""kv-upload-progress hide""></div>\n' +
                        '<div class=""input-group {class}"">\n' +
                        '   {caption}\n' +
                        '   <div class=""input-group-btn"">\n' +
                        '       {remove}\n' +
                        '       {cancel}\n' +
                        '       {upload}\n' +
                        '       {browse}\n' +
                        '   </div>\n' +
                        '</div>',
                    main2: '{preview}\n<div class=""kv-upload-progress hide""></div>\n{remove}\n{cancel}\n{upload}\n{browse}\n',
                    preview: '<div class=""file-preview {class}"">\n' +
                        '    {close}\n' +
                        '    <div class=""{dropClass}"">\n' +
                        '    <div class=""file-preview-thumbnails"">\n' +
                        '    </div>\n' +
                        '    <div class=""clearfix""></div>' +
                        '    <div class=""file-preview-status text-center text-success""></div>\n' +
                        '    <div class=""kv-fileinput-error""></div>\n' +
                        '    </div>\n' +
                        '</div>',
                    icon: '<span class=""glyphicon glyphicon-file kv-caption-icon""></span>',
                    caption: '<div tabindex=""-1"" class=""form-control file-caption {class}"">\n' +
                        '   <div class=""file-caption-name""></div>\n' +
                        '</div>',
                    btnDefault: '<button type=""{type}"" tabindex=""500"" title=""{title}"" data-toggle=""tooltip"" data-placement=""top"" data-original-title=""{title}"" class=""{css}""{status}>{icon}{label}</button>',
                    btnLink: '<a href=""{href}"" tabindex=""500"" title=""{title}"" data-toggle=""tooltip"" data-placement=""top"" data-original-title=""{title}"" class=""{css}""{status}>{icon}{label}</a>',
                    btnBrowse: '<div tabindex=""500"" class=""{css}""{status}>{icon}{label}</div>',
                    modal: '<div id=""{id}"" class=""modal fade"">\n' +
                        '  <div class=""modal-dialog modal-lg"">\n' +
                        '    <div class=""modal-content"">\n' +
                        '      <div class=""modal-header"">\n' +
                        '        <button type=""button"" class=""close"" data-dismiss=""modal"" aria-hidden=""true"">×</button>\n' +
                        '        <h3 class=""modal-title"">Detailed Preview <small>{title}</small></h3>\n' +
                        '      </div>\n' +
                        '      <div class=""modal-body"">\n' +
                        '        <textarea class=""form-control"" style=""font-family:Monaco,Consolas,monospace; height: {height}px;"" readonly>{body}</textarea>\n' +
                        '      </div>\n' +
                        '    </div>\n' +
                        '  </div>\n' +
                        '</div>',
                    zoom: '<button type=""button"" class=""btn btn-default btn-sm btn-block"" title=""{zoomTitle}: {caption}"" onclick=""{dialog}"">\n' +
                        '   {zoomInd}\n' +
                        '</button>\n',
                    progress: '<div class=""progress"">\n' +
                        '    <div class=""progress-bar progress-bar-success progress-bar-striped text-center"" role=""progressbar"" aria-valuenow=""{percent}"" aria-valuemin=""0"" aria-valuemax=""100"" style=""width:{percent}%;"">\n' +
                        '        {percent}%\n' +
                        '     </div>\n' +
                        '</div>',
                    footer: '<div class=""file-thumbnail-footer"">\n' +
                        '    {progress} <div class=""file-caption-name"" style=""width:{width}"">{caption}</div>\n' +
                        '    {actions}\n' +
                        '</div>',
                    actions: '<div class=""file-actions"">\n' +
                        '    <div class=""file-footer-buttons"">\n' +
                        '        {upload}{delete}' +
                        '    </div>\n' +
                        '    <div class=""file-upload-indicator"" tabindex=""-1"" title=""{indicatorTitle}"" data-toggle=""tooltip"" data-placement=""right"" data-original-title=""{indicatorTitle}"">{indicator}</div>\n' +
                        '    <div class=""clearfix""></div>\n' +
                        '</div>',
                    actionDelete: '<button type=""button"" class=""kv-file-remove btn btn-xs btn-danger"" title=""{removeTitle}"" data-toggle=""tooltip"" data-placement=""left"" data-original-title=""{removeTitle}""{dataUrl}{dataKey}>{removeIcon}</button>\n',
                    actionUpload: '<button type=""button"" class=""kv-file-upload {uploadClass}"" title=""{uploadTitle}"" data-toggle=""tooltip"" data-placement=""left"" data-original-title=""{uploadTitle}"">{uploadIcon}</button>\n'
                }";
        }

        public BsUploadSetting PreviewFileType(BsUploadPreviewType type)
        {
            if (type == BsUploadPreviewType.None)
            {
                Attributes["allowedPreviewTypes"] = "null";
                Attributes["previewFileIconSettings"] = @"
                {
                    'docx': '<i class=""fa fa-file-word-o text-primary""></i>',
                    'doc': '<i class=""fa fa-file-word-o text-primary""></i>',
                    'xlsx': '<i class=""fa fa-file-excel-o text-primary""></i>',
                    'xls': '<i class=""fa fa-file-excel-o text-primary""></i>',
                    'pptx': '<i class=""fa fa-file-powerpoint-o text-primary""></i>',
                    'jpg': '<i class=""fa fa-file-photo-o text-primary""></i>',
                    'ppt': '<i class=""fa fa-file-powerpoint-o text-primary""></i>',
                    'pdf': '<i class=""fa fa-file-pdf-o text-primary""></i>',
                    'zip': '<i class=""fa fa-file-archive-o text-primary""></i>',
                    'htm': '<i class=""fa fa-file-code-o text-primary""></i>',
                    'txt': '<i class=""fa fa-file-text-o text-primary""></i>',
                    'mov': '<i class=""fa fa-file-movie-o text-primary""></i>',
                    'mp3': '<i class=""fa fa-file-audio-o text-primary""></i>',
                }
            ";
            }
            else
            {
                Attributes["previewFileType"] = string.Format("'{0}'", type.ToString().ToLower());
            }
            return this;
        }

        public BsUploadSetting AllowedFileTypes(BsUploadAllowedFileType allowedFileType)
        {
            Attributes["allowedFileTypes"] = "[" + string.Join(", ", allowedFileType.Attributes.Keys) + "]";
            return this;
        }

        public BsUploadSetting AllowedFileExtensions(params string[] extensions)
        {
            Attributes["type"] = "['" + string.Join("', '", extensions) + "']";
            return this;
        }

        public BsUploadSetting MinFileCount(int count)
        {
            Attributes["minFileCount"] = count;
            return this;
        }

        public BsUploadSetting MaxFileCount(int count)
        {
            Attributes["maxFileCount"] = count;
            return this;
        }

        public BsUploadSetting MaxFileSize(int size)
        {
            Attributes["maxFileSize"] = size;
            return this;
        }

        public BsUploadSetting MinFileSize(int size)
        {
            Attributes["minFileSize"] = size;
            return this;
        }

        public BsUploadSetting ShowCaption(bool value)
        {
            Attributes["showCaption"] = value.ToString().ToLower();
            return this;
        }

        public BsUploadSetting ShowRemove(bool value)
        {
            Attributes["showRemove"] = value.ToString().ToLower();
            return this;
        }

        public BsUploadSetting ShowUpload(bool value)
        {
            Attributes["showUpload"] = value.ToString().ToLower();
            return this;
        }

        public BsUploadSetting DropZoneEnabled(bool value)
        {
            Attributes["dropZoneEnabled"] = value.ToString().ToLower();
            return this;
        }

        public BsUploadSetting UploadAsync(bool value)
        {
            Attributes["uploadAsync"] = value.ToString().ToLower();
            return this;
        }

        public BsUploadSetting UploadExtraData(object keyValueAttributes)
        {
            //var dic = (IDictionary<string, string>)keyValueAttributes;
            Attributes["uploadExtraData"] = ComponentUtility.ToJsonStringWithoutQuotes(keyValueAttributes);
            return this;
        }

        public BsUploadSetting MinImageWidth(int pixel)
        {
            Attributes["minImageWidth"] = pixel;
            return this;
        }

        public BsUploadSetting MinImageHeight(int pixel)
        {
            Attributes["minImageHeight"] = pixel;
            return this;
        }

        public BsUploadSetting MaxImageWidth(int pixel)
        {
            Attributes["maxImageWidth"] = pixel;
            return this;
        }

        public BsUploadSetting MaxImageHeight(int pixel)
        {
            Attributes["maxImageHeight"] = pixel;
            return this;
        }

        public BsUploadSetting ValidateInitialCount(bool value)
        {
            Attributes["validateInitialCount"] = value.ToString().ToLower();
            return this;
        }

        public BsUploadSetting OverwriteInitial(bool value)
        {
            Attributes["overwriteInitial"] = value.ToString().ToLower();
            return this;
        }
        //public BsUploadSetting AutoUpload(bool value)
        //{
        //    Attributes["type"] = string.Format("'{0}'", value.ToString().ToLower());
        //    return this;
        //}
        public BsUploadSetting Language(string value)
        {
            Attributes["language"] = string.Format("'{0}'", value);
            return this;
        }

        public BsUploadSetting UploadUrl(string url)
        {
            Attributes["uploadUrl"] = string.Format("'{0}'", url);
            return this;
        }

        public BsUploadSetting UploadUrlAction(string action)
        {
            var urlHelper = _htmlHelper.GetUrlHelper();
            var url = urlHelper.Action(new UrlActionContext { Action = action });
            return UploadUrl(url);
        }

        public BsUploadSetting UploadUrlAction(string action, object routeValues)
        {
            var urlHelper = _htmlHelper.GetUrlHelper();
            var url = urlHelper.Action(new UrlActionContext { Action = action, Values = routeValues });
            return UploadUrl(url);
        }

        public BsUploadSetting UploadUrlAction(string action, RouteValueDictionary routeValues)
        {
            var urlHelper = _htmlHelper.GetUrlHelper();
            var url = urlHelper.Action(new UrlActionContext { Action = action, Values = routeValues });
            return UploadUrl(url);
        }

        public BsUploadSetting UploadUrlAction(string action, string controller)
        {
            var urlHelper = _htmlHelper.GetUrlHelper();
            var url = urlHelper.Action(new UrlActionContext { Action = action, Controller = controller });
            return UploadUrl(url);
        }

        public BsUploadSetting UploadUrlAction(string action, string controller, object routeValues)
        {
            var urlHelper = _htmlHelper.GetUrlHelper();
            var url = urlHelper.Action(new UrlActionContext { Action = action, Controller = controller, Values = routeValues });
            return UploadUrl(url);
        }

        public BsUploadSetting UploadUrlAction(string action, string controller, RouteValueDictionary routeValues)
        {
            var urlHelper = _htmlHelper.GetUrlHelper();
            var url = urlHelper.Action(new UrlActionContext { Action = action, Controller = controller, Values = routeValues });
            return UploadUrl(url);
        }

        public BsUploadSetting BrowseLabel(string value)
        {
            Attributes["browseLabel"] = string.Format("'{0}'", value);
            return this;
        }

        public BsUploadSetting CancelLabel(string value)
        {
            Attributes["cancelLabel"] = string.Format("'{0}'", value);
            return this;
        }

        public BsUploadSetting UploadLabel(string value)
        {
            Attributes["uploadLabel"] = string.Format("'{0}'", value);
            return this;
        }

        public BsUploadSetting RemoveLabel(string value)
        {
            Attributes["removeLabel"] = string.Format("'{0}'", value);
            return this;
        }

        public BsUploadSetting InitialPreview(BsUploadInitialPreview initialPreview)
        {
            Attributes["initialPreview"] = "[" + string.Join(", ", initialPreview.Attributes.Values) + "]";
            return this;
        }

        public BsUploadSetting InitialPreviewConfig(BsUploadInitialPreviewConfig initialPreviewConfig)
        {
            Attributes["initialPreviewConfig"] = "[" + string.Join(", ", initialPreviewConfig.Attributes.Values) + "]";
            return this;
        }

        //accept="image/*"
        //accept="text/plain"
        //data-allowed-file-extensions='["csv", "txt"]'
        //data-show-upload="false"
        //data-show-caption="true"
        //data-show-preview="false"

        //initialPreview: [
        //    "<img style='height:160px' src='http://loremflickr.com/200/150/nature?random=1'>",
        //    "<img style='height:160px' src='http://loremflickr.com/200/150/nature?random=2'>",
        //   "<img style='height:160px' src='http://loremflickr.com/200/150/nature?random=3'>",
        //],
        //initialPreviewConfig: [
        //    {caption: "Nature-1.jpg", width: "120px", url: "/site/file-delete", key: 1},
        //    {caption: "Nature-2.jpg", width: "120px", url: "/site/file-delete", key: 2},
        //    {caption: "Nature-3.jpg", width: "120px", url: "/site/file-delete", key: 3},
        //],
    }
}

