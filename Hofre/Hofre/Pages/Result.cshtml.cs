using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hofre.Pages
{
    public class ResultModel : PageModel
    {
        
        public IActionResult OnGet(string message)
        {
            if (string.IsNullOrWhiteSpace(message)) return RedirectToPage("/index");
          
            ViewData["message"] = message;
            return Page();
        }
    }
}
