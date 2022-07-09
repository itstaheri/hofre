using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CM.Application.Contract.CourseCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hofre.Areas.Admin.Pages.CourseCategories
{
    public class IndexModel : PageModel
    {
        private readonly ICourseCategoryApplication _repository;
        public List<CourseCategoryViewModel> courseCategories;
        public IndexModel(ICourseCategoryApplication repository)
        {
            _repository = repository;
        }

        public async Task OnGet()
        {
            courseCategories =await _repository.GetAll();
        }
        public async Task<RedirectToPageResult> OnPost(long Id)
        {
            await _repository.Remove(Id);
            return RedirectToPage();
        }
    }
}
