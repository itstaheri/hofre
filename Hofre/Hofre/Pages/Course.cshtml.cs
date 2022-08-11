using Frameworks.Auth;
using Frameworks.ZarinPal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OM.Application;
using OM.Application.Contract.Order;
using Query.Modules.Course;
using System.Threading.Tasks;
using Frameworks;
using CM.Application.Contract.CourseComment;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using CM.Application.Contract.Course;

namespace Hofre.Pages
{

    public class CourseModel : PageModel
    {
        private readonly ICourseQueryRepository _repository;
        private readonly IAuth _auth;
        private readonly ICourseCommentApplication _comment;

        public CourseModel(ICourseQueryRepository repository, IAuth auth, ICourseCommentApplication comment)
        {
            _repository = repository;

            _auth = auth;
            _comment = comment;
        }

        public CourseQueryViewModel Course { get; set; }
        public List<CourseCommentViewModel> comments;
        public bool IsMember;

        public async Task OnGet(string slug)
        {
            Course = await _repository.GetBy(slug);
            IsMember = await _repository.IsMember(Course.Id, (await _auth.CurrentUserId()));
            comments = (await _comment.GetCommentsBy(Course.Id));

        }

        public async Task<RedirectToPageResult> OnPostPay(long CourseId)
        {
           
            if (await (_repository.FreeCourse(CourseId)))
            {
                await _repository.JoinToCourse(CourseId);
                return RedirectToPage();
            }
            else
            {
                return RedirectToPage("/checkout", routeValues: new{CourseId = CourseId});

            }

        }
       
       // [Authorize]
        public async Task<RedirectToPageResult> OnPostComment(CreateCourseComment commend)
        {
            await _comment.Create(commend);
            return RedirectToPage();
        }

    }
}
