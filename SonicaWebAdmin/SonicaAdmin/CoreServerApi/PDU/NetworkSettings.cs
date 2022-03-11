using ProtoBuf;

namespace SonicaWebAdmin.SonicaAdmin.CoreServerApi.PDU
{
    [ProtoContract]
    public class NetworkSettings
    {
        [ProtoMember(1)] 
        public NetworkInterfaceSettings[] NetworkInterfaceSettings { get; set; }

        public static NetworkSettings CreateWithSingleNetworkInterface(NetworkInterfaceSettings interfaceSettings)
        {
            return new NetworkSettings
            {
                NetworkInterfaceSettings = new []{interfaceSettings}
            };
        }
    }
}