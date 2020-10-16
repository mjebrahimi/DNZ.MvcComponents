using DNZ.MvcComponents;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.AspNetCore.Mvc
{
    public class TagAutocompleteOption : IOptionBuilder
    {
        public Dictionary<string, object> Attributes { get; set; }

        public TagAutocompleteOption()
        {
            Attributes = new Dictionary<string, object>();
        }

        public TagAutocompleteOption After(string value)
        {
            Attributes["after"] = value;
            return this;
        }

        public TagAutocompleteOption Character(params char[] values)
        {
            Attributes["character"] = string.Format("'{0}'", string.Concat(values.Select(p => p.ToString())));
            return this;
        }

        public TagAutocompleteOption Source(string value)
        {
            //source: function(query, process) {
            //    $.ajax({
            //    url: 'data.php',
            //        type: 'POST',
            //        dataType: 'JSON',
            //        data: 'query=' + query,
            //        success: function(data) {
            //            console.log(data);
            //            process(data);
            //        }
            //    });
            //}
            Attributes["source"] = value;
            return this;
        }

        public TagAutocompleteOption Source(IEnumerable<string> source)
        {
            var value = ComponentUtility.ToJsonString(source);
            return Source(value);
        }
    }
}