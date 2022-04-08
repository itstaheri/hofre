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
    public class CreateModel : PageModel
    {
        private readonly IDiscountApplication _repository;
        private readonly ICourseApplication _course;
        public List<SelectListItem> Courses;

        public CreateModel(IDiscountApplication repository, ICourseApplication course)
        {
            _repository = repository;
            _course = course;
        }

        public void OnGet()
        {
            Courses =_course.GetAll().Select(x=>new SelectListItem(x.Subject,x.Id.ToString())).ToList();
        }
        public async Task<RedirectToPageResult> OnPost(CreateDiscount commend)
        {
            await _repository.Create(commend);
            return RedirectToPage("./Index");
        }
    }
}
