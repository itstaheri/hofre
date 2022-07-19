using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Query.Modules.Course;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hofre.Pages.Course
{
    public class CategoryModel : PageModel
    {
        private readonly ICourseQueryRepository _repository;
        public List<CourseQueryViewModel> courses { get; set; }
        public CategoryModel(ICourseQueryRepository repository)
        {
            _repository = repository;

        }
        public async Task OnGet(long categoryId)
        {
            courses = await _repository.GetByCategory(categoryId);
        }
    }
}
