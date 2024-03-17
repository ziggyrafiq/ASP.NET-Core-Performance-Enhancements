using Microsoft.AspNetCore.Mvc;

namespace ZR.CodeExampleAvoidAccessingHttpContext.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExampleController : ControllerBase
    {
        private readonly ILogger<ExampleController> logger;

        public ExampleController(ILogger<ExampleController> logger)
        {
            this.logger = logger;
        }

        [HttpGet("safe")]
        public async Task<IActionResult> SafeAccessAsync()
        {
            try
            {
                // Access HttpContext within the asynchronous action method
                var context = HttpContext;

                // Perform your operations using HttpContext
                var userId = context.User.Identity.Name;

                // Simulate asynchronous work (e.g., database access)
                await Task.Delay(TimeSpan.FromSeconds(2));

                // Access HttpContext again
                var requestId = context.TraceIdentifier;

                // Return a response
                return Ok(new
                {
                    UserId = userId,
                    RequestId = requestId
                });
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "An error occurred.");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
