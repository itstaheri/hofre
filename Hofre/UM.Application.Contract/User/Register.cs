using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM.Application.Contract.User
{
    public class Register
    {
        [Required(ErrorMessage ="USERNAME_IS_REQUIRED")]
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "کلمه ی عبور و تکرار کلمه ی عبور باید مانند هم باشند!")]
        public string RePassword { get; set; }
    }
}
