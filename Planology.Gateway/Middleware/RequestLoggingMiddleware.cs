using System.Diagnostics;
using System.Security.Claims;

namespace Planology.Gateway.Middleware
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

        public async Task Invoke(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            var request = context.Request;
            var ip = context.Connection.RemoteIpAddress?.ToString();
            var userId = context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "Anonymous";
            var userAgent = request.Headers.UserAgent.ToString();
            var method = request.Method;
            var path = request.Path + request.QueryString;

            try
            {
                await _next(context);
                stopwatch.Stop();

                var statusCode = context.Response?.StatusCode;

                _logger.LogInformation(
                    "📥 {Method} {Path} from {IP} ({UserId}) - {StatusCode} in {Elapsed} ms - UA: {UserAgent}",
                    method, path, ip, userId, statusCode, stopwatch.ElapsedMilliseconds, userAgent
                );
            }
            catch (Exception ex)
            {
                stopwatch.Stop();

                _logger.LogError(ex,
                    "❌ {Method} {Path} from {IP} ({UserId}) FAILED in {Elapsed} ms - UA: {UserAgent}",
                    method, path, ip, userId, stopwatch.ElapsedMilliseconds, userAgent
                );

                throw;
            }
        }
    }

}
