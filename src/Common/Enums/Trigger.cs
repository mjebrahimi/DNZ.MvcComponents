using System;

namespace Microsoft.AspNetCore.Mvc
{
    [Flags]
    public enum Trigger
    {
        Click = 2,
        Hover = 4,
        Focus = 8,
        MouseOver = 16
    }
}