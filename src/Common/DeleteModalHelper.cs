using DNZ.MvcComponents;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Routing;
using System.Globalization;
using System.Linq;

namespace Microsoft.AspNetCore.Mvc.Rendering
{
    public static class DeleteModalHelper
    {
        public static IHtmlContent DeleteModal(this IHtmlHelper htmlHelper, object routeValues, string actionName = "Delete", string controllerName = null)
        {
            htmlHelper.NotNull(nameof(htmlHelper));
            actionName.NotNull(nameof(actionName));
            routeValues.NotNull(nameof(routeValues));

            var urlHelper = htmlHelper.GetUrlHelper();
            var url = urlHelper.Action(actionName, controllerName);
            var modalId = "DeleteModal_" + url.GetHashCode().ToString(CultureInfo.InvariantCulture).Replace('-', '0'); //negative (-) in naming cause error in javascript
            var funcName = $"setValues_{modalId}";

            var dictionary = new RouteValueDictionary(routeValues);
            CreateDeleteModal();

            var passArguments = string.Join(", ", dictionary.Select(p => $"'{p.Value}'"));
            var script = htmlHelper.Dialog(modalId).Show().Script + "; " + $"{funcName}({passArguments});";

            return new HtmlString(script);

            void CreateDeleteModal()
            {
                var arguments = string.Join(", ", dictionary.Select(p => p.Key));
                var setValues = string.Join("\n", dictionary.Select(p => $@"$(""#{modalId} #{p.Key}"").val({p.Key});"));
                var inputs = string.Join("\n", dictionary.Select(p => $@"<input type=""hidden"" id=""{p.Key}"" name=""{p.Key}"" />"));

                var dialog = MessageBox.Dialog(modalId, "حذف",
                $@"<div>
                    آیا جهت حذف اطمینان دارید?
                    {inputs}
                </div>",
                @"<div>
                    <input type=""submit"" value=""بله"" class=""btn btn-danger"" />
                </div>");

                var html =
                $@"<form action=""{url}"" method=""post"">
                    {htmlHelper.AntiForgeryToken().ToHtmlString()}
                    {dialog.ToHtmlString()}
                </form>
                <script>
                    function {funcName}({arguments}) {{
                        {setValues}
                    }}
                </script>";

                htmlHelper.ScriptOnce(html);
            }
        }

        #region Old
        //public static IHtmlContent DeleteModal<T>(this IHtmlHelper htmlHelper, T id, string actionName = "Delete", string controllerName = null)
        //{
        //    htmlHelper.NotNull(nameof(htmlHelper));
        //    actionName.NotNull(nameof(actionName));
        //    id.NotNull(nameof(id));

        //    controllerName ??= htmlHelper.ViewContext.RouteData.Values["controller"].ToString();
        //    var modalId = $"DeleteModal_{controllerName}_{actionName.ToLower()}";
        //    var script = htmlHelper.Dialog(modalId).Show().Script + "; " + $"setValues_{modalId}('{id}');";

        //    return new HtmlString(script);
        //}

        //public static HtmlString CreateDeleteModal(this IHtmlHelper htmlHelper, string actionName = "Delete", string controllerName = null)
        //{
        //    htmlHelper.NotNull(nameof(htmlHelper));
        //    actionName.NotNull(nameof(actionName));

        //    controllerName ??= htmlHelper.ViewContext.RouteData.Values["controller"].ToString();
        //    var modalId = $"DeleteModal_{controllerName}_{actionName.ToLower()}";
        //    var urlHelper = htmlHelper.GetUrlHelper();
        //    var url = urlHelper.Action(actionName, controllerName);

        //    var dialog = MessageBox.Dialog(modalId, "حذف",
        //        @"<div>
        //            آیا جهت حذف اطمینان دارید?
        //            <input type=""hidden"" id=""Id"" name=""Id"" />
        //        </div>",
        //        @"<div>
        //            <input type=""submit"" value=""بله"" class=""btn btn-danger"" />
        //        </div>");

        //    var result =
        //    $@"<form action=""{url}"" method=""post"">
        //        {htmlHelper.AntiForgeryToken().ToHtmlString()}
        //        {dialog.ToHtmlString()}
        //    </form>
        //    <script>
        //        function setValues_{modalId}(id) {{
        //            $(""#{modalId} #Id"").val(id);
        //        }}
        //    </script>";

        //    return new HtmlString(result);
        //}

        //public static Task<IHtmlContent> CreateDeleteModalAsync(this IHtmlHelper htmlHelper, string modalId, bool ajax = false, string actionName = "Delete")
        //{
        //    htmlHelper.ViewBag.ajax = ajax;
        //    htmlHelper.ViewBag.actionName = actionName;
        //    modalId = modalId.Replace('.', '_');
        //    return htmlHelper.PartialAsync("_DeleteView", modalId);
        //}
        #endregion
    }
}
