using System.ComponentModel.DataAnnotations;

namespace Microsoft.AspNetCore.Mvc
{
    public enum ComponentDirection
    {
        [Display(Name = "rtl")]
        RightToLeft,

        [Display(Name = "ltr")]
        LeftToRight
    }
}
