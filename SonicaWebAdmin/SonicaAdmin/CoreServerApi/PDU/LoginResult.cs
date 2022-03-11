using ProtoBuf;

namespace SonicaWebAdmin.SonicaAdmin.CoreServerApi.PDU
{
    [ProtoContract]
    public class LoginResult
    {
        [ProtoMember(1)] public bool Succes { get; set; }

        public static LoginResult SuccesAuthentification => new LoginResult { Succes = true };
        
        public static LoginResult FailedAuthentification() => new LoginResult { Succes = false };
        
    }
}