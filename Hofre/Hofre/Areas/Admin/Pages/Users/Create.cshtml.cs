using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using UM.Application.Contract.User;
using UM.Application.Contract.UserRole;
using System.Linq;
using System.Threading.Tasks;

namespace Hofre.Areas.Admin.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly IUserApplication _repository;
        private readonly IUserRoleApplication _role;
        public List<SelectListItem> roles;
        public CreateModel(IUserApplication repository, IUserRoleApplication role)
        {
            _repository = repository;
            _role = role;
        }

        public  async void OnGet()
        {
            var GetRoles = (await _role.GetAll()).Select(x => new SelectListItem(x.RoleName, x.Id.ToString())).ToList();
        }
        public async Task<RedirectToPageResult> OnPost(CreateUser commend)
        {
            await _repository.Create(commend);
            return RedirectToPage("./index");
        }
    }
}
