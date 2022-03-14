using System;

namespace SonicaWebAdmin.SonicaAdmin.CoreServerApi.Scope
{
    public class ServerApiScopeBuilder
    {
        private readonly string             _coreSettingsLocation;
        //private readonly CoreSystem         _coreSystem;
        //private readonly ICoreConfiguration _settings;
        private readonly Action             _restartCallback;

        //private SoftwareUpdateApi   _softwareUpdateApi;
        //private ILinuxSystemTimeApi _systemTimeLinuxApi;
        //private LicenseService      _licenseService;

        public ServerApiScopeBuilder(
            string coreSettingsLocation,
            //CoreSystem coreSystem,
            //ICoreConfiguration settings,
            Action restartCallback = null)
        {
            _coreSettingsLocation = coreSettingsLocation;
            //_coreSystem           = coreSystem;
            //_settings             = settings;
            _restartCallback      = restartCallback;
        }
        
        //public ServerApiScopeBuilder UseLinuxSystemTimeApi(AliseClient client)
        //{
        //    _systemTimeLinuxApi = new AliseSystemTimeApi(client, logger: Log.GetCurrentLog());
        //    return this;
        //}
        
        //public ServerApiScopeBuilder UseSoftwareUpdateApi()
        //{
        //    _softwareUpdateApi = new SoftwareUpdateApi(
        //        releaseCoreSystem: ()=> _coreSystem.Release(3000),
        //        imageValidator:    new ImageValidator(),
        //        archiveExtractor:  new ArchiveExtractor(),
        //        updateSaver:       new UpdateFileSaver(),
        //        updateRollBacker:  new UpdateRollBacker(),
        //        stepCalculator:    new StepCalculator(TimeSpan.FromMinutes(3)),
        //        updateSettings:    new SoftwareUpdateSettings(_settings, _coreSettingsLocation),
        //        //logger:            Log.GetCurrentLog()
        //        );
            
        //    return this;
        //}
        
        //public ServerApiScopeBuilder UseLicenseService(LicenseService licenseService)
        //{
        //    _licenseService = licenseService ?? throw new ArgumentNullException(nameof(licenseService));
        //    return this;
        //}
        
        public ServerApiScope Build()
        {
            //var systemInformationApi = new SystemInformationApi(
            //    softwareVersion: AssemblyTools.Git.SemVer,
            //    maxClients: _settings.Tunnel.MaxClients,
            //    system: _coreSystem,
            //    startupMetrics: _startupMetrics ?? new StartupMetrics());

            //var activeProjectApi = new ActiveProjectApi(
            //    coreSystem: _coreSystem,
            //    configurationSettings: _settings,
            //    coreSettingsLocation: _coreSettingsLocation);

            //var networkLinuxApi = new NetworkLinuxApi(
            //    tunnelIpAddress: ParseTools.ParseIp(_settings.Tunnel.ListenAddress),
            //    tunnelPort: (ushort) _settings.Tunnel.Port);

            //var loggingApi = new LoggingApi(
            //    pathToLogsLocation: _settings.Logger.LogsLocation,
            //    processRunner: ProcessRunner.Create(true, true), 
            //    logger: Log.GetCurrentLog().Wrap("LogApi"));
            
            return new ServerApiScope(
                //systemInformationApi: systemInformationApi,
                //activeProjectApi: activeProjectApi,
                //networkApi: networkLinuxApi,
                //loggingApi: loggingApi,
                
                //deviceMetrics: new MetricsApi(_coreSystem.GetMetrics, new CPUInfoProvider()),
                
                //parametrization: new ParametrizationService(
                //    reader: new ParametersReader(_coreSystem.Root.Parameters),
                //    saver:  new IniParametersSaver(_settings.Core.ParametersLocation)),
                //fileSourcesApi: new FileSourcesApi(_coreSystem),
                
                //workModeService: new CoreRunWorkModeService(_settings, Log.GetCurrentLog()), 
                
                //licenseService:          _licenseService,
                //softwareUpdateApiOrNull: _softwareUpdateApi,
                //linuxSystemTimeApi:      _systemTimeLinuxApi,
                restartCallback:         _restartCallback
            );
        }
    }
}