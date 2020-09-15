using Microsoft.AspNetCore.Mvc.Rendering;

namespace Microsoft.AspNetCore.Mvc
{
    public static partial class MessageBox
    {
        public static BootBox BootBox(string title)
        {
            return new BootBox().Title(title).Type(BootBoxType.Alert);
        }

        public static BootBox BootBox(string message, string title = "پیغام")
        {
            return new BootBox().Title(title).Message(message).Type(BootBoxType.Alert);
        }

        public static BootBox BootBox(string title, BootBoxType type)
        {
            return new BootBox().Title(title).Type(type);
        }

        public static BootBox BootBox(this IHtmlHelper helper, string title)
        {
            return new BootBox(helper).Title(title).Type(BootBoxType.Alert);
        }

        public static BootBox BootBox(this IHtmlHelper helper, string message, string title = "پیغام")
        {
            return new BootBox(helper).Title(title).Message(message).Type(BootBoxType.Alert);
        }

        public static BootBox BootBox(this IHtmlHelper helper, string title, BootBoxType type)
        {
            return new BootBox(helper).Title(title).Type(type);
        }
    }
}
