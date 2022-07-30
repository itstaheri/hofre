using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Query.Modules.User;
using System.Threading.Tasks;

namespace Hofre.Pages
{
    public class ResetPasswordModel : PageModel
    {
        private readonly IAccountQueryRepository _repository;
        public string Code { get; set; }
        public string Result { get; set; }
        public ResetPasswordModel(IAccountQueryRepository repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> OnGet(string code)
        {
            var result = await _repository.ValidationResetCode(code);
            if (string.IsNullOrWhiteSpace(code) || !result) 
                return Redirect("/account");

            Code = code;
            return Page();
        }
        public async Task<IActionResult> OnPost(ResetPasswordViewModel commend)
        {
            Code= commend.Code;
            var result = await _repository.ResetPassword(commend);
            if (result == nameof(ResetPasswordStatus.SuccessfulReset))
            {
                return RedirectToPage("/Result", routeValues: new { message = ResetPasswordStatus.SuccessfulReset });

            }
            else if(result == nameof(ResetPasswordStatus.ExpireTime))
            {
                ModelState.AddModelError(nameof(result), ResetPasswordStatus.ExpireTime);
                return Page();
            }else if(result == nameof(ResetPasswordStatus.EqualPassword))
            {
                ModelState.AddModelError(nameof(result), ResetPasswordStatus.EqualPassword);
                return Page();
            }
            return Page();

        }
    }
}
