using System;

namespace SonicaWebAdmin.SonicaAdmin.CoreServerApi.Exceptions
{
    public class AuthentificationFailedException : Exception
    {
        public AuthentificationFailedException() { }
        public AuthentificationFailedException(string message) : base(message)
        {

        }
    }
}
