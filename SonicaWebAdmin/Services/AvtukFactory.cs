using System.Linq;
using System.Net;

namespace SonicaWebAdmin.Services
{
    public class AvtukFactory : IAvtukFactory
    {
        public IPAddress Ip { get; private set; }
        public void SetIpAddress(string address)
        {
            if (address == null)
                return;

            var test = address.Split('.');
            byte[] arrayAddress = test.Select(byte.Parse).ToArray();
            Ip = new IPAddress(arrayAddress);
        }
    }
    public interface IAvtukFactory
    {
        public IPAddress Ip { get; }
        public void SetIpAddress(string address);
    }
}
