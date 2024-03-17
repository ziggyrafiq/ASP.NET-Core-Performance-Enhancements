using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace ZR.CodeExampleHandleUnknownRequest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        private readonly ILogger<ExampleController> logger;
        public ExampleController(ILogger<ExampleController> logger)
        {
            this.logger = logger;
        }

        [HttpPost("handle")]
        public async Task<IActionResult> HandleUnknownRequestBodyLengthAsync()
        {
            try
            {
                // Check if the content length is known and greater than zero
                if (HttpContext.Request.ContentLength == null || HttpContext.Request.ContentLength.Value <= 0)
                {
                    // Handle the scenario where content length is not known or invalid
                    return BadRequest("Invalid or missing request content length");
                }

                // Read the request body
                using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    var requestBody = await reader.ReadToEndAsync();

                    // Process the request body
                    this.logger.LogInformation($"Received request body: {requestBody}");

                    // Add your logic here to process the request body

                    return Ok("Request body processed successfully");
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "An error occurred while handling the request.");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
