using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Query.Modules.Course;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hofre.Pages.Course
{
    public class SearchModel : PageModel
    {
        private readonly ICourseQueryRepository _repository;
        public List<CourseQueryViewModel> courses { get; set; }
        public string Entery;

        public SearchModel(ICourseQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task OnGet(string searchentery)
        { 
            courses = await _repository.Search(searchentery);
            Entery = searchentery;
        }
    }
}
