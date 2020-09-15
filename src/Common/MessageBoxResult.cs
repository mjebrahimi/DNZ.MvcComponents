using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;

namespace Microsoft.AspNetCore.Mvc
{
    public class JavaScriptResult : ContentResult
    {
        public JavaScriptResult()
        {
            ContentType = "text/javascript";
        }

        public string Script
        {
            get => Content;
            set => Content = value;
        }
    }

    public class MessageBoxResult : JavaScriptResult, IHtmlContent, IOptionBuilder
    {
        protected string Guid;
        protected IHtmlHelper HtmlHelper;
        public Dictionary<string, object> Attributes { get; set; }
        public IHtmlContent Js => new HtmlString(Script);

        public MessageBoxResult(IHtmlHelper helper)
        {
            Attributes = new Dictionary<string, object>();
            Guid = System.Guid.NewGuid().ToString();
            HtmlHelper = helper;
        }

        protected void SetScriptTag()
        {
            string script = @"<script>
                        $(function(){
                            " + Script + @"
                        });
                    </script>";
            RenderScriptAndStyle.ScriptSingle(Guid, script, true);
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
