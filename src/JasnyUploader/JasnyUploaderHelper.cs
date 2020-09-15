using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq.Expressions;

namespace Microsoft.AspNetCore.Mvc
{
    public static class JasnyUploaderHelper
    {
        public static JasnyUploaderOption<TModel, TValue> JasnyUploaderFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            return new JasnyUploaderOption<TModel, TValue>(html, expression);
        }

        public static JasnyUploaderOption<TModel, TValue> JasnyUploaderFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string action = null, string controller = null, object routeValues = null, string urlImage = "")
        {
            return new JasnyUploaderOption<TModel, TValue>(html, expression).UploadUrlAction(action, controller, routeValues).UrlImage(urlImage);
        }
    }
}