using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Query.Modules.User;
using System.Threading.Tasks;

namespace Hofre.Pages
{
    public class ForgotPasswordModel : PageModel
    {
        private readonly IAccountQueryRepository _repository;
        public ForgotPasswordModel(IAccountQueryRepository repository)
        {
            _repository = repository;
        }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost(string entery)
        {
            var result = await _repository.ForgetPassword(entery);
            if (!result)
            {
                ModelState.AddModelError(nameof(result), "کاربری با این نام یا ایمیل وجود ندارد!");
            }
            else
            {
                ViewData["Message"] = "لینک بازیابی کلمه ی عبور برای شما ایمیل شد!";
            }
            return Page();
        }
    }
}
