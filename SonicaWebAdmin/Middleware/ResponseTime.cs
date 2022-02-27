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
        // Handle to the next Middleware in the pipeline  
        private readonly RequestDelegate _next;
        public ResponseTime(RequestDelegate next)
        {
            _next = next;
        }
        public Task InvokeAsync(HttpContext context, ILogger<Startup> logger)
        {
            // Start the Timer using Stopwatch  
            var watch = new Stopwatch();
            watch.Start();
            context.Response.OnStarting(() => {
                // Stop the timer information and calculate the time   
                watch.Stop();
                var responseTimeForCompleteRequest = watch.ElapsedMilliseconds;
                // Add the Response time information in the Response headers.   
                context.Response.Headers[RESPONSE_HEADER_RESPONSE_TIME] = responseTimeForCompleteRequest.ToString();
                logger.LogInformation("Время ответа(мс)[" + responseTimeForCompleteRequest.ToString() + "]");

                return Task.CompletedTask;
            });
            // Call the next delegate/middleware in the pipeline   
            return this._next(context);
        }
    }
}
