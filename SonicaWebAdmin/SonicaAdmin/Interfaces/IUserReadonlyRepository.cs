using SonicaWebAdmin.SonicaAdmin.Entities;
using System;
using System.Collections.Generic;

namespace SonicaWebAdmin.SonicaAdmin.Interfaces
{
    public interface IUserReadonlyRepository
    {
        IEnumerable<User> GetAllUsers();
        User Get(string userName);
        User Get(Guid id);
    }
}
