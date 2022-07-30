using Frameworks.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Query.Modules.User;
using System.Threading.Tasks;

namespace Hofre.Pages
{
    [Authorize]
    public class ChangePasswordModel : PageModel
    {
        private readonly IAuth _auth;
        private readonly IAccountQueryRepository _repository;
        public long UserId { get; set; }
        public ChangePasswordModel(IAuth auth, IAccountQueryRepository repository)
        {
            _auth = auth;
            _repository = repository;
        }

        public async Task<IActionResult> OnGet(long userId)
        {
            long userid = await _auth.CurrentUserId();
            if (userId != userid)
            {
                return RedirectToPage("/profile");
            }
            UserId = userId;
            return Page();
            
        }
        public async Task<IActionResult> OnPost(ChangePassword commend)
        {
           var result = await _repository.ChangePassword(commend);
            if (!result)
            {
                return Page();
            }
            return RedirectToPage("profile");
        }
    }
}
