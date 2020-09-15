using Microsoft.AspNetCore.Html;
using System;
using System.IO;
using System.Text.Encodings.Web;

namespace Microsoft.AspNetCore.Mvc
{
    public abstract class BaseComponent : IHtmlContent
    {
        public virtual string ToHtmlString()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return ToHtmlString();
        }

        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            writer.WriteLine(ToString());
        }
    }
}
