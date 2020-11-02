using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;

namespace Microsoft.AspNetCore.Mvc
{
    public class MessageBoxResult : JavaScriptResult, IHtmlContent, IOptionBuilder
    {
        protected IHtmlHelper HtmlHelper;
        public Dictionary<string, object> Attributes { get; set; }
        public IHtmlContent Js => new HtmlString(Script);

        public MessageBoxResult(IHtmlHelper helper)
        {
            Attributes = new Dictionary<string, object>();
            HtmlHelper = helper;
        }

        protected void SetScriptTag()
        {
            var script = @"<script>
                        $(function(){
                            " + Script + @"
                        });
                    </script>";
            RenderScriptAndStyle.ScriptOnce(script, true);
        }

        public virtual string ToHtmlString()
        {
            SetScriptTag();
            return "";
        }

        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            writer.WriteLine(ToHtmlString());
        }
    }
}
