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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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

        public IActionResult Restart()
        {
            return View();
        }

        public IActionResult Upload()
        {
            return View();
        }

        public IActionResult DownloadAndEdit()
        {
            return View();
        }

        public IActionResult Download()
        {
            return View();
        }

        public IActionResult DownloadAndDebug()
        {
            return View();
        }

        public IActionResult SoftwareUpdate()
        {
            return View();
        }

        public IActionResult GetLog()
        {
            var name = $"Sonica.Device.Logs.{DateTime.Now:yyyyMMdd.hh.mm.ss}.zip";
            byte[] fileBytes = { 0, 0, 0, 0, 0 };

            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, name);
        }
    }
}
