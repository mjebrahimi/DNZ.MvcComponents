using Microsoft.AspNetCore.Mvc.Rendering;

namespace Microsoft.AspNetCore.Mvc
{
    public static partial class MessageBox
    {
        public static SweetAlertBs SweetAlertBs(this IHtmlHelper helper, string message, string title = "پیام", SweetAlertIcon type = SweetAlertIcon.None)
        {
            return new SweetAlertBs(helper).Text(message).Title(title).Type(type);
        }

        public static SweetAlertBs SweetAlertBs(string message, string title = "پیام", SweetAlertIcon type = SweetAlertIcon.None)
        {
            return new SweetAlertBs().Text(message).Title(title).Type(type);
        }
    }
}