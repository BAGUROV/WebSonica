

using SonicaWebAdmin.SonicaAdmin.Entities;

namespace SonicaWebAdmin.SonicaAdmin.Interfaces
{
    public interface IUserRepository : IUserReadonlyRepository
    {
        void AddUser(User user);
        void UpdateUser(User user);
        void Remove(string userName);
    }
}
