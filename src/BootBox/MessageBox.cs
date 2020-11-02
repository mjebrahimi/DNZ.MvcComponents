using Microsoft.AspNetCore.Mvc.Rendering;

namespace Microsoft.AspNetCore.Mvc
{
    public static partial class MessageBox
    {
        public static BootBox BootBox(string message)
        {
            return new BootBox().Message(message).Type(BootBoxType.Alert);
        }

        public static BootBox BootBox(string message, BootBoxType type)
        {
            return new BootBox().Message(message).Type(type);
        }

        public static BootBox BootBox(string message, string title)
        {
            return new BootBox().Message(message).Title(title).Type(BootBoxType.Alert);
        }

        public static BootBox BootBox(string message, string title, BootBoxType type)
        {
            return new BootBox().Message(message).Title(title).Type(type);
        }

        public static BootBox BootBox(this IHtmlHelper helper, string message)
        {
            return new BootBox(helper).Message(message).Type(BootBoxType.Alert);
        }

        public static BootBox BootBox(this IHtmlHelper helper, string message, BootBoxType type)
        {
            return new BootBox(helper).Message(message).Type(type);
        }

        public static BootBox BootBox(this IHtmlHelper helper, string message, string title)
        {
            return new BootBox(helper).Message(message).Title(title).Type(BootBoxType.Alert);
        }

        public static BootBox BootBox(this IHtmlHelper helper, string message, string title, BootBoxType type)
        {
            return new BootBox(helper).Message(message).Title(title).Type(type);
        }
    }
}
