using System.ComponentModel;

namespace Microsoft.AspNetCore.Mvc
{
    public enum ToastrAlignment
    {
        [Description("toast-top-right")]
        TopRight,

        [Description("toast-bottom-right")]
        BottomRight,

        [Description("toast-top-left")]
        TopLeft,

        [Description("toast-bottom-left")]
        BottomLeft,

        [Description("toast-top-full-width")]
        TopFullWidth,

        [Description("toast-bottom-full-width")]
        BottomFullWidth,

        [Description("toast-top-center")]
        TopCenter,

        [Description("toast-bottom-center")]
        BottomCenter
    }
}