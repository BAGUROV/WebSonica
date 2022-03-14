using SonicaWebAdmin.SonicaAdmin.Entities;

namespace SonicaWebAdmin.SonicaAdmin.Interfaces
{
    public interface IUserEditService
    {
        User Add(UserInfo user, string password);
        void Remove(string name);
        void SetPassword(string name, string password);
        void Update(UserInfo user);
    }
}
