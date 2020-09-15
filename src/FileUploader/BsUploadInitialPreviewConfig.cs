using DNZ.MvcComponents;
using System;
using System.Collections.Generic;

namespace Microsoft.AspNetCore.Mvc
{
    public class BsUploadInitialPreviewConfig : IOptionBuilder
    {
        public Dictionary<string, object> Attributes { get; set; }

        public BsUploadInitialPreviewConfig()
        {
            Attributes = new Dictionary<string, object>();
        }

        public BsUploadInitialPreviewConfig Add(string caption, string url, int key)
        {
            var jsonClass = new { caption, url, key };
            Attributes.Add(Guid.NewGuid().ToString(), ComponentUtility.ToJsonStringWithoutQuotes(jsonClass));
            return this;
        }
    }
}
