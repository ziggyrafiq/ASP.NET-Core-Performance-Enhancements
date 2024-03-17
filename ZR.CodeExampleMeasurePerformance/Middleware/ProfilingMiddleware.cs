using System.Diagnostics;

namespace ZR.CodeExampleMeasurePerformance.Middleware
{
    public class ProfilingMiddleware
    {
        private readonly RequestDelegate _next;

        public ProfilingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            await _next(context);

            stopwatch.Stop();
            if (stopwatch.ElapsedMilliseconds > 100) // Example threshold for a "hot" code path
            {
                // Log or report the slow code path
            }
        }

    }
}