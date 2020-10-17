using Microsoft.AspNetCore.Mvc.Rendering;

namespace Microsoft.AspNetCore.Mvc
{
    public static partial class MessageBox
    {
        public static SweetAlert SweetAlert(this IHtmlHelper helper, string message, string title = "پیام", SweetAlertType type = SweetAlertType.Default)
        {
            return new SweetAlert(helper).Text(message).Title(title).Type(type);
        }

        public static SweetAlert SweetAlert(string message, string title = "پیام", SweetAlertType type = SweetAlertType.Default)
        {
            return new SweetAlert().Text(message).Title(title).Type(type);
        }
    }
}