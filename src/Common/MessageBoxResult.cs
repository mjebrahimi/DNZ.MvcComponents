using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;

namespace Microsoft.AspNetCore.Mvc
{
    public class MessageBoxResult : JavaScriptResult, IHtmlContent, IOptionBuilder
    {
        private readonly string guid;
        protected IHtmlHelper HtmlHelper;
        public Dictionary<string, object> Attributes { get; set; }
        //public IHtmlContent Js => new HtmlString(Script); //prevent encoding script

        public MessageBoxResult(IHtmlHelper helper)
        {
            guid = Guid.NewGuid().ToString();
            HtmlHelper = helper;
            Attributes = new Dictionary<string, object>();
        }

        protected void SetScriptTag()
        {
            var script = @"<script>
                        $(function(){
                            " + Script + @"
                        });
                    </script>";
            RenderScriptAndStyle.ScriptOnce(guid, script, true);
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
