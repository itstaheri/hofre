using Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UM.Domain.UserRoleAgg;

namespace UM.Domain.UserAgg
{
    public class UserModel : BaseEntity
    {
        public UserModel(string username, string email, string phone, string password, string profilePicture, long roleId)
        {
            Username = username;
            Email = email;
            Phone = phone;
            Password = password;
            ProfilePicture = profilePicture;
            RoleId = roleId;
            IsActive = true;
        }
        public void Edit(string username, string email, string phone, long roleId)
        {
            Username = username;
            Email = email;
            Phone = phone;
            RoleId = roleId;

        }
        public void ChangeProfilePicture(string picture)
        {
            if (!string.IsNullOrWhiteSpace(picture)) ProfilePicture = picture;
          
        } 
        public void ChangePassword(string password) => Password = password;
        public void Active() => IsActive = true;
        public void DeActive() => IsActive = false;

        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string Password { get; private set; }
        public string ProfilePicture { get; private set; }
        public bool IsActive { get; private set; }
        public long RoleId { get; private set; }
        public UserRoleModel userRole { get; private set; }
    }
}
