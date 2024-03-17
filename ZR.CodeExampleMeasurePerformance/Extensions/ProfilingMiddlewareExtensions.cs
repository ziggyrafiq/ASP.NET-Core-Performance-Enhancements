using ZR.CodeExampleMeasurePerformance.Middleware;

namespace ZR.CodeExampleMeasurePerformance.Extensions
{
    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ProfilingMiddlewareExtensions
    {
        public static IApplicationBuilder UseProfilingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ProfilingMiddleware>();
        }
    }
}

 
