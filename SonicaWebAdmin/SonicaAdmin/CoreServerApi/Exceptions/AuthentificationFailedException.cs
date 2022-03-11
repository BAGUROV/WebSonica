using System;

namespace Auth.Exceptions
{
    public class AuthentificationFailedException : Exception
    {
        public AuthentificationFailedException() { }
        public AuthentificationFailedException(string message) : base(message)
        {

        }
    }
}
