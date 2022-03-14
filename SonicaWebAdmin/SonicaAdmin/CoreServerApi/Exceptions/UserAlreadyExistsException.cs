using System;

namespace SonicaWebAdmin.SonicaAdmin.CoreServerApi.Exceptions
{
    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException(string name) : base("User \"" + name + "\" already exists")
        {
            Name = name;
        }
        public UserAlreadyExistsException(Guid id) : base("User with id of " + id.ToString() + " already exists")
        {
            Id = id;
        }

        public Guid? Id { get; }

        public string Name { get; }
    }
}
