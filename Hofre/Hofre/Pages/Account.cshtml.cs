using Frameworks;
using Frameworks.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;
using UM.Application.Contract.User;

namespace Hofre.Pages
{
    public class AccountModel : PageModel
    {
        private readonly IUserApplication _repository;
        private readonly IAuth _auth;

        public AccountModel(IUserApplication repository, IAuth auth)
        {
            _repository = repository;
            _auth = auth;
        }

        public  void OnGet()
        {
            //if (await (_auth.IsAuthenticated())) Redirecttop("./profile");


        }
        public async Task<IActionResult> OnPostLogin(Login commend)
        {
            var result = await _repository.Login(commend);
            if (result.Valid == false)
            {
                ModelState.AddModelError(nameof(commend.Username), "کاربری با این نام کاربری وجود ندارد!");
                return RedirectToPage("./profile");
            }

            else if (result.Valid == true && result.Result == false)
            {
                ModelState.AddModelError(nameof(commend.Username), "نام کاربری یا کلمه ی عبور اشتباه است!");
                return Page();
            }
            else
            {
                return Page();
            }
        }
        public async Task<IActionResult> OnPostRegister(Register commend)
        {

            var result = await _repository.Signup(commend);
            if (result == Status.seuccessfulRegister)
            {
                await _repository.Login(new Login { Username = commend.Username, Password = commend.Password });
                return RedirectToPage("./profile");
            }
            else if (result == Status.RepetitiousData)
            {
                ModelState.AddModelError("", "کاربری با این مشخصات موجود است!");
                return Page();
            }
            else
            {
                ModelState.AddModelError("", "ثبت نام با خطا مواجه شد!");
                return Page();
            }




        }
    }
}
