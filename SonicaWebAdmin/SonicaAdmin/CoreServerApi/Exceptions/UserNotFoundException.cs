using System;

namespace SonicaWebAdmin.SonicaAdmin.CoreServerApi.Exceptions
{
    public class UserNotFoundException: Exception
    {
        public UserNotFoundException(string name) : base("User \"" + name + "\" not found")
        {
            Name = name;
        }
        public UserNotFoundException(Guid id) : base("User with id of " + id.ToString() + " not found")
        {
            Id = id;
        }

        public Guid? Id { get; }

        public string Name { get; }
    }
}
