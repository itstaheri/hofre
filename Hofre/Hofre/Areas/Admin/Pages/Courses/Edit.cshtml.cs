using CM.Application.Contract.Course;
using CM.Application.Contract.CourseCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hofre.Areas.Admin.Pages.Courses
{
    public class EditModel : PageModel
    {
        private readonly ICourseApplication _repository;
        private readonly ICourseCategoryApplication _category;
        [BindProperty] public EditCourse course { get; set; }
        public List<SelectListItem> categories { get; set; }
        public List<CourseVideos> videos { get; set; }

        public EditModel(ICourseApplication repository, ICourseCategoryApplication category)
        {
            _repository = repository;
            _category = category;
        }

        public async Task OnGet(long Id)
        {
            course = await _repository.GetValueForEdit(Id);
            categories = (await _category.GetAll()).Select(x=> new SelectListItem(x.Name, x.Id.ToString())).ToList();
            videos = await _repository.GetVideos(Id);

        }
        public async Task<RedirectToPageResult> OnPost(EditCourse edit)
        {
            await _repository.Edit(edit);
            return RedirectToPage("./Index");
        }
        public async Task<RedirectToPageResult> OnPostDeleteVideo(long Id,string folder)
        {
            await _repository.DeleteVideo(Id, folder);
            return RedirectToPage();
       }
    }
}
