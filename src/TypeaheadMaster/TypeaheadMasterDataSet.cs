using DNZ.MvcComponents;
using System.Collections.Generic;

namespace Microsoft.AspNetCore.Mvc
{
    public class TypeaheadMasterDataSet : IOptionBuilder
    {
        public Dictionary<string, object> Attributes { get; set; }

        public TypeaheadMasterDataSet()
        {
            Attributes = new Dictionary<string, object>();
        }

        public TypeaheadMasterDataSet Source(string value)
        {
            Attributes["source"] = value;
            return this;
        }

        public TypeaheadMasterDataSet Limit(int value)
        {
            Attributes["limit"] = value;
            return this;
        }

        public TypeaheadMasterDataSet Name(string value)
        {
            Attributes["name"] = string.Format("'{0}'", value);
            return this;
        }

        public TypeaheadMasterDataSet Display(string value)
        {
            Attributes["display"] = string.Format("'{0}'", value);
            return this;
        }

        public TypeaheadMasterDataSet Display(TypeaheadMasterTemplate template)
        {
            Attributes["templates"] = template.RenderOptions();
            return this;
        }
    }
}