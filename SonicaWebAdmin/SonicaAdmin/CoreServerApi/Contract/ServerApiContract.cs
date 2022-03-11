using Auth.Exceptions;
using SonicaWebAdmin.SonicaAdmin.CoreServerApi.PDU;
using SonicaWebAdmin.SonicaAdmin.CoreServerApi.Scope;
using SonicaWebAdmin.SonicaAdmin.Entities;
using SonicaWebAdmin.SonicaAdmin.Interfaces;
using System;
using System.IO;
using System.Text;

namespace SonicaWebAdmin.SonicaAdmin.CoreServerApi.Contract
{
    public sealed class ServerApiContract : IServerApiContract, IReleasable
    {
        private readonly IUserService _userService;
        private readonly Restrictions _restrictions;
        private readonly IServerApiScope _serverApiScope;

        public ServerApiContract(IUserService userService, IServerApiScope serverApi, Restrictions restrictions)
        {
            _userService = userService;
            _serverApiScope = serverApi;
            _restrictions = restrictions;

            //_serverApiScope.ActiveProjectApi.ProjectStateChanged += OnProjectStateChanged;
        }

        //#region Basics

        //      public Action<int> ProjectStateChanged { get; set; }

        //      public Permissions GetPermissions()
        //      {
        //          if (_serverApiScope.License?.ValidateLicense()?.IsLicenseAccepted == true)
        //          {
        //             return new Permissions
        //              {
        //                  AllowSetGack           = IsAllowed(_restrictions.RoleForSaveGack),
        //                  AllowGetGack           = IsAllowed(_restrictions.RoleForDownloadProject),
        //                  GetNetworkSettings     = IsAllowed(_restrictions.RoleForGetConnectionSettings),
        //                  SetNetworkSettings     = IsAllowed(_restrictions.RoleForSetNetworkSettings),
        //                  DownloadProjectInfo    = IsAllowed(_restrictions.RoleForDownloadProjectInfo),
        //                  RestartApplication     = IsAllowed(_restrictions.RoleForRestartApplication) && _serverApiScope.CanBeRestarted,
        //                  SoftwareUpdate         = IsAllowed(_restrictions.RoleForSoftwareUpdate) && _serverApiScope.SoftwareUpdateApiOrNull != null,
        //                  ChangeServerSystemTime = _serverApiScope.LinuxSystemTimeApiOrNull != null,
        //                  DeviceActivated        = true
        //              };
        //          }
        //          else
        //          {
        //              return Permissions.DeviceNotActivated();
        //          }
        //      }

        //      public DeviceMetrics GetMetrics(DeviceMetricsType metricsType)
        //          => _serverApiScope.Metrics.GetMetrics(metricsType);

        //      public bool DropLogs()
        //          => _serverApiScope.LoggingApi.DropLogs();

        //      public FilePdu GetLogArchive() 
        //          => _serverApiScope.LoggingApi.GetLogArchive();

        //      public DumpInformationPdu RunTcpDump(DumpArgumentsPdu arguments)
        //          => _serverApiScope.LoggingApi.RunTcpDump(arguments);

        //      public DumpInformationPdu StopTcpDump()
        //          => _serverApiScope.LoggingApi.StopTcpDump();

        //      public DumpInformationPdu GetTcpDumpStatus()
        //          => _serverApiScope.LoggingApi.GetTcpDumpStatus();

        //      public SystemInfo GetSystemInfo()
        //          => _serverApiScope.SystemInformationApi.GetSystemInfo();

        //      public bool SetGack(byte[] zippedGackFolder, string name)
        //      {
        //          LogWrite($"SetGack {name}");
        //          ThrowIfNoPermission(_restrictions.RoleForSaveGack);
        //          LogWrite($"SetGack {name} allowed");

        //          var gack = new NewZipGackReader().GetGackOrNull(new MemoryStream(zippedGackFolder));
        //          LogWrite($"Start saving gack {name}");

        //          if (gack == null)
        //              throw new InvalidOperationException("Gack has wrong format");
        //          _serverApiScope.ActiveProjectApi.SaveProject(gack, name);
        //          LogWrite($"Gack {name} saved");

        //          return true;
        //      }

        //      public FilePdu GetGack()
        //      {
        //          ThrowIfNoPermission(_restrictions.RoleForDownloadProject);
        //          return _serverApiScope.ActiveProjectApi.GetActiveProject();
        //      }

        //      public ProjectInfo GetGackInfo()
        //      {
        //          ThrowIfNoPermission(_restrictions.RoleForDownloadProjectInfo);
        //          return _serverApiScope.ActiveProjectApi.GetInformationAboutRunningProject();
        //      }

        public void RestartApplicationAndForget()
        {
            ThrowIfNoPermission(_restrictions.RoleForRestartApplication);
            if (!_serverApiScope.CanBeRestarted) return;
            _serverApiScope.RestartApplication();
        }

        public bool RestartApplicationAndThrow()
        {
            //LogWrite("Restart application and throw Connection is lost");
            RestartApplicationAndForget();
            return true;
        }

        //      public bool SetNetworkSettings(NetworkSettings settings)
        //      {
        //          LogWrite("Set network settings");
        //          ThrowIfNoPermission(_restrictions.RoleForSetNetworkSettings);

        //       try
        //       {
        //        _serverApiScope.NetworkApi.SetNetworkSettings(settings);
        //       }
        //       catch
        //       {
        //        return false;
        //       }

        //          return RestartApplicationAndThrow();
        //      }

        //      public NetworkSettings GetNetworkSettings()
        //      {
        //          LogWrite("Get network settings");
        //          ThrowIfNoPermission(_restrictions.RoleForGetNetworkSettings);
        //          return _serverApiScope.NetworkApi.GetNetworkSettings();
        //      }

        //      public ConnectionSettings GetConnectionSettings()
        //      {
        //          LogWrite("Get connection settings");
        //          ThrowIfNoPermission(_restrictions.RoleForGetConnectionSettings);
        //          return _serverApiScope.NetworkApi.GetConnectionSettings();
        //      }

        public LoginResult TryLogIn(string userName, string password)
        {
            try
            {
                //LogWrite("Try logIn");
                //_userService.LogIn(userName, password);
                return LoginResult.SuccesAuthentification;
            }
            catch (AuthentificationFailedException)
            {
                return LoginResult.FailedAuthentification();
            }
        }

        //      #endregion    

        //      #region Software update

        //      public UpdatePermission TryGetPermissionToUpdate(SoftwareVersion version, SoftwareFileInfo info)
        //      {
        //          LogWrite($"Try get permission to update [SoftwareVersion]: {info} [FileName]: {version}");
        //          ThrowIfNoPermission(_restrictions.SonicaCoreSoftwareUpdate);

        //          if (_serverApiScope.SoftwareUpdateApiOrNull == null)
        //              return UpdatePermission.Fail("Not Implemented");
        //          else
        //              return _serverApiScope.SoftwareUpdateApiOrNull.TryGetPermissionToUpdate(version, info);
        //      }

        //      public SavePartResult TrySendPartOfUpdate(PartOfUpdate partOfUpdate)
        //      {
        //          LogWrite($"Try send part of update: {partOfUpdate}");
        //          ThrowIfNoPermission(_restrictions.SonicaCoreSoftwareUpdate);

        //          if (_serverApiScope.SoftwareUpdateApiOrNull == null)
        //              return SavePartResult.Fail("Not Implemented");
        //          else
        //              return _serverApiScope.SoftwareUpdateApiOrNull.TrySavePartOfUpdate(partOfUpdate);
        //      }

        //      public VerifyResult TryVerifySoftwarePackage()
        //      {
        //          LogWrite("Try verify software package");
        //          ThrowIfNoPermission(_restrictions.SonicaCoreSoftwareUpdate);

        //          if (_serverApiScope.SoftwareUpdateApiOrNull == null)
        //              return VerifyResult.Fail("Not Implemented");
        //          else
        //          {
        //              return _serverApiScope.SoftwareUpdateApiOrNull.TryVerifySoftwarePackage();
        //          }
        //      }

        //      public RollBackResult TryRollBackUpdate()
        //      {
        //          LogWrite("Try roll back update");
        //          ThrowIfNoPermission(_restrictions.SonicaCoreSoftwareUpdate);

        //          if (_serverApiScope.SoftwareUpdateApiOrNull == null)
        //              return RollBackResult.Fail("Not Implemented");
        //          else
        //              return _serverApiScope.SoftwareUpdateApiOrNull.TryRollBackUpdate();
        //      }

        //      #endregion

        //      #region Parametrization

        //      public SetParametersResult SetParameters(ParametersContainer settings)
        //      {
        //          var sb = new StringBuilder();
        //          foreach (var parameter in settings.Parameters)
        //          {
        //              sb.Append($"\r\n{parameter.Name}:{parameter.Value}");
        //          }

        //          LogWrite($"Set parameters ({settings.Parameters.Length}) {sb}");
        //          return _serverApiScope.Parametrization.SetParameters(settings);
        //      }

        //      public ParametersContainer GetParameters()
        //      {
        //          LogWrite("Get parameters");
        //          return _serverApiScope.Parametrization.GetParameters();
        //      }

        //      #endregion

        //      #region Core Files

        //      public CoreFilesListDto GetAllFileSourceInfos()
        //          => _serverApiScope.FileSourcesApi.GetAllCoreFileInfos();

        //      public CoreFilesListDto GetAllFileSourceInfos(CoreFilesFilterDto filterDto)
        //          => _serverApiScope.FileSourcesApi.GetAllCoreFileInfos(filterDto);

        //      public CoreFilePortionDto InitializeDownload(string blockPath, string fileId) 
        //          => _serverApiScope.FileSourcesApi.InitializeDownload(blockPath, fileId);

        //      public CoreFilePortionDto GetNextPortion(int downloadId)
        //          => _serverApiScope.FileSourcesApi.GetNextPortion(downloadId);

        //      public bool CancelFileOperation(int id) 
        //          => _serverApiScope.FileSourcesApi.Cancel(id);

        //      public bool ClearFile(string blockPath, string fileId) 
        //          => _serverApiScope.FileSourcesApi.ClearFile(blockPath, fileId);

        //      public UploadPortionResultDto InitializeUpload(CoreFilePortionDto filePortion)
        //          => _serverApiScope.FileSourcesApi.InitializeUpload(filePortion);

        //      public UploadPortionResultDto SetNextPortion(CoreFilePortionDto filePortion)
        //          => _serverApiScope.FileSourcesApi.SetNextPortion(filePortion);

        //      #endregion

        //      #region Linux system time

        //      public TimeSettingResult SetLinuxSystemTime(TimeSetting setting)
        //      {
        //          try
        //          {
        //              return _serverApiScope.LinuxSystemTimeApiOrNull.SetSystemTime(setting);
        //          }
        //          catch (Exception e)
        //          {
        //              return TimeSettingResult.Fail($"Fail set time, error: {e.Message}");
        //          }
        //      }

        //      public TimeSettingResult GetLinuxSystemTime(TimeSetting setting)
        //      {
        //          try
        //          {
        //              return _serverApiScope.LinuxSystemTimeApiOrNull.GetSystemTime(setting);
        //          }
        //          catch (Exception e)
        //          {
        //              return TimeSettingResult.Fail($"Fail get time, error: {e.Message}");
        //          }
        //      }

        //      #endregion

        //      #region OEM KEY

        //      public RequestKeyPdu GetRequestKey()
        //      {
        //          try
        //          {
        //             return _serverApiScope.License.GetRequestKey();
        //          }
        //          catch (Exception e)
        //          {
        //              return RequestKeyPdu.Fail($"Fail get request key: {e.Message}");
        //          }
        //      }

        //      public ResponseKeyResultPdu SetResponseKey(ResponseKeyPdu key)
        //      {
        //          try
        //          {
        //              return _serverApiScope.License.Activate(key);
        //          }
        //          catch (Exception e)
        //          {
        //              return ResponseKeyResultPdu.Fail(e);
        //          }
        //      }

        //      public LicenseInfoPdu GetLicenseInformation()
        //      {
        //          return _serverApiScope.License.GetLicenseInformation();
        //      }

        //      public GetWorkModePdu GetCoreRunMode()
        //      {
        //          return _serverApiScope.WorkModeService?.GetCoreRunMode();
        //      }

        //      public SetResultRunModePdu SetCoreRunMode(SetWorkModePdu workModePdu)
        //      {
        //          return _serverApiScope.WorkModeService?.SetCoreRunMode(workModePdu);
        //      }

        //      #endregion

        //#region Private methods

        //private bool IsAllowed(UserRole? role) 
        //    => role.HasValue && _userService.IsAllowed(role.Value);

        private void ThrowIfNoPermission(UserRole? role)
        {
            if (!role.HasValue)
                throw new InvalidOperationException("Specified server api method is inaccessible");
            _userService.ThrowIfNotAllowed(role.Value);
        }

        //private static void LogWrite(string message, LogLevel logLevel = LogLevel.Debug) 
        //    => Log.Write(logLevel, "[Core API]", message);

        //private void OnProjectStateChanged(BlockState state)
        //{
        //    // Если state изменился а связь по TNT еще не подключились 
        //    // Получаем ошибку, ошибка проявщяется при определенных обстоятельства ...
        //    try {
        //        ProjectStateChanged?.Invoke((int) state);
        //    }
        //    catch (Exception e) {
        //        LogWrite("Fail send project state: " + e.Message);   
        //    }
        //}

        //#endregion

        public void Release()
        {
            //if (_serverApiScope != null)
            //    _serverApiScope.ActiveProjectApi.ProjectStateChanged -= OnProjectStateChanged;
        }
    }
}