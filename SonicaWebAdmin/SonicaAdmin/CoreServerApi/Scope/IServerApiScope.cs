
using SonicaWebAdmin.SonicaAdmin.Interfaces;

namespace SonicaWebAdmin.SonicaAdmin.CoreServerApi.Scope
{
    /// <summary>
    /// Сервис для управления приложением
    /// </summary>
    public interface IServerApiScope : IReleasable
    {
        bool CanBeRestarted { get; }
        //IFileSourcesApi FileSourcesApi { get; }
        //ISoftwareUpdateApi SoftwareUpdateApiOrNull { get; }
        //ISystemInformationApi SystemInformationApi { get; }
        //IActiveProjectApi ActiveProjectApi { get; }
        //INetworkApi NetworkApi { get; }
        //ILoggingApi LoggingApi { get; }
        //IDeviceMetrics Metrics { get; }
        //IParametrization Parametrization { get; }
        //public ILinuxSystemTimeApi LinuxSystemTimeApiOrNull { get; }
        //ILicenseService License { get; }
        //ICoreRunWorkModeService WorkModeService { get; }
        void RestartApplication();
    }
}