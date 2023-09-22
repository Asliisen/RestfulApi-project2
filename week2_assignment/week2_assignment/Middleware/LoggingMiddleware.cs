using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;


namespace week2_assignment.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            // Logging when the request starts
            _logger.LogInformation($"Action has started: {context.Request.Path}");

            // Request is being processed
            await _next(context);

            // Logging when the response is processed
            _logger.LogInformation($"Action completed: {context.Request.Path}, Success Status: {context.Response.StatusCode}");
        }
    }
}
