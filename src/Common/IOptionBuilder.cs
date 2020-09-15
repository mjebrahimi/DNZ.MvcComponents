using System.Collections.Generic;

namespace Microsoft.AspNetCore.Mvc
{
    public interface IOptionBuilder
    {
        Dictionary<string, object> Attributes { get; set; }
    }
}
