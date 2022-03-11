using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SonicaWebAdmin.Models.Avtuk;
using SonicaWebAdmin.Services;
using SonicaWebAdmin.SonicaAdmin;
using SonicaWebAdmin.SonicaAdmin.Control.Operations;
using SonicaWebAdmin.SonicaAdmin.CoreServerApi.Contract;
using SonicaWebAdmin.SonicaAdmin.P;
using SonicaWebAdmin.SonicaAdmin.P.Startup;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SonicaWebAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        private readonly ILogger<ValuesController> _logger;
        private IAvtukFactory _avtukFactory;
        private bool _manualDisconnection;
        private string _loadingStatus; // заменить на лог
        private string _manualDisconnectionMessage;
        private AvtukModel _avtukModel;
        private ControlPanelPageOperationExecutor _executor;
        private readonly CancellationTokenSource _cancellationTokenSource;

        public ValuesController(ILogger<ValuesController> logger, IAvtukFactory avtukFactory)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into ValuesController");
            _avtukFactory = avtukFactory;
            _cancellationTokenSource = new CancellationTokenSource();
            _executor = new ControlPanelPageOperationExecutor();
        }

        private async void Connect(AdminSettings settings)
        {
            IServerApiContract connection = null;
            try
            {
                _loadingStatus = $"Подключение к {_avtukFactory.Ip}";
                connection = new ServerApiContract(null,null,null);
                //connection = await CoreServerApi.ConnectAsync(
                //        endPoint: new IPEndPoint(_avtukFactory.Ip, settings.Port),
                //        timeOutInMs: settings.MaxAwaitTimeOutInMs)
                //    .WithAsyncCancelation(_cancellationTokenSource.Token);

                _avtukModel = new AvtukModel(_avtukFactory, settings, connection);
                _loadingStatus = "Аутентификация";

                var loginResult = await _avtukModel.LoginAsync("admin", "admin", _cancellationTokenSource.Token)
                    .WithAsyncCancelation(_cancellationTokenSource.Token);

                if (!loginResult.Succes)
                {
                    //connection.Dispose();
                    //OpenPage(new StartupPageViewModel("Не удалось аутентифицироваться"));
                    return;
                }

                _loadingStatus = "Получение разрешений";
                var permissions = await _avtukModel.UpdatePermissionsAsync(_cancellationTokenSource.Token)
                    .WithAsyncCancelation(_cancellationTokenSource.Token);

                _loadingStatus = "Обновление информации";
                await _avtukModel.UpdateCurrentMetricsAsync(_cancellationTokenSource.Token)
                    .WithAsyncCancelation(_cancellationTokenSource.Token);

                await _avtukModel.UpdateSystemInfoAsync(_cancellationTokenSource.Token)
                    .WithAsyncCancelation(_cancellationTokenSource.Token);

                if (!permissions.IsDeviceActivated)
                {
                    //OpenPage(new LicenseActivationViewModel(avtukModel));
                    return;
                }

                
            }
            catch (Exception e)
            {
                //SLog.Log.Warn("ConnectPage", e, "Connection error: ");https://localhost:5001/api/Values/restart?ip=172.16.29.222
                //if (connection?.Channel != null)
                //{
                //    try
                //    {
                //        //connection.Dispose();
                //    }
                //    catch (Exception ex)
                //    {
                //        //SLog.Log.Warn("ConnectPage", ex, "Connection dispose error: ");
                //    }
                //}

                //if (_cancellationTokenSource.Token.IsCancellationRequested)
                //{
                //    //OpenPage(new StartupPageViewModel());
                //}
                //else
                //{
                //    //OpenPage(new StartupPageViewModel(
                //    //    $"Невозможно подсоединиться к {_session.Ip}. Ошибка: " + e.GetBaseException().Message));
                //}
            }
        }

        [Route("restart")]
        public async Task<string> RestartAsync(string ip)
        {
            _avtukFactory.SetIpAddress(ip);
            _logger.LogInformation("restart");

            var settingsRepository = new SettingsRepository();
            settingsRepository.SetLastIpAddress(_avtukFactory.Ip);
            Connect(settingsRepository.GetSettings());


            _manualDisconnection = true;
            _manualDisconnectionMessage = "Устройство перезагружается";

            var result = await _executor.ExecuteOpAsync(new RestartOperationViewModel(_avtukModel));
            if (!(result is OperationResult.SuccessfullyResult))
            {
                _manualDisconnection = false;
                _manualDisconnectionMessage = null;
            }

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
            System.Threading.Thread.Sleep(10000);
            var name = $"Sonica.Device.Logs.{DateTime.Now:yyyyMMdd.hh.mm.ss}.zip";
            byte[] fileBytes = { 0, 0, 0, 0, 0 };

            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, name);
        }
    }
}
