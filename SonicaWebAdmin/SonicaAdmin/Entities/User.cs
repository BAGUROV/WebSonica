using SonicaWebAdmin.SonicaAdmin.Tools;
using System;

namespace SonicaWebAdmin.SonicaAdmin.Entities
{
    public class User
    {
        public static User  Create(string userName, string password, UserRole role)
        {
            return Create(userName, password, role, Guid.NewGuid());
        }
        
        public static User Create(string userName, string password, UserRole role, Guid id)
        {
            var user = new User
            {
                Created  = DateTime.Now,
                UserName = userName,
                Role     = role,
                Id       = id
            };
            user.SetPassword(password);
            return user;
        }

        public virtual Guid Id { get; set; }
        public virtual string UserName { get; set; }
        public virtual UserRole Role { get; set; }
        public virtual byte[] Hash { get; set; }
        public virtual byte[] Salt { get; set; }
        public virtual DateTime Created { get; set; }
       
    }
}
