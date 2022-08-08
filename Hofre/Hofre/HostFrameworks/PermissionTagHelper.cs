using Frameworks.Auth;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Linq;

namespace Hofre
{
    [HtmlTargetElement(Attributes = "Permission")]
    public class PermissionTagHelper : TagHelper
    {
        public int Permission { get; set; }

        private readonly IAuth _authHelper;

        public PermissionTagHelper(IAuth authHelper)
        {
            _authHelper = authHelper;
        }

        public async override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!(await _authHelper.IsAuthenticated()))
            {
                output.SuppressOutput();
                return;
            }

            var permissions = _authHelper.GetPermissions();
            if ((await permissions).All(x => x != Permission))
            {
                output.SuppressOutput();
                return;
            }

            base.Process(context, output);
        }
    }
}