using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;

namespace DNZ.MvcComponents
{
    public static class ComponentUtility
    {
        private const string path = "/DNZ.MvcComponents";
        internal static IServiceProvider ApplicationServiceProvider { get; private set; }


        public static IServiceCollection AddMvcComponents(this IServiceCollection services)
        {
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
                        string fileName = Path.GetFileName(context.Request.Path.ToString());
                        string content = GetWebResource(fileName);
                        context.Response.ContentType = GetMimeType(fileName);
                        if (content == null)
                        {
                            context.Response.StatusCode = 404;
                        }
                        else
                        {
                            context.Response.ContentLength = Encoding.UTF8.GetByteCount(content);
                            await context.Response.WriteAsync(content, Encoding.UTF8);
                        }
                    });
                });
            return appBuilder;
        }

        public static string GetMimeType(string fileName)
        {
            new FileExtensionContentTypeProvider().TryGetContentType(fileName, out string contentType);
            return contentType ?? "application/octet-stream";
        }

        public static HttpContext GetHttpContext()
        {
            return ApplicationServiceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext;
        }

        public static IUrlHelper GetUrlHelper(this IHtmlHelper htmlHelper)
        {
            IUrlHelperFactory urlFactory = htmlHelper.ViewContext.HttpContext.RequestServices.GetRequiredService<IUrlHelperFactory>();
            IActionContextAccessor actionAccessor = htmlHelper.ViewContext.HttpContext.RequestServices.GetRequiredService<IActionContextAccessor>();
            return urlFactory.GetUrlHelper(actionAccessor.ActionContext);
        }

        public static IUrlHelper GetUrlHelper(this HttpContext httpContext)
        {
            IUrlHelperFactory urlFactory = httpContext.RequestServices.GetRequiredService<IUrlHelperFactory>();
            IActionContextAccessor actionAccessor = httpContext.RequestServices.GetRequiredService<IActionContextAccessor>();
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

            if (request.Headers != null)
            {
                return request.Headers["X-Requested-With"] == "XMLHttpRequest";
            }

            return false;
        }

        public static string GetFullHtmlFieldId(this TemplateInfo templateInfo, string name)
        {
            return templateInfo.GetFullHtmlFieldName(name).Replace(".", "_");
        }

        public static string FieldNameFor<T, TResult>(this IHtmlHelper<T> html, Expression<Func<T, TResult>> expression)
        {
            return html.ViewData.TemplateInfo.GetFullHtmlFieldName(ExpressionHelper.GetExpressionText(expression));
        }

        public static string FieldIdFor<T, TResult>(this IHtmlHelper<T> html, Expression<Func<T, TResult>> expression)
        {
            string name = ExpressionHelper.GetExpressionText(expression);
            //var id = html.ViewData.TemplateInfo.GetFullHtmlFieldId(name);
            // because "[" and "]" aren't replaced with "_" in GetFullHtmlFieldId

            return html.ViewData.TemplateInfo.GetFullHtmlFieldName(name).Replace('[', '_').Replace(']', '_').Replace('.', '_');
        }

        public static string ToLowerFirst(this string str)
        {
            char[] a = str.ToCharArray();
            a[0] = char.ToLower(a[0]);
            return new string(a);
            //return str.Substring(0, 1).ToLower() + str.Substring(1);
        }

        public static T ConvertTo<T>(this object obj)
        {
            return (T)Convert.ChangeType(obj, typeof(T));
        }

        public static string ToDescription(this Enum value)
        {
            DisplayNameAttribute[] attributes = (DisplayNameAttribute[])value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DisplayNameAttribute), false);
            return attributes.Length > 0 ? attributes[0].DisplayName : value.ToString();
        }

        public static object ToAnonymousObject<TKey, TValue>(this IDictionary<TKey, TValue> dic)
        {
            ExpandoObject expandoObject = new ExpandoObject();
            IDictionary<string, object> expandoDictionary = expandoObject;

            foreach (KeyValuePair<TKey, TValue> keyValuePair in dic)
            {
                expandoDictionary.Add(keyValuePair.Key.ConvertTo<string>(), keyValuePair.Value.ConvertTo<string>());
            }

            return expandoObject;
        }

        public static void DefinGlobalJavascriptVariable(this IScript script, IHtmlHelper html, string name)
        {
            html.Script(@"
            <script>
                var " + name + @";
                $(function(){
                    " + name + " = " + script.Script + @" 
                });
            </script>");
        }

        public static string GetWebResourceUrl(string resourceId)
        {
            return $"{path}/{resourceId}";
        }

        public static string GetWebResource(string resourceId)
        {
            Type type = typeof(ComponentUtility);
            using (Stream stream = type.Assembly.GetManifestResourceStream(resourceId))
            {
                if (stream == null)
                {
                    return null;
                }

                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public static string GetWebResource(Type type, string resourceId)
        {
            type.NotNull(nameof(type));
            using (Stream stream = type.Assembly.GetManifestResourceStream(type, resourceId))
            {
                if (stream == null)
                {
                    return null;
                }

                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public static string ToJsonStringWithoutQuotes(object value)
        {
            JsonSerializer serializer = new JsonSerializer();
            StringWriter stringWriter = new StringWriter();
            using (JsonTextWriter jsonWriter = new JsonTextWriter(stringWriter))
            {
                jsonWriter.QuoteName = false;
                serializer.Serialize(jsonWriter, value);
                return stringWriter.ToString();
            }
        }

        public static string ToJsonString(object value)
        {
            return JsonConvert.SerializeObject(value);
        }

        #region MergeAttributes
        private static object GetValue(IGrouping<string, KeyValuePair<string, object>> source, bool appendCssClass)
        {
            if (appendCssClass)
            {
                return source.Key == "class" ? string.Join(" ", source.Select(p => p.Value)) : source.First().Value;
            }

            return source.First().Value;
        }

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
            Dictionary<string, object> primary = primaryAttributes as Dictionary<string, object>;
            Dictionary<string, object> secondary = secondaryAttributes as Dictionary<string, object>;

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

            Dictionary<string, object> attributes = new RouteValueDictionary(primaryAttributes).Concat(new RouteValueDictionary(secondaryAttributes)).GroupBy(d => d.Key)
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
        #endregion

        public static string RenderOptions(this IOptionBuilder options)
        {
            string result = string.Join(", \n", options.Attributes.Select(p => p.Key + ": " + p.Value));
            return "{\n" + result + "\n}";
        }

        public static string RenderOptions(this Dictionary<string, object> attributes)
        {
            string result = string.Join(", \n", attributes.Select(p => p.Key + ": " + p.Value));
            return "{\n" + result + "\n}";
        }

        private static long lastTimeStamp = DateTime.UtcNow.Ticks;

        public static long UtcNowTicks
        {
            get
            {
                long original, newValue;
                do
                {
                    original = lastTimeStamp;
                    long now = DateTime.UtcNow.Ticks;
                    newValue = Math.Max(now, original + 1);
                } while (Interlocked.CompareExchange(ref lastTimeStamp, newValue, original) != original);

                return newValue;
            }
        }

        public static string ToJavaScriptString(this string template)
        {
            string safeText = template.Replace('\'', '"');
            string[] lines = safeText.Split('\n');
            IEnumerable<string> linesWithQuotes = lines.Select(p => string.Format("'{0}'", p.Trim('\n', '\r', ' ')));
            string result = string.Join("+\n", linesWithQuotes);
            return result;
        }

        public static T GetPropValue<T>(object src, string propName)
        {
            object value = src.GetType().GetProperty(propName).GetValue(src, null);
            return (T)value;
        }

        public static string ToHtmlString(this IHtmlContent tag)
        {
            using (StringWriter writer = new StringWriter())
            {
                tag.WriteTo(writer, HtmlEncoder.Default);
                return writer.ToString();
            }
        }
    }
}
