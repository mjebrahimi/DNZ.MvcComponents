using Microsoft.AspNetCore.Mvc.Rendering;

namespace Microsoft.AspNetCore.Mvc
{
    public static partial class MessageBox
    {
        public static Toastr Toastr(string text, string title = "پیام", ToastrType type = ToastrType.Info)
        {
            return new Toastr().Text(text).Title(title).Type(type);
        }

        public static Toastr Toastr(this IHtmlHelper helper, string text, string title = "پیام", ToastrType type = ToastrType.Info)
        {
            return new Toastr(helper).Text(text).Title(title).Type(type);
        }
    }
}
