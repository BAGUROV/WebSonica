using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace SonicaWebAdmin.Controllers
{
    [Route("api2/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into HomeController");
        }

        [Route("index")]
        public string Index()
        {
            return "7";
        }

        [Route("privacy")]
        public string Privacy()
        {
            return "8";
        }

    }
}
