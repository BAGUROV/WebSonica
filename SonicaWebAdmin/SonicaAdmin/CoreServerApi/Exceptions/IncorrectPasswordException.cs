namespace SonicaWebAdmin.SonicaAdmin.CoreServerApi.Exceptions
{
    public class IncorrectPasswordException: AuthentificationFailedException
    {
        public IncorrectPasswordException() : base("Incorrect password")
        {
            
        }
    }
}
