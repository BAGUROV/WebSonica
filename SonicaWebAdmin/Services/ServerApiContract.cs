using Core.ServerApi.Contract;
using Core.ServerApi;
using Sonica.Admin.Models;
using Sonica.Admin.Pages.StartupPage;
using System.Net;
using System.Threading;
using TNT.Core.Api;
using TNT.Core.Tcp;
using Sonica.Admin;
using System;

namespace SonicaWebAdmin.Services
{
    public interface IContract
    {
        public AvtukModel AvtukModel { get; set; }
    }
    public class ServerApiContract : IContract
    {
        private readonly SettingsRepository _settingsRepository = new SettingsRepository();
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        public AvtukModel AvtukModel { get; set; }
        public ServerApiContract()
        {
            Connect();
        }

        public void Connect()
        {
            try
            {
                var _avtukFactory = new AvtukFactory(TestClass.SetIpAddress("172.16.29.222"));
                _settingsRepository.SetLastIpAddress(_avtukFactory.Ip);

                IConnection<IServerApiContract, TcpChannel> connection = null;
                connection = CoreServerApi.Connect(
                            endPoint: new IPEndPoint(_avtukFactory.Ip, 17177),
                            timeOutInMs: 90000);

                AvtukModel = new AvtukModel(_avtukFactory, _settingsRepository.GetSettings(), connection);
                var permissions = AvtukModel.UpdatePermissionsAsync(_cancellationTokenSource.Token)
                        .WithAsyncCancelation(_cancellationTokenSource.Token);
                 AvtukModel.UpdateCurrentMetricsAsync(_cancellationTokenSource.Token)
                        .WithAsyncCancelation(_cancellationTokenSource.Token);

                 AvtukModel.UpdateSystemInfoAsync(_cancellationTokenSource.Token)
                    .WithAsyncCancelation(_cancellationTokenSource.Token);
            }
            catch (Exception e)
            { 
                
            }
        }
    }
}
//var _avtukFactory = new AvtukFactory(TestClass.SetIpAddress(ip));
//_settingsRepository.SetLastIpAddress(_avtukFactory.Ip);

//IConnection<IServerApiContract, TcpChannel> connection = null;
//connection = await CoreServerApi.ConnectAsync(
//            endPoint: new IPEndPoint(_avtukFactory.Ip, 17177),
//            timeOutInMs: 90000)
//        .WithAsyncCancelation(_cancellationTokenSource.Token);

//var avtukModel = new AvtukModel(_avtukFactory, _settingsRepository.GetSettings(), connection);
//var permissions = await avtukModel.UpdatePermissionsAsync(_cancellationTokenSource.Token)
//        .WithAsyncCancelation(_cancellationTokenSource.Token);
//await avtukModel.UpdateCurrentMetricsAsync(_cancellationTokenSource.Token)
//        .WithAsyncCancelation(_cancellationTokenSource.Token);

//await avtukModel.UpdateSystemInfoAsync(_cancellationTokenSource.Token)
//    .WithAsyncCancelation(_cancellationTokenSource.Token);


//private readonly SettingsRepository _settingsRepository = new SettingsRepository();
//private readonly CancellationTokenSource _cancellationTokenSource;
//private readonly AvtukModel _avtukModel;