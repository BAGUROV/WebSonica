using SonicaWebAdmin.SonicaAdmin.Entities;
using System;
using System.Collections.Generic;

namespace SonicaWebAdmin.SonicaAdmin.Interfaces
{
    public interface IUserService
    {
        event Action<IUserService, UserInfo> CurrentUserChanged;
        UserInfo CurrentUser { get; }
        IEnumerable<UserInfo> GetAllUsers();
        
        void LogOut();

        /// <summary>
        /// Производит авторизацию пользователя
        /// </summary>
        /// <exception cref="AuthentificationFailedException"></exception>
        void LogIn(string user, string password);

        void ThrowIfNotAllowed(UserRole minimumUserRole);
        bool IsAllowed(UserRole minimumUserRole);
        bool IsCurrentUserDefault { get; }
    }
}
