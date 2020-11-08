//using Microsoft.AspNetCore.Html;
//using Microsoft.AspNetCore.Mvc.ModelBinding;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.AspNetCore.Mvc.ViewFeatures;
//using System;
//using System.Linq.Expressions;

//namespace Microsoft.AspNetCore.Mvc
//{
//    public static class UploadHtmlHelpers
//    {
//        public static IHtmlContent Upload(this IHtmlHelper helper, string name, object htmlAttributes = null)
//        {
//            //helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(ExpressionHelper.GetExpressionText(expression))
//            var input = new TagBuilder("input");
//            input.Attributes.Add("type", "file");
//            input.Attributes.Add("id", helper.ViewData.TemplateInfo.GetFullHtmlFieldId(name));
//            input.Attributes.Add("name", helper.ViewData.TemplateInfo.GetFullHtmlFieldName(name));

//            if (htmlAttributes != null)
//            {
//                var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
//                input.MergeAttributes(attributes);
//            }

//            return new HtmlString(input.ToString());
//        }

//        public static IHtmlContent UploadFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
//        {
//            //helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(ExpressionHelper.GetExpressionText(expression))
//            var data = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
//            var input = new TagBuilder("input");
//            input.Attributes.Add("type", "file");
//            input.Attributes.Add("id", helper.ViewData.TemplateInfo.GetFullHtmlFieldId(ExpressionHelper.GetExpressionText(expression)));
//            input.Attributes.Add("name", helper.ViewData.TemplateInfo.GetFullHtmlFieldName(ExpressionHelper.GetExpressionText(expression)));

//            if (htmlAttributes != null)
//            {
//                var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
//                input.MergeAttributes(attributes);
//            }

//            return new HtmlString(input.ToString());
//        }
//    }
//}
