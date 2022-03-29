using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CM.Application.Contract.Course;
using CM.Application.Contract.CourseCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hofre.Areas.Admin.Pages.Courses
{
    public class CreateModel : PageModel
    {
        private readonly ICourseApplication _repository;
        private readonly ICourseCategoryApplication _category;
        public List<SelectListItem> categories;

        public CreateModel(ICourseApplication repository, ICourseCategoryApplication category)
        {
            _repository = repository;
            _category = category;
        }
      
        public void OnGet()
        {
           
            categories = _category.GetAll().Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();

        }
        public RedirectToPageResult OnPost(CreateCourse commend)
        {
            _repository.Create(commend);
           
            return RedirectToPage("./index");
        }
    }
}
