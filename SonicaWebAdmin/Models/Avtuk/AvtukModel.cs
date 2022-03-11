﻿using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using SonicaWebAdmin.Services;
using SonicaWebAdmin.SonicaAdmin.CoreServerApi.Contract;
using SonicaWebAdmin.SonicaAdmin.CoreServerApi.PDU;
using SonicaWebAdmin.SonicaAdmin.P.Startup;

namespace SonicaWebAdmin.Models.Avtuk
{
    public class AvtukModel
    {
        public AdminSettings Settings { get; }
        private readonly IAvtukFactory _session;
        private readonly IServerApiContract _connection;

        public IPAddress Ip => _session.Ip;

        public AvtukModel(
            IAvtukFactory session, 
            AdminSettings settings,
            IServerApiContract connection)
        {
            Settings = settings;
            _session = session;
            _connection = connection;
        }

        public AvtukPermissions Permissions { get; private set; }
        public AvtukCoreMetrics Metrics { get; private set; } = new AvtukCoreMetrics();
      
        public NetworkSettings NetworkSetting { get; private set; }
        public SystemInfo SystemInfo { get; private set; }
        public ProjectInfo GackInfo { get; private set; }

        public Task<LoginResult> LoginAsync(string login, string password, CancellationToken cancellationToken) =>
            Task.Run(() => _connection.TryLogIn(login, password), cancellationToken);

        public Task<bool> UpdateCurrentMetricsAsync(CancellationToken cancellationToken) =>
            Task.Run(() =>
            {
                cancellationToken.ThrowIfCancellationRequested();
                UpdateCurrentMetrics();
                cancellationToken.ThrowIfCancellationRequested();
                return true;
            }, cancellationToken);
       
        public void UpdateCurrentMetrics()
        {
            try
            {
                //_updateMetrics();
            }
            catch (Exception e)
            {
                //Log.Error("UpdateCurrentMetrics", e, "Received error: ");
                Metrics = new AvtukCoreMetrics();
            }
        }

        public DateTime? DeviceTime { get; private set; }

        
        //#region Basic

        public Task<bool> UpdateNetworkSettingsAsync(CancellationToken cancellationToken) =>
            Task.Run(() =>
            {
                cancellationToken.ThrowIfCancellationRequested();
                if (!Permissions.CanGetNetworkSettings)
                {
                    NetworkSetting = new NetworkSettings
                    {
                        NetworkInterfaceSettings = new NetworkInterfaceSettings[0]
                    };
                    return false;
                }
                return true;
            }, cancellationToken);

        public Task<bool> UpdateSystemInfoAsync(CancellationToken cancellationToken) =>
            Task.Run(() =>
            {
                cancellationToken.ThrowIfCancellationRequested();
                cancellationToken.ThrowIfCancellationRequested();
                cancellationToken.ThrowIfCancellationRequested();
                cancellationToken.ThrowIfCancellationRequested();
                return true;
            }, cancellationToken);


        public Task<AvtukPermissions> UpdatePermissionsAsync(CancellationToken cancellationToken) =>
            Task.Run(() =>
            {
                cancellationToken.ThrowIfCancellationRequested();

                cancellationToken.ThrowIfCancellationRequested();

                cancellationToken.ThrowIfCancellationRequested();

                return Permissions;
            }, cancellationToken);
        //TODO: решить проблему null
       //public Task<FileModel> DownloadGackAsync(CancellationToken cancellationToken) =>
       //     Task.Run(() =>
       //     {
       //         var gack = _connection.Contract.GetGack();
       //         return new FileModel(gack.Name, gack.Content);
       //     }, cancellationToken);

       // public Task<bool> UploadGackAsync(FileModel model, CancellationToken cancellationToken)
       // {
       //     return Task.Run(() =>
       //         _connection.Contract.SetGack(model.Content, model.Name), cancellationToken);
       // }
		
        public Task<bool> TryRestartAsync() => Task.Run(() =>
        {
            if (!Permissions.CanRestartApplication)
                return false;
            try
            {
                _connection.RestartApplicationAndThrow();
                return false;
            }
            catch (Exception e)
            {
                //Log.Error("RestartAsync", e, "Received error: ");
                return true;
            }
        });

   //     public async Task<FileModel> DownloadLogsArchiveAsync(CancellationToken token)
   //     {
   //         var logs = await Task.Run(() =>
   //             _connection.Contract.GetLogArchive(), token);
   //         return new FileModel(logs.Name + "." + logs.Extension, logs.Content);
   //     }

   //     public async Task<bool> DropLogs(CancellationToken token)
   //     {
   //         return await Task.Run(()=> _connection.Contract.DropLogs(), token);
   //     }
        
   //     public async Task<DumpInformationPdu> RunTcpDump(DumpArgumentsPdu dumpArguments, CancellationToken token)
   //     {
   //         return await Task.Run(()=> _connection.Contract.RunTcpDump(dumpArguments), token);
   //     }
        
   //     public async Task<DumpInformationPdu> StopTcpDump(CancellationToken token)
   //     {
   //         return await Task.Run(()=> _connection.Contract.StopTcpDump(), token);
   //     }

   //     public async Task<DumpInformationPdu> GetTcpDumpStatus(CancellationToken token)
   //     {
   //         return await Task.Run(()=> _connection.Contract.GetTcpDumpStatus(), token);
   //     }
        
   //     #endregion

   //     #region Parametrization

   //     public ParametersContainer GetParameters()
   //     {
   //         try
   //         {
   //             return _connection.Contract.GetParameters();
   //         }
   //         catch (Exception e)
   //         {
   //             return ParametersContainer.FailRead(e);
   //         }
   //     }
        
   //     public SetParametersResult SetParameters(ParametersContainer parameters)
   //     {
   //         try
   //         {
   //             return _connection.Contract.SetParameters(parameters);
   //         }
   //         catch (Exception e)
   //         {
   //             return SetParametersResult.Fail(e);
   //         }
   //     }
        
   //     #endregion
        
   //     #region Software update
		
	  //  public Task<UpdatePermission> TryGetPermissionToUpdate(SoftwareVersion version, SoftwareFileInfo softwareFileInfo)
			//=> Task.Run(() => _connection.Contract.TryGetPermissionToUpdate(version, softwareFileInfo));
	    
	  //  public Task<SavePartResult> TrySendPartOfUpdate(PartOfUpdate partOfUpdate)
		 //   => Task.Run(() => _connection.Contract.TrySendPartOfUpdate(partOfUpdate));
		
	  //  public Task<VerifyResult> TryVerifySoftwarePackage()
		 //   => Task.Run(() => _connection.Contract.TryVerifySoftwarePackage());

	  //  public Task<RollBackResult> TryRollBackUpdate()
		 //   => Task.Run(() => _connection.Contract.TryRollBackUpdate());
		
   //     #endregion

   //     #region File sources

   //     public Task<CoreFilesListDto> GetAllFileSourceInfos() =>
   //         Task.Run(() => _connection.Contract.GetAllFileSourceInfos());

   //     public Task<CoreFilesListDto> GetAllFileSourceInfos(string[] fileExtensions)
   //         => Task.Run(() => _connection.Contract.GetAllFileSourceInfos(CoreFilesFilterDto.Create(fileExtensions)));
        

   //     public Task<bool> ClearFile(CoreFileInfoDto coreFile)
   //         => Task.Run(() => _connection.Contract.ClearFile(coreFile.SourcePath, coreFile.Name));
        
   //     public Task<CoreFilePortionDto> InitializeFileDownload(CoreFileInfoDto coreFile) => 
   //         Task.Run(() => _connection.Contract.InitializeDownload(coreFile.SourcePath, coreFile.Name));
        
   //     public Task<CoreFilePortionDto> DownloadNextPortion(int downloadId) => 
   //         Task.Run(() => _connection.Contract.GetNextPortion(downloadId));
        
   //     public Task CancelDownload(int downloadId) => 
   //         Task.Run(() => _connection.Contract.CancelFileOperation(downloadId));

   //     public Task<UploadPortionResultDto> InitializeFileUpload(CoreFilePortionDto filePortion) => 
   //         Task.Run(() => _connection.Contract.InitializeUpload(filePortion));
        
   //     public Task<UploadPortionResultDto> UploadNextPortion(CoreFilePortionDto filePortion) => 
   //         Task.Run(() => _connection.Contract.SetNextPortion(filePortion));

   //     #endregion

   //     #region Linux System Time

   //     public Task<TimeSettingResult> GetLinuxSystemTime(TimeSetting setting, CancellationToken token) =>
   //         Task.Run(() => _connection.Contract.GetLinuxSystemTime(setting), token);

   //     public Task<TimeSettingResult> SetLinuxSystemTime(TimeSetting setting, CancellationToken token) =>
   //         Task.Run(() => _connection.Contract.SetLinuxSystemTime(setting), token);

   //     #endregion

   //     #region OEM Key

   //     public RequestKeyPdu GetRequestKey()
   //     {
   //         return _connection.Contract.GetRequestKey();
   //     }

   //     public ResponseKeyResultPdu SetResponseKey(string responseKey)
   //     {
   //         return _connection.Contract.SetResponseKey(new ResponseKeyPdu { Base32Key = responseKey});
   //     }

   //     public LicenseInfoPdu GetLicenseInformation()
   //     {
   //         return _connection.Contract.GetLicenseInformation();
   //     }
        
   //     #endregion

   //     public SetResultRunModePdu SetCoreRunMode(RunModePdu runMode)
   //     {
   //         return _connection.Contract.SetCoreRunMode(new SetWorkModePdu {RunMode = runMode});
   //     }

   //     public RunModePdu GetCoreRunModeOrThrow()
   //     {
   //         var result = _connection.Contract.GetCoreRunMode();
   //         if(!string.IsNullOrEmpty(result.Error))
   //             throw new InvalidOperationException($"Remote error: {result.Error}");
   //         return result.CoreRunMode;
   //     }
        
   //     #region Private

   //     private void Channel_OnDisconnect(object sender, ErrorMessage cause)
   //         => _connectionIsLostCompletionSource.SetResult(cause);

   //     private void _updateMetrics()
   //     {
   //         var sw = Stopwatch.StartNew();
   //         var metrics = _connection.Contract.GetMetrics(DeviceMetricsType.All);
   //         sw.Stop();

   //         Metrics = new AvtukCoreMetrics
   //         {
   //             RamUsageBytes            = metrics?.ProcessRamUsageInBytes ?? 0,
   //             CpuUsagePercent          = metrics?.ProcessCpuUsageInPercent ?? 0,
   //             CpuTemperature           = metrics?.CPUInfo?.Temperature ?? -1,
   //             FailedOperationsCount    = metrics?.CoreMetrics?.FailedOperations ?? 0,
   //             IdleTime                 = metrics?.CoreMetrics?.IdleTime ?? TimeSpan.Zero,
   //             ProcessedOperationsCount = metrics?.CoreMetrics?.ProcessedOperationsCount ?? 0,
   //             ProcessingTime           = metrics?.CoreMetrics?.ProcessingTime ?? TimeSpan.Zero,
   //             QueueLength              = metrics?.CoreMetrics?.QueueLength ?? 0,
   //             SlowestOperationTime     = metrics?.CoreMetrics?.SlowestOperationTime ?? TimeSpan.Zero,
   //             SlowestOperationName     = metrics?.CoreMetrics?.SlowestOperationName,
   //             MeasurementPeriod        = metrics?.CoreMetrics?.MeasurementPeriod ?? TimeSpan.Zero,
   //             ResponseTime             = sw.Elapsed,
   //             IsNtpEnabled             = metrics.CoreMetrics.IsNtpEnabled
   //         };
   //         DeviceTime = metrics?.DeviceTime;
   //     }

   //     #endregion


        
    }
}