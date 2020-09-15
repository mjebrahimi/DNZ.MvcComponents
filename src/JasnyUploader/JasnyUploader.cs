using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Microsoft.AspNetCore.Routing;
using DNZ.MvcComponents;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text.Encodings.Web;

namespace Microsoft.AspNetCore.Mvc
{
    public class JasnyUploaderOption<TModel, TValue> : IOptionBuilder, IHtmlContent
    {
        private const string jasny_bootstrap_css = "DNZ.MvcComponents.JasnyUploader.css.jasny-bootstrap.css";
        private const string jasny_bootstrap_css_min = "DNZ.MvcComponents.JasnyUploader.css.jasny-bootstrap.min.css";
        private const string jasny_bootstrap_js = "DNZ.MvcComponents.JasnyUploader.js.jasny-bootstrap.js";
        private const string jasny_bootstrap_min_js = "DNZ.MvcComponents.JasnyUploader.js.jasny-bootstrap.min.js";

        public IHtmlHelper<TModel> HtmlHelper { get; set; }
        public Expression<Func<TModel, TValue>> Expression { get; set; }
        public Dictionary<string, object> Attributes { get; set; }
        public bool JustPartial { get; set; }
        private string accept;

        public JasnyUploaderOption(IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression)
        {
            HtmlHelper = htmlHelper;
            Expression = expression;
            Attributes = new Dictionary<string, object>();
            SelectText("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<i class='fa fa-check'></i> انتخاب تصویر&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
            ChangeText("تغییر");
            RemoveText("حذف");
            SelectIcon(""); //fa fa-check
            ChangeIcon("fa fa-repeat"); //fa fa-repeat
            RemoveIcon("fa fa-times"); //fa fa-times
            SelectChangeClass("btn btn-primary");
            RemoveClass("btn btn-danger");
            FixSize(true);
            AutoUpload(true);
            DefaultPreview(true);
            DefaultImage(JasnyDefaultImage.NoImage2);
            Width(200);
            Height(150);
            UploadUrl("");
            LoadingImage(JasnyLoading.Default1);
        }

        public JasnyUploaderOption<TModel, TValue> SetJustPartial()
        {
            JustPartial = true;
            return this;
        }

        public JasnyUploaderOption<TModel, TValue> Accept(string value)
        {
            accept = value;
            return this;
        }

        public JasnyUploaderOption<TModel, TValue> SelectText(string value)
        {
            Attributes["selectText"] = value;
            return this;
        }

        public JasnyUploaderOption<TModel, TValue> SelectIcon(string value)
        {
            Attributes["selectIcon"] = value;
            return this;
        }

        public JasnyUploaderOption<TModel, TValue> ChangeText(string value)
        {
            Attributes["changeText"] = value;
            return this;
        }

        public JasnyUploaderOption<TModel, TValue> ChangeIcon(string value)
        {
            Attributes["changeIcon"] = value;
            return this;
        }

        public JasnyUploaderOption<TModel, TValue> RemoveText(string value)
        {
            Attributes["removeText"] = value;
            return this;
        }

        public JasnyUploaderOption<TModel, TValue> RemoveIcon(string value)
        {
            Attributes["removeIcon"] = value;
            return this;
        }

        public JasnyUploaderOption<TModel, TValue> SelectChangeClass(string value)
        {
            Attributes["selectChangeClass"] = value;
            return this;
        }

        public JasnyUploaderOption<TModel, TValue> RemoveClass(string value)
        {
            Attributes["removeClass"] = value;
            return this;
        }

        public JasnyUploaderOption<TModel, TValue> FixSize(bool value)
        {
            Attributes["fixSize"] = value;
            return this;
        }

        public JasnyUploaderOption<TModel, TValue> AutoUpload(bool value)
        {
            Attributes["autoUpload"] = value;
            return this;
        }

        public JasnyUploaderOption<TModel, TValue> DefaultPreview(bool value)
        {
            Attributes["defaultPreview"] = value;
            return this;
        }

        public JasnyUploaderOption<TModel, TValue> DefaultImage(string value)
        {
            Attributes["defaultImage"] = value;
            return this;
        }

        public JasnyUploaderOption<TModel, TValue> DefaultImage(JasnyDefaultImage value)
        {
            string resource = string.Format("DNZ.MvcComponents.JasnyUploader.img.{0}.gif", value.ToString());
            Attributes["defaultImage"] = ComponentUtility.GetWebResourceUrl(resource);
            return this;
        }

        public JasnyUploaderOption<TModel, TValue> LoadingImage(JasnyLoading value)
        {
            Attributes["loadingImage"] = value.ToString().ToLower();
            return this;
        }

        public JasnyUploaderOption<TModel, TValue> Width(int value)
        {
            Attributes["width"] = value;
            return this;
        }

        public JasnyUploaderOption<TModel, TValue> Height(int value)
        {
            Attributes["height"] = value;
            return this;
        }

        public JasnyUploaderOption<TModel, TValue> UrlImage(string url)
        {
            Attributes["urlImage"] = url;
            return this;
        }

        public JasnyUploaderOption<TModel, TValue> UploadUrl(string url)
        {
            Attributes["uploadUrl"] = url;
            return this;
        }

        public JasnyUploaderOption<TModel, TValue> UploadUrlAction(string action)
        {
            IUrlHelper urlHelper = HtmlHelper.GetUrlHelper();
            string url = urlHelper.Action(new UrlActionContext { Action = action });
            return UploadUrl(url);
        }

        public JasnyUploaderOption<TModel, TValue> UploadUrlAction(string action, object routeValues)
        {
            IUrlHelper urlHelper = HtmlHelper.GetUrlHelper();
            string url = urlHelper.Action(new UrlActionContext { Action = action, Values = routeValues });
            return UploadUrl(url);
        }

        public JasnyUploaderOption<TModel, TValue> UploadUrlAction(string action, RouteValueDictionary routeValues)
        {
            IUrlHelper urlHelper = HtmlHelper.GetUrlHelper();
            string url = urlHelper.Action(new UrlActionContext { Action = action, Values = routeValues });
            return UploadUrl(url);
        }

        public JasnyUploaderOption<TModel, TValue> UploadUrlAction(string action, string controller)
        {
            IUrlHelper urlHelper = HtmlHelper.GetUrlHelper();
            string url = urlHelper.Action(new UrlActionContext { Action = action, Controller = controller });
            return UploadUrl(url);
        }

        public JasnyUploaderOption<TModel, TValue> UploadUrlAction(string action, string controller, object routeValues)
        {
            IUrlHelper urlHelper = HtmlHelper.GetUrlHelper();
            string url = urlHelper.Action(new UrlActionContext { Action = action, Controller = controller, Values = routeValues });
            return UploadUrl(url);
        }

        public JasnyUploaderOption<TModel, TValue> UploadUrlAction(string action, string controller, RouteValueDictionary routeValues)
        {
            IUrlHelper urlHelper = HtmlHelper.GetUrlHelper();
            string url = urlHelper.Action(new UrlActionContext { Action = action, Controller = controller, Values = routeValues });
            return UploadUrl(url);
        }

        public string ToHtmlString()
        {
            ViewFeatures.ModelExplorer metadata = ExpressionMetadataProvider.FromLambdaExpression(Expression, HtmlHelper.ViewData, HtmlHelper.MetadataProvider);
            string htmlFieldName = ExpressionHelper.GetExpressionText(Expression);
            IHtmlContent label = HtmlHelper.LabelFor(Expression, new { @class = "control-label", style = "padding: 0 0 10px 0;" });
            string id = HtmlHelper.FieldIdFor(Expression); //.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName);
            string name = HtmlHelper.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName);
            string value = metadata.Model?.ToString() ?? "";

            string script = "";
            if (JustPartial)
            {
                script += "<link href=\"" + ComponentUtility.GetWebResourceUrl(jasny_bootstrap_css) + "\" rel=\"stylesheet\" />\n\n";
                script += "<script src=\"" + ComponentUtility.GetWebResourceUrl(jasny_bootstrap_js) + "\"></script>\n";
            }
            else
            {
                HtmlHelper.StyleFileSingle(@"<link href=""" + ComponentUtility.GetWebResourceUrl(jasny_bootstrap_css) + @""" rel=""stylesheet"" />");
                HtmlHelper.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(jasny_bootstrap_js) + @"""></script>");
            }
            string url = Attributes["uploadUrl"].ToString();
            string selectIcon = Attributes["selectIcon"].ToString() == "" ? "" : string.Format(@"<i class=""{0}""></i> ", Attributes["selectIcon"]);
            string changeIcon = Attributes["changeIcon"].ToString() == "" ? "" : string.Format(@"<i class=""{0}""></i> ", Attributes["changeIcon"]);
            string removeIcon = Attributes["removeIcon"].ToString() == "" ? "" : string.Format(@"<i class=""{0}""></i> ", Attributes["removeIcon"]);
            string urlImage = Attributes["urlImage"].ToString();
            string defaultImageValue = Attributes["defaultImage"].ToString();
            if (/*urlImage != "" && */value != "")
            {
                defaultImageValue = urlImage.Contains("{0}") ? string.Format(urlImage, value) : (urlImage + value);
            }
            string defaultImage = Attributes["defaultImage"].ToString() == "" ? "" : $@"<img src=""{defaultImageValue}"" />";
            bool autoUpload = Convert.ToBoolean(Attributes["autoUpload"]);
            string width = Attributes["width"] + "px";
            string height = Attributes["height"] + "px";
            string max = Convert.ToBoolean(Attributes["fixSize"]) ? "" : "max-";
            string styles = $"{max}width: {width}; {max}height: {height};";

            script += @"
            <script>
                $(function(){
                    var changedCount = 0;
                    var clearedCount = 0;
                    $(""#" + id + @"_jasnyUpload"").jasnyfileinput()" + ((autoUpload && url != "") ? @"
                    .on(""change.bs.fileinput"", function () {
                        $('<div class=""jasny-loading " + Attributes["loadingImage"] + @""" ></div>').insertAfter($(this).find("".fileinput-preview img""));
                        var hidden = $(""#" + id + @""");
                        hidden.val('');
                        var data = new FormData();
                        data.append('file', $(""#" + id + @"_jasnyFile"")[0].files[0]);
                        $.ajax({
                            url: '" + url + @"',
                            type: 'POST',
                            data: data,
                            cache: false,
                            contentType: false,
                            processData: false,
                            success: function (response) {
                                $(""#" + id + @"_jasnyUpload "").find("".jasny-loading." + Attributes["loadingImage"] + @""").remove();
                                hidden.val(response).valid();
                            }
                        });
                    }).on(""clear.bs.fileinput"", function () {
                        $(""#" + id + @""").val('" + (value != "" ? value : "") + @"').valid();
                    });" : "") + @"
                });
            </script>";

            string defaultPreview = Convert.ToBoolean(Attributes["defaultPreview"]) ?
                    $@"<div class=""fileinput-new thumbnail"" style=""width:{width}; height: {height}"">
                        {defaultImage}
                    </div>" : "";
            string result = $@"
            <div id=""{id}_jasnyUpload"" class=""fileinput fileinput-new text-center"" data-provides=""fileinput"">
                <div>{label.ToHtmlString() }</div>
                    {defaultPreview}
                    <div class=""fileinput-preview fileinput-exists thumbnail"" style=""{styles}""></div>
                <div>
                    <span class=""{Attributes["selectChangeClass"]} btn-file"">
                        <span class=""fileinput-new"">{selectIcon}{Attributes["selectText"]}</span>
                        <span class=""fileinput-exists"">{changeIcon}{Attributes["changeText"]}</span>
                        <input type=""file"" id=""{id}_jasnyFile"" name=""{(autoUpload ? "file" : name)}"" accept=""{accept}"">
                    </span>
                    <a href=""#"" class=""{Attributes["removeClass"]} fileinput-exists"" data-dismiss=""fileinput"">{removeIcon}{Attributes["removeText"]}</a>
                </div>
                {(autoUpload ? HtmlHelper.HiddenFor(Expression, new { id }).ToHtmlString() : "")}
            </div>";

            if (JustPartial)
            {
                result += Environment.NewLine + Environment.NewLine + script;
            }
            else
            {
                HtmlHelper.Script(script);
            }

            return result;
        }

        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            writer.Write(ToHtmlString());
        }
    }
}
