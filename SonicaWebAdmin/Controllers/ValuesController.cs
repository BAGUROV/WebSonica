using Auth;
using Auth.Entities;
using Auth.Interfaces;
using Core.ServerApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Sonica.Admin.Pages.ConnectionPage;
using TNT.Core.Tcp;
using TNT.Core.Api;
using System.Net;
using Sonica.Admin;
using System.Threading;
using System.Threading.Tasks;
using SonicaWebAdmin.Services;

namespace SonicaWebAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        private readonly ILogger<ValuesController> _logger;
        private readonly IContract _contract;

        public ValuesController(ILogger<ValuesController> logger, IContract contract)
        {
            _logger = logger;
            _contract = contract;

            _logger.LogDebug(1, "NLog injected into ValuesController");
        }

        [Route("restart")]
        public async Task<bool> Restart(string ip)
        {
            
            _logger.LogInformation("restart");
            return await _contract.AvtukModel.TryRestartAsync();
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
            System.Threading.Thread.Sleep(10000);
            var name = $"Sonica.Device.Logs.{DateTime.Now:yyyyMMdd.hh.mm.ss}.zip";
            byte[] fileBytes = { 0, 0, 0, 0, 0 };

            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, name);
        }
    }
}
