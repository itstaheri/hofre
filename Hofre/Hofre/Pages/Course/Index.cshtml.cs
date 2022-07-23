using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Query.Modules.Course;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hofre.Pages.Course
{
    public class IndexModel : PageModel
    {
        private readonly ICourseQueryRepository _repository;
        public List<CourseQueryViewModel> courses { get; set; }
        public CoursePageViewModel CoursePage { get; set; }
        public IndexModel(ICourseQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task OnGet(int pageId=1)
        {
            CoursePage = await _repository.GetAll(pageId);
        }
        
    }
}
