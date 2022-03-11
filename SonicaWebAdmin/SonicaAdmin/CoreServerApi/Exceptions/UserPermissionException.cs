using SonicaWebAdmin.SonicaAdmin.Entities;
using System;

namespace Auth.Exceptions
{
    public class UserPermissionException: Exception
    {
        public UserPermissionException(UserRole currentRole, UserRole minimumRole)
            : base("This action needs \""+ minimumRole+"\" role to continue")
        {
            CurrentRole = currentRole;
            MinimumRole = minimumRole;
        }

        public UserRole CurrentRole { get; }

        public UserRole MinimumRole { get; }
    }
}
