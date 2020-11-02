using Microsoft.AspNetCore.Mvc.Rendering;

namespace Microsoft.AspNetCore.Mvc
{
    public static partial class MessageBox
    {
        public static SweetAlert SweetAlert(this IHtmlHelper helper, string message, string title = "پیام", SweetAlertIcon type = SweetAlertIcon.None)
        {
            return new SweetAlert(helper).Text(message).Title(title).Icon(type);
        }

        public static SweetAlert SweetAlert(string message, string title = "پیام", SweetAlertIcon type = SweetAlertIcon.None)
        {
            return new SweetAlert().Text(message).Title(title).Icon(type);
        }
    }
}