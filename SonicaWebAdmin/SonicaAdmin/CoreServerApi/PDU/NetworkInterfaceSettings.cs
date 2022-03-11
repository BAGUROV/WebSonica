using ProtoBuf;

namespace SonicaWebAdmin.SonicaAdmin.CoreServerApi.PDU
{
    /// <summary>
    /// Настройка сетевого интерфейса (сетевой карты итд)
    /// </summary>
    [ProtoContract]
    public class NetworkInterfaceSettings
    {
        [ProtoMember(1)] public string NetworkId { get; set; }
        [ProtoMember(2)] public byte[] IpAddress { get; set; }
        [ProtoMember(3)] public byte[] Mask      { get; set; }
        [ProtoMember(6)] public byte[] Gateway   { get; set; }
    }
}