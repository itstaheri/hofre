using CM.Application.Contract.CourseComment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hofre.Areas.Admin.Pages.Courses
{
    public class CommentModel : PageModel
    {
        private readonly ICourseCommentApplication _repository;
        public List<CourseCommentViewModel> Comments { get; set; }
        public CommentModel(ICourseCommentApplication repository)
        {
            _repository =  repository;
        }
        public async Task OnGet()
        {
            Comments = await _repository.GetAll();

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
        public async Task<RedirectToPageResult> OnPostDelete(long Id)
        {
            await _repository.Remove(Id);
            return RedirectToPage();
        }

    }
}
