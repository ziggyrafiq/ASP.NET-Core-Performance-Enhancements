using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZR.CodeExampleEmbarkingAsynchronousOdyssey.Helpers;

namespace ZR.CodeExampleEmbarkingAsynchronousOdyssey.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsyncApiExample : ControllerBase
    {
        private readonly AsyncExample _asyncExample;

        public AsyncApiExample()
        {
            _asyncExample = new AsyncExample();
        }

        public async Task<IActionResult> ProcessAsync()
        {
            var data = await _asyncExample.FetchDataAsync();
            // Process data asynchronously

            // Return data as JSON
            return new JsonResult(data);
        }
    }
}
