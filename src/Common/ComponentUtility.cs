using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Threading;

namespace DNZ.MvcComponents
{
    public static class ComponentUtility
    {
        private const string path = "/DNZ.MvcComponents";
        private static IServiceProvider ApplicationServiceProvider;
        private static bool UseCdn;
        private static Assembly currentAssembly = typeof(ComponentUtility).Assembly;

        public static IServiceCollection AddMvcComponents(this IServiceCollection services, bool useCdn = true)
        {
            UseCdn = useCdn;
            services.AddHttpContextAccessor();
            services.TryAddSingleton<HttpContextAccessor>();
            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.TryAddSingleton<ActionContextAccessor>();

            return services;
        }

        public static IApplicationBuilder UseMvcComponents(this IApplicationBuilder appBuilder)
        {
            ApplicationServiceProvider = appBuilder.ApplicationServices;
            appBuilder.MapWhen(
                httpContext => httpContext.Request.Path.StartsWithSegments(new PathString(path), StringComparison.OrdinalIgnoreCase), app =>
                {
                    app.Run(async context =>
                    {
                        var fileName = Path.GetFileName(context.Request.Path.ToString());
                        using var stream = currentAssembly.GetManifestResourceStream(fileName);
                        if (stream == null)
                        {
                            context.Response.StatusCode = 404;
                        }
                        else
                        {
                            context.Response.ContentLength = stream.Length;
                            context.Response.ContentType = GetMimeType(fileName);
                            await stream.CopyToAsync(context.Response.Body, context.RequestAborted);
                        }
                    });
                });
            return appBuilder;
        }

        public static IUrlHelper GetUrlHelper(this IHtmlHelper htmlHelper)
        {
            var urlFactory = htmlHelper.ViewContext.HttpContext.RequestServices.GetRequiredService<IUrlHelperFactory>();
            var actionAccessor = htmlHelper.ViewContext.HttpContext.RequestServices.GetRequiredService<IActionContextAccessor>();
            return urlFactory.GetUrlHelper(actionAccessor.ActionContext);
        }

        public static IUrlHelper GetUrlHelper(this HttpContext httpContext)
        {
            var urlFactory = httpContext.RequestServices.GetRequiredService<IUrlHelperFactory>();
            var actionAccessor = httpContext.RequestServices.GetRequiredService<IActionContextAccessor>();
            return urlFactory.GetUrlHelper(actionAccessor.ActionContext);
        }

        /// <summary>
        /// Determines whether the specified HTTP request is an AJAX request.
        /// </summary>
        ///
        /// <returns>
        /// true if the specified HTTP request is an AJAX request; otherwise, false.
        /// </returns>
        /// <param name="request">The HTTP request.</param><exception cref="T:System.ArgumentNullException">The <paramref name="request"/> parameter is null (Nothing in Visual Basic).</exception>
        public static bool IsAjaxRequest(this HttpRequest request)
        {
            request.NotNull(nameof(request));

            if (request.Headers == null)
                return false;

            return request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }

        public static string FieldNameFor<T, TResult>(this IHtmlHelper<T> html, Expression<Func<T, TResult>> expression)
        {
            //return html.NameFor(expression); //html.Name();
            var expresionProvider = html.ViewContext.HttpContext.RequestServices.GetRequiredService<ModelExpressionProvider>();
            return html.ViewData.TemplateInfo.GetFullHtmlFieldName(expresionProvider.GetExpressionText(expression));
        }

        public static string FieldIdFor<T, TResult>(this IHtmlHelper<T> html, Expression<Func<T, TResult>> expression)
        {
            //return html.IdFor(expression); //html.Id();
            var name = html.FieldNameFor(expression);
            return html.GenerateIdFromName(name);
        }

        public static string ToHtmlString(this IHtmlContent tag, HtmlEncoder htmlEncoder = null)
        {
            using var writer = new StringWriter();
            tag.WriteTo(writer, htmlEncoder ?? HtmlEncoder.Default);
            return writer.ToString();
        }

        #region MergeAttributes
        public static IDictionary<string, object> MergeAttributes(object primaryAttributes, object secondaryAttributes, bool appendCssClass = true) //not replace css class
        {
            if (secondaryAttributes is not IDictionary<string, object> secondary)
                secondary = HtmlHelper.AnonymousObjectToHtmlAttributes(secondaryAttributes);

            if (primaryAttributes is not IDictionary<string, object> primary)
                primary = HtmlHelper.AnonymousObjectToHtmlAttributes(primaryAttributes);

            return MergeAttributes(primary, secondary, appendCssClass);
        }

        public static IDictionary<string, object> MergeAttributes(this IDictionary<string, object> primaryAttributes, object secondaryAttributes, bool appendCssClass = true) //not replace css class
        {
            if (secondaryAttributes is not IDictionary<string, object> secondary)
                secondary = HtmlHelper.AnonymousObjectToHtmlAttributes(secondaryAttributes);

            return MergeAttributes(primaryAttributes, secondary, appendCssClass);
        }

        public static IDictionary<string, object> MergeAttributes(object primaryAttributes, IDictionary<string, object> secondaryAttributes, bool appendCssClass = true) //not replace css class
        {
            if (primaryAttributes is not IDictionary<string, object> primary)
                primary = HtmlHelper.AnonymousObjectToHtmlAttributes(primaryAttributes);

            return MergeAttributes(primary, secondaryAttributes, appendCssClass);
        }

        public static IDictionary<string, object> MergeAttributes(this IDictionary<string, object> primaryAttributes, IDictionary<string, object> secondaryAttributes, bool appendCssClass = true) //not replace css class
        {
            return primaryAttributes.Concat(secondaryAttributes).GroupBy(d => d.Key).ToDictionary(d => d.Key, d => GetValue(d, appendCssClass));

            static object GetValue(IGrouping<string, KeyValuePair<string, object>> source, bool appendCssClass)
            {
                if (appendCssClass && source.Key == "class")
                    return string.Join(" ", source.Select(p => p.Value));

                return source.First().Value;
            }
        }
        #endregion

        internal static string GetCssTag(string localUrl, string cdnTag)
        {
            if (localUrl == null)
                return cdnTag;
            if (cdnTag == null)
                return "<link href=\"" + GetWebResourceUrl(localUrl) + "\" rel=\"stylesheet\" />";

            return UseCdn ? cdnTag : "<link href=\"" + GetWebResourceUrl(localUrl) + "\" rel=\"stylesheet\" />";
        }

        internal static string GetJsTag(string localUrl, string cdnTag)
        {
            if (localUrl == null)
                return cdnTag;
            if (cdnTag == null)
                return "<script src=\"" + GetWebResourceUrl(localUrl) + "\"></script>";

            return UseCdn ? cdnTag : "<script src=\"" + GetWebResourceUrl(localUrl) + "\"></script>";
        }

        internal static HttpContext GetHttpContext()
        {
            return ApplicationServiceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext;
        }

        internal static ModelExplorer GetModelExplorer<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            var expresionProvider = html.ViewContext.HttpContext.RequestServices.GetRequiredService<ModelExpressionProvider>();
            return expresionProvider.CreateModelExpression(html.ViewData, expression).ModelExplorer;
        }

        private static readonly Type stringType = typeof(string);
        internal static ModelExplorer GetModelExplorerForString(this IHtmlHelper html, string expression)
        {
            //IHtmlGenerator
            return html.MetadataProvider.GetModelExplorerForType(stringType, expression);
        }

        internal static void DefinGlobalJavascriptVariable(this IScript script, IHtmlHelper html, string name)
        {
            html.Script(@"
            <script>
                var " + name + @";
                $(function(){
                    " + name + " = " + script.Script + @" 
                });
            </script>");
        }

        internal static string GetWebResourceUrl(string resourceId)
        {
            return $"{path}/{resourceId}";
        }

        internal static string RenderOptions(this IOptionBuilder options)
        {
            var result = string.Join(", \n", options.Attributes.Select(p => p.Key + ": " + p.Value));
            return "{\n" + result + "\n}";
        }

        internal static string RenderOptions(this Dictionary<string, object> attributes)
        {
            var result = string.Join(", \n", attributes.Select(p => p.Key + ": " + p.Value));
            return "{\n" + result + "\n}";
        }

        private static long lastTimeStamp = DateTime.UtcNow.Ticks;
        internal static long UtcNowTicks
        {
            get
            {
                long original, newValue;
                do
                {
                    original = lastTimeStamp;
                    var now = DateTime.UtcNow.Ticks;
                    newValue = Math.Max(now, original + 1);
                } while (Interlocked.CompareExchange(ref lastTimeStamp, newValue, original) != original);

                return newValue;
            }
        }

        internal static string ToJavaScriptString(this string template)
        {
            var safeText = template.Replace('\'', '"');
            var lines = safeText.Split('\n');
            var linesWithQuotes = lines.Select(p => string.Format("'{0}'", p.Trim('\n', '\r', ' ')));
            var result = string.Join("+\n", linesWithQuotes);
            return result;
        }

        internal static T GetPropValue<T>(object src, string propName)
        {
            var value = src.GetType().GetProperty(propName).GetValue(src, null);
            return (T)value;
        }

        internal static T NotNull<T>(this T obj, string name, string message = null)
        {
            if (obj is null)
                throw new ArgumentNullException($"{name} : {typeof(T)}", message);
            return obj;
        }

        internal static bool HasValue(this string value, bool ignoreWhiteSpace = true)
        {
            return ignoreWhiteSpace ? !string.IsNullOrWhiteSpace(value) : !string.IsNullOrEmpty(value);
        }

        internal static string ToLowerFirst(this string str)
        {
            var a = str.ToCharArray();
            a[0] = char.ToLower(a[0]);
            return new string(a);
        }

        internal static T ConvertTo<T>(this object obj)
        {
            return (T)Convert.ChangeType(obj, typeof(T));
        }

        internal static string ToDisplayName(this Enum value)
        {
            return value.GetType().GetField(value.ToString()).GetCustomAttribute<DisplayAttribute>(false).Name;
        }

        internal static string GetMimeType(string fileName)
        {
            new FileExtensionContentTypeProvider().TryGetContentType(fileName, out var contentType);
            return contentType ?? "application/octet-stream";
        }

        internal static object ToAnonymousObject<TKey, TValue>(this IDictionary<TKey, TValue> dic)
        {
            var expandoObject = new ExpandoObject();
            IDictionary<string, object> expandoDictionary = expandoObject;

            foreach (var keyValuePair in dic)
            {
                expandoDictionary.Add(keyValuePair.Key.ConvertTo<string>(), keyValuePair.Value.ConvertTo<string>());
            }

            return expandoObject;
        }

        internal static string ToJsonStringWithoutQuotes(object value)
        {
            var serializer = new JsonSerializer();
            var stringWriter = new StringWriter();
            using var jsonWriter = new JsonTextWriter(stringWriter)
            {
                QuoteName = false
            };
            serializer.Serialize(jsonWriter, value);
            return stringWriter.ToString();
        }

        internal static string ToJsonString(object value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}
