using SonicaWebAdmin.SonicaAdmin.CoreServerApi.Exceptions;
using SonicaWebAdmin.SonicaAdmin.Entities;
using SonicaWebAdmin.SonicaAdmin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SonicaWebAdmin.SonicaAdmin
{
    public class UserCollectionRepository : IUserRepository
    {
        private readonly List<User> _users;

        public UserCollectionRepository(IEnumerable<User> users)
        {
            _users = new List<User>();
            foreach (var user in users)
            {
                AddUser(user);
            }
        }

        public UserCollectionRepository()
        {
            _users = new List<User>();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _users.ToList();
        }

        public User Get(string userName)
        {
            var user = _users.SingleOrDefault(u => u.UserName == userName);
            if (user == null)
                throw new UserNotFoundException(userName);
            return user;
        }

        public User Get(Guid id)
        {
            var user = _users.SingleOrDefault(u => u.Id == id);
            if (user == null)
                throw new UserNotFoundException(id);
            return user;
        }

        public void AddUser(User user)
        {
            if (_users.Any(u => u.UserName == user.UserName))
                throw new UserAlreadyExistsException(user.UserName);
            if (_users.Any(u => u.Id == user.Id))
                throw new UserAlreadyExistsException(user.Id);
            if (user.Id == Guid.Empty)
                throw new InvalidOperationException("User id is empty");

            _users.Add(user);
        }

        public void UpdateUser(User user)
        {
            //do nothing;
        }

        public void Remove(string userName)
        {
            var user = Get(userName);
            _users.Remove(user);
        }
    }
}
