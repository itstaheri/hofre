using Microsoft.AspNetCore.Authorization;

namespace Hofre.HostFrameworks
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public string Code { get;private set; }
        public PermissionRequirement(string code)
        {
            Code = code;
        }
    }
}
