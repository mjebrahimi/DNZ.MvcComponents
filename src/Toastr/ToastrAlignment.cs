using System.ComponentModel.DataAnnotations;

namespace Microsoft.AspNetCore.Mvc
{
    public enum ToastrAlignment
    {
        [Display(Name = "toast-top-right")]
        TopRight,

        [Display(Name = "toast-bottom-right")]
        BottomRight,

        [Display(Name = "toast-top-left")]
        TopLeft,

        [Display(Name = "toast-bottom-left")]
        BottomLeft,

        [Display(Name = "toast-top-full-width")]
        TopFullWidth,

        [Display(Name = "toast-bottom-full-width")]
        BottomFullWidth,

        [Display(Name = "toast-top-center")]
        TopCenter,

        [Display(Name = "toast-bottom-center")]
        BottomCenter
    }
}