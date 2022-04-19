using System.Linq;
using System.Net;

namespace SonicaWebAdmin.Services
{
    public static class TestClass
    {
        public static IPAddress SetIpAddress(string address)
        {
            if (address == null)
                return null;

            var test = address.Split('.');
            byte[] arrayAddress = test.Select(byte.Parse).ToArray();
            return new IPAddress(arrayAddress);
        }
    }
}
