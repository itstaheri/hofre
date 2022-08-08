using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frameworks.Auth
{
    public class AuthViewModel
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public string RoleName { get; set; }
        public string Username { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
        public List<string> Permissions { get; set; }
    }
}
