using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CM.Application.Contract.CourseCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hofre.Areas.Admin.Pages.CourseCategories
{
    public class EditModel : PageModel
    {
        private readonly ICourseCategoryApplication _repository;

        public EditModel(ICourseCategoryApplication repository)
        {
            _repository = repository;
        }

        [BindProperty] public EditCourseCategory courseCategory { get; set; }
        public async Task OnGet(long Id)
        {
            courseCategory = await _repository.GetValueForEdit(Id);
        }
        public async Task<RedirectToPageResult> OnPost(EditCourseCategory commend)
        {
           await _repository.Edit(commend);
            return RedirectToPage("./index");
        }
    }
}
