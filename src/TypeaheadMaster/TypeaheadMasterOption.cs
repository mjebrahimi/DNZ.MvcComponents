using DNZ.MvcComponents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.AspNetCore.Mvc
{
    public class TypeaheadMasterOption : IOptionBuilder
    {
        public Dictionary<string, object> Attributes { get; set; }

        public TypeaheadMasterOption()
        {
            Attributes = new Dictionary<string, object>();
            Highlight(true);
            Hint(true);
        }

        public TypeaheadMasterOption MinLength(int value)
        {
            Attributes["option_minLength"] = value;
            return this;
        }

        public TypeaheadMasterOption Highlight(bool value)
        {
            Attributes["option_highlight"] = value.ToString().ToLower();
            return this;
        }

        public TypeaheadMasterOption Hint(bool value)
        {
            Attributes["option_hint"] = value.ToString().ToLower();
            return this;
        }

        public TypeaheadMasterOption DataSetSource(string value)
        {
            Attributes["dataset_source"] = value;
            return this;
        }

        public TypeaheadMasterOption DataSetSource(IEnumerable<string> source)
        {
            string value = new Bloodhound().Local(source).Script;
            return DataSetSource(value);
        }

        public TypeaheadMasterOption DataSetSource(Bloodhound bloodhound)
        {
            string value = bloodhound.Script;
            return DataSetSource(value);
        }

        public TypeaheadMasterOption DataSetLimit(int value)
        {
            Attributes["dataset_limit"] = value;
            return this;
        }

        public TypeaheadMasterOption DataSetName(string value)
        {
            Attributes["dataset_name"] = string.Format("'{0}'", value);
            return this;
        }

        public TypeaheadMasterOption DataSetDisplay(string value)
        {
            Attributes["dataset_display"] = string.Format("'{0}'", value);
            return this;
        }

        public TypeaheadMasterOption DataSetTemplates(TypeaheadMasterTemplate template)
        {
            Attributes["dataset_templates"] = template.RenderOptions();
            return this;
        }

        public TypeaheadMasterOption AddDataSet(TypeaheadMasterDataSet dataset)
        {
            Attributes.Add("add_dataset_" + Guid.NewGuid().ToString(), dataset.RenderOptions());
            return this;
        }

        public string RenderOptions()
        {
            string result = string.Join(", \n", Attributes.Where(p => p.Key.StartsWith("option_")).Select(p => p.Key.Replace("option_", "") + ": " + p.Value));
            return "{\n" + result + "\n}";
        }

        public string RenderDataSetOptions()
        {
            string result = string.Join(", \n", Attributes.Where(p => p.Key.StartsWith("dataset_")).Select(p => p.Key.Replace("dataset_", "") + ": " + p.Value));
            return string.Join(", \n", "{\n" + result + "\n}");
        }
    }
}