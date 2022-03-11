using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NLog;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SonicaWebAdmin.Middleware
{
    public class ResponseTime
    {
        private const string RESPONSE_HEADER_RESPONSE_TIME = "Response-Time-ms";
        private readonly RequestDelegate _next;

        public ResponseTime(RequestDelegate next)
        {
            _next = next;
        }

        public Task InvokeAsync(HttpContext context, ILogger<Startup> logger)
        {
            var watch = new Stopwatch();
            watch.Start();
            context.Response.OnStarting(() => {

                watch.Stop();
                var responseTimeForCompleteRequest = watch.ElapsedMilliseconds;

                context.Response.Headers[RESPONSE_HEADER_RESPONSE_TIME] = responseTimeForCompleteRequest.ToString();
                logger.LogInformation("Время ответа(мс)[" + responseTimeForCompleteRequest.ToString() + "]");

                return Task.CompletedTask;
            });

            return this._next(context);
        }
    }
}
