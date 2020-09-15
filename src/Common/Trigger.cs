using System;

namespace Microsoft.AspNetCore.Mvc
{
    [Flags]
    public enum Trigger
    {
        Click,
        Hover,
        Focus,
        MouseOver
    }
}