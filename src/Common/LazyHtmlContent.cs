using Microsoft.AspNetCore.Html;
using System;
using System.IO;
using System.Text.Encodings.Web;

namespace Microsoft.AspNetCore.Mvc
{
    public class LazyHtmlContent : IHtmlContent
    {
        private readonly Func<string> _func;
        public LazyHtmlContent(Func<string> func)
        {
            _func = func;
        }
        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            string result = _func();
            writer.WriteLine(result);
        }
    }
}