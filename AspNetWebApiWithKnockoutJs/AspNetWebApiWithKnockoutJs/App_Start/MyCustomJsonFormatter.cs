using System;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace AspNetWebApiWithKnockoutJs
{
    internal class MyCustomJsonFormatter : JsonMediaTypeFormatter
    {
        public MyCustomJsonFormatter()
        {
            this.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
        }

        public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
        {
            base.SetDefaultContentHeaders(type, headers, mediaType);

            headers.ContentType = new MediaTypeHeaderValue("application/json");
        }
    }
}