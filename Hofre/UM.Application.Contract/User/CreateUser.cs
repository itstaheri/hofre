using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM.Application.Contract.User
{
    public class CreateUser
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public IFormFile ProfilePicture { get; set; }
        public long RoleId { get; set; }
    }
}
