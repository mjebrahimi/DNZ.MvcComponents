using DNZ.MvcComponents;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.AspNetCore.Mvc
{
    public class TypeaheadOption : IOptionBuilder
    {
        public Dictionary<string, object> Attributes { get; set; }

        public TypeaheadOption()
        {
            Attributes = new Dictionary<string, object>();
        }

        public TypeaheadOption Ajax(string value)
        {
            Attributes["ajax"] = string.Format("'{0}'", value);
            return this;
        }

        public TypeaheadOption Ajax(TypeaheadAjax value)
        {
            Attributes["ajax"] = value.RenderOptions();
            return this;
        }

        public TypeaheadOption DisplayField(string value)
        {
            SetDictionaryByEnumerable();
            Attributes["displayField"] = string.Format("'{0}'", value);
            return this;
        }

        public TypeaheadOption ValueField(string value)
        {
            SetDictionaryByEnumerable();
            Attributes["valueField"] = string.Format("'{0}'", value);
            return this;
        }
        //public TypeaheadOption Display(string value)
        //{
        //    Attributes["display"] = string.Format("'{0}'", value);
        //    return this;
        //}
        //public TypeaheadOption Val(string value)
        //{
        //    Attributes["val"] = string.Format("'{0}'", value);
        //    return this;
        //}
        public TypeaheadOption Item(string value)
        {
            Attributes["item"] = string.Format("'{0}'", value);
            return this;
        }

        public TypeaheadOption Menu(string value)
        {
            Attributes["menu"] = string.Format("'{0}'", value);
            return this;
        }

        /// <summary>
        /// If this option is set to true,the items value will be 100 and the HTML render menu will be set to:
        /// '<ul class="typeahead dropdown-menu" style="max-height:220px;overflow:auto;" ></ul>'
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public TypeaheadOption ScrollBar(bool value)
        {
            Attributes["scrollBar"] = value.ToString().ToLower();
            return this;
        }

        public TypeaheadOption AlignWidth(bool value)
        {
            Attributes["alignWidth"] = value.ToString().ToLower();
            return this;
        }

        public TypeaheadOption OnSelect(string value)
        {
            Attributes["onSelect"] = value;
            return this;
        }

        public TypeaheadOption Source(string value)
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

        public TypeaheadOption Source(IEnumerable<string> source)
        {
            Dictionary = source.ToDictionary(p => p, p => p);
            var value = ComponentUtility.ToJsonString(source);
            return Source(value);
        }

        public TypeaheadOption Source(IEnumerable source)
        {
            _source = source;
            SetDictionaryByEnumerable();
            var value = ComponentUtility.ToJsonString(source);
            return Source(value);
        }

        public TypeaheadOption Source(Dictionary<int, string> source)
        {
            Dictionary = source.ToDictionary(p => p.Key.ToString(), p => p.Value);
            var value = ComponentUtility.ToJsonString(source.Select(p => new { id = p.Key, name = p.Value }));
            return Source(value);
        }

        public Dictionary<string, string> Dictionary { get; set; }
        private IEnumerable _source;

        private void SetDictionaryByEnumerable()
        {
            if (Attributes.ContainsKey("valueField") && Attributes["valueField"] != null && Attributes.ContainsKey("displayField") && Attributes["displayField"] != null && _source != null)
            {
                var valueField = Attributes["valueField"].ToString().Trim('\'');
                var displayField = Attributes["displayField"].ToString().Trim('\'');
                var dic = new Dictionary<string, string>();
                foreach (var item in _source)
                {
                    var keyDic = ComponentUtility.GetPropValue<string>(item, valueField);
                    var valueDic = ComponentUtility.GetPropValue<string>(item, displayField);
                    dic.Add(keyDic, valueDic);
                }
                Dictionary = dic;
            }
        }
    }
}