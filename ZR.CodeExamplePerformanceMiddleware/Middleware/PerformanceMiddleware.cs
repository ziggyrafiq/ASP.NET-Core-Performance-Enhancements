using System.Diagnostics;

namespace ZR.CodeExamplePerformanceMiddleware.Middleware
{
    public class PerformanceMiddleware
    {
        private readonly RequestDelegate _next;

        public PerformanceMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Start the stopwatch to measure the execution time
            var stopwatch = Stopwatch.StartNew();

            // Call the next middleware component in the pipeline
            await _next(context);

            // Stop the stopwatch
            stopwatch.Stop();

            // Log the execution time (you can use a logging framework like Serilog)
            var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"Middleware execution time: {elapsedMilliseconds} ms");
        }
    }
}
