using Microsoft.AspNetCore.Mvc;
using Query.Modules.Course;
using System.Threading.Tasks;

namespace Hofre.ViewComponents
{
    public class CourseCategoryViewComponent : ViewComponent
    {
        private readonly ICourseQueryRepository _repository;
        public CourseCategoryViewComponent(ICourseQueryRepository repository)
        {
            _repository = repository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var category = await _repository.GetAllCategories();
            return View(category);
        }
    }
}
