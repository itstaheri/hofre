using Frameworks.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Query.Modules.User;
using System.Collections.Generic;
using System.Threading.Tasks;
using UM.Application;
using UM.Application.Contract.User;

namespace Hofre.Pages
{
    [Authorize]
    [IgnoreAntiforgeryToken]
    public class ProfileModel : PageModel
    {
        private readonly IAccountQueryRepository _repository;
        private readonly IUserApplication _userApplication;
        private readonly IAuth _auth;
        public AccountQueryViewModel account { get; set; }
        public ProfileModel(IAccountQueryRepository repository, IAuth auth, IUserApplication userApplication)
        {
            _repository = repository;
            _auth = auth;
            _userApplication = userApplication;
        }

        public async Task OnGet()
        {

            account = await _repository.GetBy((await _auth.CurrentUserId()),"profile");
        }
        public async Task <IActionResult> OnPostEdit(EditUser commend)
        {
            var result =await _userApplication.Edit(commend);
            account = await _repository.GetBy((await _auth.CurrentUserId()),"profile");

            if (result == nameof(UserEditStatus.RepetitiveUsername))
            {
                ModelState.AddModelError(result, UserEditStatus.RepetitiveUsername);
                return Page();
            }
            else if (result == nameof(UserEditStatus.RepetitivePhone))
            {
                ModelState.AddModelError(result, UserEditStatus.RepetitivePhone);
                return Page();
            }
            else if (result == nameof(UserEditStatus.RepetitiveEmail))
            {
                ModelState.AddModelError(result, UserEditStatus.RepetitiveEmail);
                return Page();
            }
            else if (result == nameof(UserEditStatus.FailEdit))
            {
                ModelState.AddModelError(result, UserEditStatus.FailEdit);
                return Page();
            }
            return Page();
        }
        public async Task<RedirectToPageResult> OnGetSignout()
        {   
            await _auth.SignOut();
            return RedirectToPage("/account");
        }
        public async Task<RedirectToPageResult> OnPostProfile(IFormFile profilePicture)
        {
            await _repository.UpdateProfilePicture(await _auth.CurrentUserId(), profilePicture);
            return RedirectToPage();
        }
        public  async Task<IActionResult> OnPostData(long Id,string commend)
        {
            account = await _repository.GetBy(Id,commend);
            return new JsonResult(account);
        }
    }
}
