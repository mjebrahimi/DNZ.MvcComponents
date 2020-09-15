using System.Collections.Generic;

namespace Microsoft.AspNetCore.Mvc
{
    public class BsUploadAllowedFileType : IOptionBuilder
    {
        public Dictionary<string, object> Attributes { get; set; }

        public BsUploadAllowedFileType()
        {
            Attributes = new Dictionary<string, object>();
        }

        public BsUploadAllowedFileType XImage()
        {
            Attributes["'image'"] = "";
            return this;
        }

        public BsUploadAllowedFileType XHtml()
        {
            Attributes["'html'"] = "";
            return this;
        }

        public BsUploadAllowedFileType XText()
        {
            Attributes["'text'"] = "";
            return this;
        }

        public BsUploadAllowedFileType XVideo()
        {
            Attributes["'video'"] = "";
            return this;
        }

        public BsUploadAllowedFileType XAudio()
        {
            Attributes["'audio'"] = "";
            return this;
        }

        public BsUploadAllowedFileType XFlash()
        {
            Attributes["'flash'"] = "";
            return this;
        }

        public BsUploadAllowedFileType XObject()
        {
            Attributes["'object'"] = "";
            return this;
        }
    }
}