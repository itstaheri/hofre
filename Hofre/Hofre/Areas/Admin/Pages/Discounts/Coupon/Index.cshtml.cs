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
    public class IndexModel : PageModel
    {
        private readonly ICouponApplication _repository;
        public List<CouponViewModel> Coupons { get; set; }

    
        public IndexModel(ICouponApplication repository)
        {
            _repository = repository;
        }
        public async Task OnGet()
        {
            Coupons = await _repository.GetAll();
        }
        public async Task<RedirectToPageResult> OnPost(long Id)
        {
            await _repository.Remove(Id);
            return RedirectToPage("./index");
        }
      
        public async Task<RedirectToPageResult> OnPostRemove(long Id)
        {
            await _repository.Remove(Id);
            return RedirectToPage("./index");
        }
    }
}
