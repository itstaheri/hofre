using CM.Application.Contract.Course;
using DM.Application.Contract.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hofre.Areas.Admin.Pages.Discounts
{
    public class IndexModel : PageModel
    {
        private readonly IDiscountApplication _repository;
        private readonly ICourseApplication _course;
        public List<DiscountViewModel> discounts;
        public List<SelectListItem> courses;

        public IndexModel(IDiscountApplication repository, ICourseApplication course)
        {
            _repository = repository;
            _course = course;
        }

        public async Task OnGet()
        {
            discounts = await _repository.GetAll();
        }
        public async Task<RedirectToPageResult> OnPost(long Id)
        {
            await _repository.Remove(Id);
            return RedirectToPage();
        }
    }
}
