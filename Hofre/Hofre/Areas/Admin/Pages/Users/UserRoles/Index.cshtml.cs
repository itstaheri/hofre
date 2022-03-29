using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using UM.Application.Contract.UserRole;

namespace Hofre.Areas.Admin.Pages.Users.UserRoles
{
    public class IndexModel : PageModel
    {
        private readonly IUserRoleApplication _repository;
        public List<UserRoleViewModel> UserRoles { get; set; }
        public IndexModel(IUserRoleApplication repository)
        {
            _repository = repository;
        }

        public async Task OnGet()
        {
            UserRoles = await _repository.GetAll();

        }
        public async Task OnPost(CreateUserRole commend)
        {
            await _repository.Create(commend);
        }
    }
}
