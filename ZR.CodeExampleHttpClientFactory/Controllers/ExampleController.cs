using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ZR.CodeExampleHttpClientFactory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        private readonly HttpClient apiClient;

        public ExampleController(IHttpClientFactory httpClientFactory)
        {
            this.apiClient = httpClientFactory.CreateClient("apiClient");
        }

        [HttpGet(Name = "GetExample")]
        public async Task<IActionResult> Get()
        {
            try
            {
                // Use the _apiClient to make HTTP requests to the configured base address
                HttpResponseMessage response = await this.apiClient.GetAsync("/api/someendpoint");

                if (response.IsSuccessStatusCode)
                {
                    // Handle the successful response
                    var content = await response.Content.ReadAsStringAsync();
                    return Ok(content); // Use Ok() to return a 200 OK response
                }
                else
                {
                    // Handle the error response
                    return StatusCode((int)response.StatusCode, "Error"); // Use StatusCode to return the appropriate status code
                }
            }
            catch (HttpRequestException)
            {
                // Handle exceptions related to the HTTP request
                return StatusCode(500, "Internal Server Error");
            }
        }

    }
}
