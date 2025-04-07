using System.Text;

namespace UserManagementAPI.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Log the request
            await LogRequest(context);

            // Call the next middleware
            await _next(context);

            // Log the response
            LogResponse(context);
        }

        private async Task LogRequest(HttpContext context)
        {
            var request = context.Request;
            var requestBody = string.Empty;

            if (request.ContentLength > 0)
            {
                request.EnableBuffering();
                using var reader = new StreamReader(request.Body, Encoding.UTF8, true, 1024, true);
                requestBody = await reader.ReadToEndAsync();
                request.Body.Position = 0;
            }

            _logger.LogInformation(
                "HTTP {Method} {Path} received from {IP} with body: {Body}",
                request.Method,
                request.Path,
                context.Connection.RemoteIpAddress,
                requestBody);
        }

        private void LogResponse(HttpContext context)
        {
            _logger.LogInformation(
                "HTTP {StatusCode} returned for {Method} {Path}",
                context.Response.StatusCode,
                context.Request.Method,
                context.Request.Path);
        }
    }

    // Extension method for middleware registration
    public static class RequestLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLoggingMiddleware>();
        }
    }
}