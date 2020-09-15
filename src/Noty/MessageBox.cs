using Microsoft.AspNetCore.Mvc.Rendering;
using DNZ.MvcComponents;

namespace Microsoft.AspNetCore.Mvc
{
    public static partial class MessageBox
    {
        public static Noty Noty(string text, MessageType type = MessageType.Alert, bool modal = false, MessageAlignment layout = MessageAlignment.Center, bool dismissQueue = false)
        {
            return new Noty().Text(text).Type(type).Modal(modal).Layout(layout).DismissQueue(dismissQueue);
        }

        public static Noty Noty(this IHtmlHelper helper, string text, MessageType type = MessageType.Alert, bool modal = false, MessageAlignment layout = MessageAlignment.Center, bool dismissQueue = false)
        {
            return new Noty(helper).Text(text).Type(type).Modal(modal).Layout(layout).DismissQueue(dismissQueue);
        }

        public static JavaScriptResult Show(string message, MessageType type = MessageType.Alert, bool modal = false, MessageAlignment layout = MessageAlignment.Center, bool dismissQueue = false)
        {
            string txt = "$.noty.closeAll(); noty({ text: \"" + message + "\", type: \"" + type.ToString().ToLower() + "\", layout: \"" + layout.ToString().ToLowerFirst() + "\", dismissQueue: " + dismissQueue.ToString().ToLower() + ", modal: " + modal.ToString().ToLower() + ", timeout: 5000 });";
            return new JavaScriptResult { Script = txt };
        }
    }
}