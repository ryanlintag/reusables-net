namespace Api1
{
    public class SecurityHeaderChekerMiddleware
    {
        private readonly RequestDelegate _next;
        public SecurityHeaderChekerMiddleware(RequestDelegate next) => _next = next;
        public async Task Invoke(HttpContext context)
        {
            if (!(context.Request.Headers.ContainsKey("x-user-json") && context.Request.Headers.ContainsKey("x-api-key")))
                context.Response.StatusCode = 400;
            else
                await _next.Invoke(context);
        }
    }
}
