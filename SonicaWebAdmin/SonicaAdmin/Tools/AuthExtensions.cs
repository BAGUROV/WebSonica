using Auth.Exceptions;
using SonicaWebAdmin.SonicaAdmin.Entities;

namespace SonicaWebAdmin.SonicaAdmin.Tools
{
    public static class AuthExtensions
    {
        public static bool Allow(this UserRole originRole, UserRole restrictionRole)
        {
            return originRole <= restrictionRole;
        }

        public static void ThrowIfNotAllowed(this UserRole originRole, UserRole restrictionRole)
        {
            if (!originRole.Allow(restrictionRole))
                throw new UserPermissionException(originRole, restrictionRole);
        }

        public static UserInfo GetInfo(this User entity)
        {
            return UserInfo.Create(entity.UserName, entity.Role, entity.Id);
        }

        public static void SetPassword(this User entity,string password)
        {
            entity.Salt = PasswordTools.CreateSalt(10);
            entity.Hash = PasswordTools.GenerateSaltedHash(password, entity.Salt);
        }

        public static bool CheckPassword(this User entity, string password)
        {
            return PasswordTools.CheckPassword(password, entity.Hash, entity.Salt);
        }
    }
}
