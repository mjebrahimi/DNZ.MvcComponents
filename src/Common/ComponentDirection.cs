using System.ComponentModel;

namespace Microsoft.AspNetCore.Mvc
{
    public enum ComponentDirection
    {
        [Description("rtl")]
        RightToLeft,

        [Description("ltr")]
        LeftToRight
    }
}
