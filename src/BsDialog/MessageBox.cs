using Microsoft.AspNetCore.Mvc.Rendering;

namespace Microsoft.AspNetCore.Mvc
{
    public static partial class MessageBox
    {
        public static BsDialog BsDialog(string message)
        {
            return new BsDialog().Message(message).Title("پیام").Type(DialogType.Default);
        }

        public static BsDialog BsDialog(string message, DialogType type)
        {
            return new BsDialog().Message(message).Title("پیام").Type(type);
        }

        public static BsDialog BsDialog(string message, string title)
        {
            return new BsDialog().Message(message).Title(title).Type(DialogType.Default);
        }

        public static BsDialog BsDialog(string message, string title, DialogType type)
        {
            return new BsDialog().Message(message).Title(title).Type(type);
        }

        public static BsDialog BsDialog(this IHtmlHelper helper, string message)
        {
            return new BsDialog(helper).Message(message).Title("پیام").Type(DialogType.Default);
        }

        public static BsDialog BsDialog(this IHtmlHelper helper, string message, DialogType type)
        {
            return new BsDialog(helper).Message(message).Title("پیام").Type(type);
        }

        public static BsDialog BsDialog(this IHtmlHelper helper, string message, string title)
        {
            return new BsDialog(helper).Message(message).Title(title).Type(DialogType.Default);
        }

        public static BsDialog BsDialog(this IHtmlHelper helper, string message, string title, DialogType type)
        {
            return new BsDialog(helper).Message(message).Title(title).Type(type);
        }
    }
}