using Exceptions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Frameworks.Auth
{
    public class Auth : IAuth
    {
        private readonly IHttpContextAccessor _httpContext;

        public Auth(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public Task<long> CurrentUserId()
        {
            throw new NotImplementedException();
        }

        public async Task<AuthViewModel> CurrentUserInfo()
        {
            var result = new AuthViewModel();
            if (!(await IsAuthenticated()))
                return result;

            var claims = _httpContext.HttpContext.User.Claims.ToList();
            result.Id = long.Parse(claims.FirstOrDefault(x => x.Type == "AccountId").Value);
            result.Username = claims.FirstOrDefault(x => x.Type == "Username").Value;
            result.RoleId = long.Parse(claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value);
            result.Number = claims.FirstOrDefault(x => x.Type == "Mobile").Value;
            result.Email = claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;
            result.Picture = claims.FirstOrDefault(x => x.Type == "Picture").Value;
            return result;
        }

        public async Task<string> CurrentUserRole()
        {
            if (!(await IsAuthenticated()))
                throw new NotFoundException
            return _httpContext.HttpContext.User.Claims.First(x=>x.Type == )
        }

        public async Task<bool> IsAuthenticated()
        {
            return  _httpContext.HttpContext.User.Identity.IsAuthenticated;
        }

        public async Task SignIn(AuthViewModel account)
        {
            var claims = new List<Claim>
            {
                new Claim("AccountId",account.Id.ToString()),
                new Claim("Username",account.Username),
                new Claim(ClaimTypes.Role,account.RoleId.ToString()),
                new Claim("Phone",account.Number),
                new Claim(ClaimTypes.Email,account.Email),
                new Claim("Picture",account.Picture),


            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTime.UtcNow.AddDays(1),

            };
            await _httpContext.HttpContext
                .SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
        }

        public async Task SignOut()
        {
          await  _httpContext.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
