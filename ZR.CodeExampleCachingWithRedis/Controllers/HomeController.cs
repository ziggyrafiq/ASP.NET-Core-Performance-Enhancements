using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Diagnostics;
using System.Text;
using ZR.CodeExampleCachingWithRedis.Models;

namespace ZR.CodeExampleCachingWithRedis.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDistributedCache _distributedCache;
        public HomeController(ILogger<HomeController> logger, IDistributedCache distributedCache)
        {
            _logger = logger;
            _distributedCache = distributedCache;
        }

        public IActionResult Index()
        {
            byte[] cachedBytes = _distributedCache.Get("cachedData");
            if (cachedBytes == null)
            {
                // Data not in cache, fetch and cache it
                string data = GetDataFromSource();
                cachedBytes = Encoding.UTF8.GetBytes(data);
                DistributedCacheEntryOptions cacheOptions = new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
                };
                _distributedCache.Set("cachedData", cachedBytes, cacheOptions);
            }

            string cachedValue = Encoding.UTF8.GetString(cachedBytes);
            return View("Index", cachedValue);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private string GetDataFromSource()
        {
            // Simulating data retrieval
            return "Data from source";
        }

    }
}