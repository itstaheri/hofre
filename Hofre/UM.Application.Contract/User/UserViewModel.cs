using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM.Application.Contract.User
{
    public class UserViewModel
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ProfilePicture { get; set; }
        public bool IsActive { get; set; }
        public long RoleId { get; set; }
        public string CreationDate { get; set; }
        public string RoleName { get; set; }
    }
}
