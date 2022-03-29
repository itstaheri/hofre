using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CM.Application.Contract.CourseCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hofre.Areas.Admin.Pages.CourseCategories
{
    public class CreateModel : PageModel
    {
        private readonly ICourseCategoryApplication _repository;

        public CreateModel(ICourseCategoryApplication repository)
        {
            _repository = repository;
        }

        public void OnGet()
        {
        }
        public RedirectToPageResult OnPost(CreateCourseCategory commend)
        {
            _repository.Create(commend);
            return RedirectToPage("./index");
        }
    }
}
