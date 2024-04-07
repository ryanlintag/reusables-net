using Helpers;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace Api1
{
    public class SecurityHeaderChekerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IEncryption _encryption;
        public SecurityHeaderChekerMiddleware(RequestDelegate next, IEncryption encryption)
        {
            _next = next;
            _encryption = encryption;
        }
        public async Task Invoke(HttpContext context)
        {
            if (!(context.Request.Headers.ContainsKey("x-user-json") && context.Request.Headers.ContainsKey("x-api-key")))
            {
                context.Response.StatusCode = 400;
                await _next.Invoke(context);
            }
            if(string.IsNullOrEmpty(context.Request.Headers["x-user-json"]) || string.IsNullOrEmpty(context.Request.Headers["x-api-key"]))
            {
                context.Response.StatusCode = 400;
                await _next.Invoke(context);
            }
            var userJson = context.Request.Headers["x-user-json"];
            var apiKey = context.Request.Headers["x-api-key"];

            var headers = JsonSerializer.Deserialize<Dictionary<string,string>>(userJson);
            foreach(var header in headers)
            {
                context.Items.Add(header.Key, _encryption.Decrypt(header.Value, apiKey));
            }
            
            await _next.Invoke(context);
        }
    }
}
