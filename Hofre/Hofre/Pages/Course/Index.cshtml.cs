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
        public IndexModel(ICourseQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task OnGet()
        {
            courses = await _repository.GetAll();
        }
        public async Task<RedirectToPageResult> OnPost(string searchentery)
        {
           
            return RedirectToPage("./Search",new{searchentery});

        }
    }
}
