using Core.ServerApi;
using Core.ServerApi.Contract;
using System.Net;

namespace SonicaWebAdmin.Models
{
    public class ConnectingAdmin
    {
        public void ReConnect(ref IServerApiContract contract)
        {
            contract = CoreServerApi.Connect(endPoint: new IPEndPoint(new IPAddress(new byte[] { 172, 16, 29, 222 }), 17177)).Contract;
        }
    }
}
