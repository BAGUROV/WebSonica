using System;

namespace SonicaWebAdmin.SonicaAdmin.Entities
{
    public class UserInfo
    {
        public static UserInfo CreateGuest(string userName = "Guest")
        {
            return new UserInfo(userName, UserRole.Guest, Guid.NewGuid());
        }

        public static UserInfo CreateAdmin(string userName = "Admin")
        {
            return new UserInfo(userName, UserRole.Administrator, Guid.NewGuid());
        }

        public static UserInfo CreateDeveloper(string name = "Developer")
        {
            return Create(name, UserRole.Developer);
        }

        public static UserInfo Create(string userName, UserRole role, Guid id)
        {
            return new UserInfo(userName, role, id);
        }

        public static UserInfo Create(string userName, UserRole role)
        {
            return new UserInfo(userName, role, Guid.NewGuid());
        }

        private UserInfo(string userName, UserRole role, Guid id)
        {
            UserName = userName;
            Role     = role;
            Id       = id;
        }

        public Guid Id { get; }

        public string UserName { get; }

        public UserRole Role { get; }

        public bool IsEqualTo(UserInfo user)
        {
            if (Id != user.Id) return false;
            if (user.Role != Role) return false;
            if (user.UserName != UserName) return false;
            return true;
        }
    }
}