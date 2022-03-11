

using SonicaWebAdmin.SonicaAdmin.Entities;

namespace SonicaWebAdmin.SonicaAdmin.CoreServerApi
{
    /// <summary>
    /// Разрешения на операции серверного API
    /// </summary>
    public class Restrictions
    {
        public static Restrictions Create()
        {
            return new Restrictions
            {
                RoleForSaveGack              = UserRole.Administrator,
                RoleForRestartApplication    = UserRole.Administrator,
                RoleForSetNetworkSettings    = UserRole.Administrator,
                SonicaCoreSoftwareUpdate     = UserRole.Administrator,
                RoleForSoftwareUpdate        = UserRole.Administrator,

                RoleForGetConnectionSettings = UserRole.Guest,
                RoleForGetNetworkSettings    = UserRole.Guest,
                RoleForDownloadProject       = UserRole.Guest,
                RoleForDownloadProjectInfo   = UserRole.Guest
            };
        }

        public UserRole? RoleForGetConnectionSettings { get; set; }
        public UserRole? RoleForSaveGack              { get; set; }
        public UserRole? RoleForRestartApplication    { get; set; }
        public UserRole? RoleForSetNetworkSettings    { get; set; }
        public UserRole? RoleForGetNetworkSettings    { get; set; }
        public UserRole? RoleForDownloadProject       { get; set; }
        public UserRole? RoleForDownloadProjectInfo   { get; set; }
        public UserRole? SonicaCoreSoftwareUpdate     { get; set; }
        public UserRole? RoleForSoftwareUpdate        { get; set; }
    }
}