using System;

namespace SonicaWebAdmin.SonicaAdmin.CoreServerApi.Scope
{
    public class ServerApiScope : IServerApiScope
    {
        //public IFileSourcesApi FileSourcesApi { get; }
        //public ISoftwareUpdateApi SoftwareUpdateApiOrNull { get; }
        //public ILinuxSystemTimeApi LinuxSystemTimeApiOrNull { get; }
        //public ILicenseService License { get; }
        //public ICoreRunWorkModeService WorkModeService { get; }
        //public ISystemInformationApi SystemInformationApi { get; }
        //public IActiveProjectApi ActiveProjectApi { get; }
        //public INetworkApi NetworkApi { get; }
        //public ILoggingApi LoggingApi { get; }
        //public IDeviceMetrics Metrics { get; }
        //public IParametrization Parametrization { get; }

        private readonly Action _restartCallback;

        public ServerApiScope(
            //ISystemInformationApi systemInformationApi,
            //IActiveProjectApi activeProjectApi,
            //INetworkApi networkApi,
            //ILoggingApi loggingApi,
            //IDeviceMetrics deviceMetrics,
            //IParametrization parametrization,
            //IFileSourcesApi fileSourcesApi,
            //ILicenseService licenseService,
            //ICoreRunWorkModeService workModeService = null,
            //ISoftwareUpdateApi softwareUpdateApiOrNull = null,
            //ILinuxSystemTimeApi linuxSystemTimeApi = null,
            Action restartCallback = null)
        {
            //SoftwareUpdateApiOrNull = softwareUpdateApiOrNull;
            //LinuxSystemTimeApiOrNull = linuxSystemTimeApi;
            //SystemInformationApi = systemInformationApi;
            //ActiveProjectApi = activeProjectApi;
            //NetworkApi = networkApi;
            //LoggingApi = loggingApi;
            //Metrics = deviceMetrics;
            //License = licenseService;
            //WorkModeService = workModeService;
            //Parametrization = parametrization ?? throw new ArgumentNullException(nameof(parametrization));
            //FileSourcesApi = fileSourcesApi;
            _restartCallback = restartCallback;
        }

        public bool CanBeRestarted => _restartCallback != null;

        public void RestartApplication()
        {
            //Log.Debug("AdminAppScope", "Call RestartApplication");
            _restartCallback?.Invoke();
        }

        public void Release()
        {
            //ActiveProjectApi.Release();
        }
    }
}
