using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SonicaWebAdmin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SonicaWebAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        private readonly ILogger<ValuesController> _logger;
        private IAvtukFactory _avtukFactory;

        public ValuesController(ILogger<ValuesController> logger, IAvtukFactory avtukFactory)
        {
            _logger = logger;
            _avtukFactory = avtukFactory;
        }

        [Route("restart")]
        public string Restart(string ip)
        {
            _avtukFactory.SetIpAddress(ip);
            _logger.LogInformation("Hello world");
            return "1";
        }

        [Route("upload")]
        public string Upload()
        {
            return "2";
        }

        [Route("downloadandedit")]
        public string DownloadAndEdit()
        {
            return "3";
        }

        [Route("download")]
        public string Download()
        {
            return "4";
        }

        [Route("downloadanddebug")]
        public string DownloadAndDebug()
        {
            return "5";
        }

        [Route("softwareupdate")]
        public string SoftwareUpdate()
        {
            return "6";
        }

        [Route("getlog")]
        public IActionResult GetLog()
        {
            var name = $"Sonica.Device.Logs.{DateTime.Now:yyyyMMdd.hh.mm.ss}.zip";
            byte[] fileBytes = { 0, 0, 0, 0, 0 };

            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, name);
        }
    }
}
