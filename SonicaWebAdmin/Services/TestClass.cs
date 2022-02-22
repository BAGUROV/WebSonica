using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SonicaWebAdmin.Services
{
    public class TestClass : ITestClass
    {
        public int Send()
        {
            return 1;
        }
    }
    public interface ITestClass
    {
        int Send();
    }
}
