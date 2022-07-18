using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Hofre.ViewComponents
{
    public class HeaderViewComponentModel : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(long id)
        {
            return View();
        }
      
    }
}
