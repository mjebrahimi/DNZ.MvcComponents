using Microsoft.AspNetCore.Html;
using System.IO;
using System.Text.Encodings.Web;

namespace Microsoft.AspNetCore.Mvc
{
    public abstract class BaseComponent : IHtmlContent
    {
        public abstract string ToHtmlString();

        public override string ToString()
        {
            return ToHtmlString();
        }

        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            writer.WriteLine(ToHtmlString());
        }
    }
}
