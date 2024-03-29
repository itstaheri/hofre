﻿using Exceptions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
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
        public async Task<List<int>> GetPermissions()
        {
            if (!await IsAuthenticated())
                return new List<int>();

            var permissions = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Permissions")
                ?.Value;
            return JsonConvert.DeserializeObject<List<int>>(permissions);
        }
        public async Task<long> CurrentUserId()
        {
            return await IsAuthenticated()
                ? long.Parse(_httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "AccountId")?.Value)
                : 0;
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
            result.Number = claims.FirstOrDefault(x => x.Type == "Phone")?.Value;
            result.Email = claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;
            result.Picture = claims.FirstOrDefault(x => x.Type == "Picture").Value;
            result.RoleName = claims.FirstOrDefault(x => x.Type == "RoleName").Value;
            result.RoleName = claims.FirstOrDefault(x => x.Type == "Permissions").Value;
            return result;
        }

        public async Task<string> CurrentUserName()
        {
            if (!(await IsAuthenticated()))
                throw new NotFoundException();
            return _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Username")?.Value;   

        }

        public async Task<string> CurrentUserRole()
        {
            if (!(await IsAuthenticated()))
                throw new NotFoundException();
            return _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
        }

        public async Task<bool> IsAuthenticated()
        {
            return  _httpContext.HttpContext.User.Identity.IsAuthenticated;
        }

        public async Task SignIn(AuthViewModel account)
        {
            var permissions = JsonConvert.SerializeObject(account.Permissions);
            var claims = new List<Claim>
            {
                new Claim("AccountId",account.Id.ToString()),
                new Claim("Username",account.Username),
                new Claim(ClaimTypes.Role,account.RoleId.ToString()),
                new Claim("Phone",account.Number),
                new Claim(ClaimTypes.Email,account.Email),
                new Claim("Picture",account.Picture),
                new Claim(ClaimTypes.Name,account.Username),
                new Claim("RoleName",account.RoleName),
                new Claim("Permissions",permissions)


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
