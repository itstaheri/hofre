using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CM.Application.Contract.Course;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hofre.Areas.Admin.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly ICourseApplication _repository;
        public List<CourseViewModel> courses;
        public IndexModel(ICourseApplication repository)
        {
            _repository = repository;
        }

        public void OnGet()
        {
            courses = _repository.GetAll();
        }
        public RedirectToPageResult OnPostActive(long Id)
        {
            _repository.Active(Id);
            return RedirectToPage();
        }
        public RedirectToPageResult OnPostDeActive(long Id)
        {
            _repository.DeActive(Id);
            return RedirectToPage();
        }
        public RedirectToPageResult OnPostRemove(long Id)
        {
            _repository.Remove(Id);
            return RedirectToPage();
        }
    }
}
