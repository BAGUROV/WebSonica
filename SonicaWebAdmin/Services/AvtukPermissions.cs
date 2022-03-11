


namespace SonicaWebAdmin.Services
{
    public readonly struct AvtukPermissions
    {
        public readonly bool CanGetNetworkSettings;
        public readonly bool CanRestartApplication;
        public readonly bool CanSetGack;
        public readonly bool CanSetNetworkSettings;
        public readonly bool CanGetGack;
        public readonly bool CanDownloadProjectInfo;
        public readonly bool CanUpdateSoftware;
        public readonly bool CanChangeServerSystemTime;
        public readonly bool DeviceActivated;
        
        //public AvtukPermissions(Permissions permissions)
        //{
        //    CanRestartApplication = permissions.RestartApplication;
        //    CanGetNetworkSettings = permissions.GetNetworkSettings;
        //    CanGetGack = permissions.AllowGetGack;
        //    CanSetGack = permissions.AllowSetGack;
        //    CanSetNetworkSettings = permissions.SetNetworkSettings;
        //    CanDownloadProjectInfo = permissions.DownloadProjectInfo;
        //    CanUpdateSoftware = permissions.SoftwareUpdate;
        //    CanChangeServerSystemTime = permissions.ChangeServerSystemTime;
        //    DeviceActivated = permissions.DeviceActivated;
        //}

        public bool IsDeviceActivated => DeviceActivated;
    }
}