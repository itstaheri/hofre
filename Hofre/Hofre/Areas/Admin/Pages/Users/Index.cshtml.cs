using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using UM.Application.Contract.User;
using UM.Application.Contract.UserRole;

namespace Hofre.Areas.Admin.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly IUserApplication _repository;
        public List<UserViewModel> Users { get; set; }
        public IndexModel(IUserApplication repository)
        {
            _repository = repository;
        }

        public async Task OnGet()
        {
            Users = await _repository.GetAll();   
        }
        public async Task OnPostRemove(long Id)
        {
            await _repository.Remove(Id);
        }
        public async Task OnPostActive(long Id)
        {
            await _repository.Active(Id);
        }
        public async Task OnPostDeActive(long Id)
        {
            await _repository.DeActive(Id);
        }
        public async Task ChangePassword(long Id,string newPassword)
        {
            await _repository.ChangePassword(Id, newPassword);
        }

    }
}
