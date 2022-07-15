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
        public List<CourseVideos> videos { get; set; }
        public IndexModel(ICourseApplication repository)
        {
            _repository = repository;
        }

        public async Task OnGet()
        {
            courses = await _repository.GetAll();

        }
        public async Task<RedirectToPageResult> OnPostActive(long Id)
        {
           await _repository.Active(Id);
            return RedirectToPage();
        }
        public async Task<RedirectToPageResult> OnPostDeActive(long Id)
        {
           await _repository.DeActive(Id);
            return RedirectToPage();
        }
        public async Task<RedirectToPageResult> OnPostRemove(long Id)
        {
           await _repository.Remove(Id);
            return RedirectToPage();
        }
    }
}
