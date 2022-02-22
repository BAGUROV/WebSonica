using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SonicaWebAdmin.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("error")]
        public ErrorViewModel Error()
        {
            return new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
        }
    }
}
