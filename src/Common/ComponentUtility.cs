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
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;

namespace DNZ.MvcComponents
{
    public static class ComponentUtility
    {
        private const string path = "/DNZ.MvcComponents";
        private static IServiceProvider ApplicationServiceProvider;
        private static bool UseCdn;

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
                        var content = GetWebResource(fileName);
                        context.Response.ContentType = GetMimeType(fileName);
                        if (content == null)
                        {
                            context.Response.StatusCode = 404;
                        }
                        else
                        {
                            context.Response.ContentLength = Encoding.UTF8.GetByteCount(content);
                            await context.Response.WriteAsync(content, Encoding.UTF8).ConfigureAwait(false);
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
        public static Dictionary<string, object> MergeAttributes(object primaryAttributes, Dictionary<string, object> secondaryAttributes, bool appendCssClass = true) //not replace css class
        {
            if (primaryAttributes is Dictionary<string, object> primary)
            {
                return MergeAttributes(primary, secondaryAttributes, appendCssClass);
            }

            return new RouteValueDictionary(primaryAttributes).Concat(secondaryAttributes).GroupBy(d => d.Key).ToDictionary(d => d.Key, d => GetValue(d, appendCssClass));
        }

        public static Dictionary<string, object> MergeAttributes(object primaryAttributes, object secondaryAttributes, bool appendCssClass = true) //not replace css class
        {
            var primary = primaryAttributes as Dictionary<string, object>;
            var secondary = secondaryAttributes as Dictionary<string, object>;

            if (primary != null && secondary != null)
            {
                return MergeAttributes(primary, secondary, appendCssClass);
            }

            if (primary != null)
            {
                return MergeAttributes(primary, secondaryAttributes, appendCssClass);
            }

            if (secondary != null)
            {
                return MergeAttributes(primaryAttributes, secondary, appendCssClass);
            }

            var attributes = new RouteValueDictionary(primaryAttributes).Concat(new RouteValueDictionary(secondaryAttributes)).GroupBy(d => d.Key)
                .ToDictionary(d => d.Key.Replace('_', '-'), d => GetValue(d, appendCssClass));
            return attributes;
        }

        public static Dictionary<string, object> MergeAttributes(this Dictionary<string, object> primaryAttributes, Dictionary<string, object> secondaryAttributes, bool appendCssClass = true) //not replace css class
        {
            return primaryAttributes.Concat(secondaryAttributes).GroupBy(d => d.Key).ToDictionary(d => d.Key, d => GetValue(d, appendCssClass));
        }

        public static Dictionary<string, object> MergeAttributes(this Dictionary<string, object> primaryAttributes, object secondaryAttributes, bool appendCssClass = true) //not replace css class
        {
            if (secondaryAttributes is Dictionary<string, object> secondary)
            {
                return MergeAttributes(primaryAttributes, secondary, appendCssClass);
            }

            return primaryAttributes.Concat(new RouteValueDictionary(secondaryAttributes)).GroupBy(d => d.Key).ToDictionary(d => d.Key, d => GetValue(d, appendCssClass));

            //var input = new TagBuilder("input");
            //var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            //input.MergeAttributes(attributes);
        }

        private static object GetValue(IGrouping<string, KeyValuePair<string, object>> source, bool appendCssClass)
        {
            if (appendCssClass)
            {
                return source.Key == "class" ? string.Join(" ", source.Select(p => p.Value)) : source.First().Value;
            }

            return source.First().Value;
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

        internal static ModelExplorer GetModelExplorerForString(this IHtmlHelper html, string expression)
        {
            //IHtmlGenerator
            return html.MetadataProvider.GetModelExplorerForType(typeof(string), expression);
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

        internal static string GetWebResource(string resourceId)
        {
            var type = typeof(ComponentUtility);
            using (var stream = type.Assembly.GetManifestResourceStream(resourceId))
            {
                if (stream == null)
                    return null;

                using var reader = new StreamReader(stream, Encoding.UTF8);
                return reader.ReadToEnd();
            }
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
            where T : class
        {
            if (obj is null)
            {
                throw new ArgumentNullException($"{name} : {typeof(T)}", message);
            }

            return obj;
        }

        internal static T? NotNull<T>(this T? obj, string name, string message = null)
            where T : struct
        {
            if (!obj.HasValue)
            {
                throw new ArgumentNullException($"{name} : {typeof(T)}", message);
            }

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
