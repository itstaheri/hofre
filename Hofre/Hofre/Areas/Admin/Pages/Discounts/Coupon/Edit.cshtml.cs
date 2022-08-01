using CM.Application.Contract.Course;
using DM.Application.Contract.DiscountCoupon;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hofre.Areas.Admin.Pages.Discounts.Coupon
{
    public class EditModel : PageModel
    {
        private readonly ICouponApplication _repository;
        private readonly ICourseApplication _course;

        public EditCoupon Coupon { get; set; }
        public List<SelectListItem> Courses { get; set; }
        public EditModel(ICouponApplication repository,ICourseApplication course)
        {
            _repository = repository;
            _course = course;
        }
        public async Task OnGet(long Id)
        {
            Coupon = await _repository.GetValueForEdit(Id);
            Courses = (await _course.GetAll()).Select(x => new SelectListItem(x.Subject, x.Id.ToString())).ToList();
        }
        public async Task<RedirectToPageResult> OnPost(EditCoupon commend)
        {
            await _repository.Edit(commend);
            return RedirectToPage("./index");
        }
      
    }
}
