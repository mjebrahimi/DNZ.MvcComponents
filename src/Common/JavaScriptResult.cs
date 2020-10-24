namespace Microsoft.AspNetCore.Mvc
{
    public class JavaScriptResult : ContentResult
    {
        public JavaScriptResult()
        {
            ContentType = "text/javascript";
        }

        public string Script
        {
            get => Content;
            set => Content = value;
        }
    }
}
