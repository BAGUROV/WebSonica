using SonicaWebAdmin.SonicaAdmin.CoreServerApi.Exceptions;
using SonicaWebAdmin.SonicaAdmin.Entities;
using SonicaWebAdmin.SonicaAdmin.Interfaces;
using SonicaWebAdmin.SonicaAdmin.Tools;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SonicaWebAdmin.SonicaAdmin
{
    public class UserService: IUserService
    {
        private readonly IUserReadonlyRepository _repository;
        private UserInfo _currentUser;
        private readonly UserInfo _defaultUser;

        public UserService(IUserReadonlyRepository repository)
            :this(repository, UserInfo.CreateGuest())
        {
        }

        public UserService(IUserReadonlyRepository repository, UserInfo defaultUser)
        {
            _repository  = repository;
            _defaultUser = defaultUser;
            _currentUser = defaultUser;
        }

        public event Action<IUserService, UserInfo> CurrentUserChanged;

        public UserInfo CurrentUser
        {
            get => _currentUser;
            private set
            {
                var oldUser  = _currentUser;
                _currentUser = value;
                if(!value.IsEqualTo(oldUser))
                {
                    CurrentUserChanged?.Invoke(this, value);
                }
            }
        }

        public IEnumerable<UserInfo> GetAllUsers()
        {
            return _repository.GetAllUsers().Select(g => g.GetInfo()).ToList();
        }

        public void LogOut()
        {
            CurrentUser = _defaultUser;
        }

        public void LogIn(string userName, string password)
        {
            User user;
            try
            {
                user = _repository.Get(userName);
            }
            catch (UserNotFoundException) 
            {
                throw new AuthentificationFailedException();
            }

            if (!user.CheckPassword(password))
                throw new AuthentificationFailedException();
            CurrentUser = user.GetInfo();
        }

        internal void LogIn(string userName)
        {
            CurrentUser = _repository.Get(userName).GetInfo();
        }

        public void ThrowIfNotAllowed(UserRole minimumUserRole)
        {
            CurrentUser.Role.ThrowIfNotAllowed(minimumUserRole);
        }

        public bool IsCurrentUserDefault => _currentUser.IsEqualTo(_defaultUser);

        public bool IsAllowed(UserRole minimumUserRole)
        {
            return CurrentUser.Role.Allow(minimumUserRole);
        }
    }
}
