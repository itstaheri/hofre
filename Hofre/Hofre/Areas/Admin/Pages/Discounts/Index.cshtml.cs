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
        [BindProperty] public EditDiscount Discount { get; set; }

        public IndexModel(IDiscountApplication repository, ICourseApplication course)
        {
            _repository = repository;
            _course = course;
        }

        public async void OnGet()
        {
            discounts = await _repository.GetAll();
<<<<<<< Updated upstream
         //   Discount = await _repository.GetValueForEdit()
=======
>>>>>>> Stashed changes

        }
        public async Task<RedirectToPageResult> OnPost(long Id)
        {
            await _repository.Remove(Id);
            return RedirectToPage();
        }
    }
}
