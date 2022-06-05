using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Core.ServerApi.Contract;
using SonicaWebAdmin.Models;

namespace SonicaWebAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        private readonly ILogger<ValuesController> _logger;
        private IServerApiContract _contract;
        private readonly ConnectingAdmin _admin;

        public ValuesController(ILogger<ValuesController> logger, IServerApiContract contract)
        {
            _logger = logger;
            _contract = contract;
            _admin = new ConnectingAdmin();
            _logger.LogDebug(1, "NLog injected into ValuesController");
        }

        [Route("restart")]
        public string Restart()
        {
            _logger.LogInformation("restart");
            try
            {
                _admin.ReConnect(ref _contract);
                _contract.RestartApplicationAndForget();
                return "Сервер перезагружен";
            }
            catch (Exception e)
            {
                return e.Message;
            }
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
            var content = _contract.GetLogArchive();
            return File(content.Content, System.Net.Mime.MediaTypeNames.Application.Zip, name);
        }
    }
}
