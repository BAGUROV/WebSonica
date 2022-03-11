using ProtoBuf;

namespace SonicaWebAdmin.SonicaAdmin.CoreServerApi.PDU
{
    [ProtoContract]
    public class Permissions
    {
        [ProtoMember(1)] public bool AllowSetGack;
        [ProtoMember(2)] public bool AllowGetGack;
        [ProtoMember(3)] public bool RestartApplication;
        [ProtoMember(4)] public bool SetNetworkSettings;
        [ProtoMember(5)] public bool GetNetworkSettings;
        [ProtoMember(6)] public bool SoftwareUpdate;
        [ProtoMember(7)] public bool DownloadProjectInfo;
        [ProtoMember(8)] public bool ChangeServerSystemTime;
        [ProtoMember(9)] public bool DeviceActivated;

        public static Permissions DeviceNotActivated() {
            return new Permissions {
                AllowSetGack           = false,
                AllowGetGack           = false,
                RestartApplication     = true,
                SetNetworkSettings     = false,
                GetNetworkSettings     = false,
                SoftwareUpdate         = true,
                DownloadProjectInfo    = true,
                ChangeServerSystemTime = false,
                DeviceActivated        = false
            };
        }
    }
}