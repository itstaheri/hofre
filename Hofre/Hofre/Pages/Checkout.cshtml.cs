using Frameworks;
using Frameworks.Auth;
using Frameworks.ZarinPal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OM.Application.Contract.Order;
using Query.Modules.Coupon;
using Query.Modules.Course;
using System.Threading.Tasks;

namespace Hofre.Pages
{
    public class CheckoutModel : PageModel
    {
        private readonly IOrderApplication _order;
        private readonly IZarinPalFactory _zarinpal;
        private readonly IAuth _auth;
        private readonly ICouponQueryRepository _coupon;
        private readonly ICourseQueryRepository _course;
        public PlaceCouponResult CouponResult { get; set; }
        public bool PlaceOrder = false;
        public string SaveCoupon = "";

        public CheckoutModel(IOrderApplication order, IZarinPalFactory zarinpal, IAuth auth, ICouponQueryRepository coupon, ICourseQueryRepository course)
        {
            _order = order;
            _zarinpal = zarinpal;
            _auth = auth;
            _coupon = coupon;
            _course = course;
        }

         public CourseQueryViewModel Course { get; set; }
        public async Task OnGet(long CourseId)
        {
           
            Course = await _course.GetBy(CourseId);
            

        }
        public async Task<IActionResult> OnPostPay(OrderViewModel order)
        {
            //var usercoupon = new UserCouponViewModel { Coupon = }
            var user = await _auth.CurrentUserInfo();
            var orderId = await _order.PlaceOrder(order);
            var paymentResponse = _zarinpal.CreatePaymentRequest(order.TotalPrice.ToMoney(), user.Number, user.Email, "", orderId);
            return Redirect($"https://{_zarinpal.Prefix}.zarinpal.com/pg/StartPay/{paymentResponse.Authority}");
        }
        public async Task<IActionResult> OnGetCallBack([FromQuery] string authority, string status, [FromQuery] long orderId)
        {
            var amount = await _order.GetAmountBy(orderId);
            var verify = _zarinpal.CreateVerificationRequest(authority, amount.ToString());
            if (status == "OK" && verify.Status == 200)
            {
                var Code = await _order.PaySucceded(verify.RefID, orderId);
                //await _coupon.SaveUserCoupon()
                return RedirectToPage("./PaymentResult", "پرداخت با موفقیت انجام شد.", Code);
            }
            else
            {
                return RedirectToPage("/Result", "OnGet", "پرداخت با مشکل مواجه شد.در صورت کسر وجه از حساب شما مبلغ کسر شده تا 24آینده به حساب شما برگشت داده خواهد شد");
            }
        }
        public async Task<IActionResult> OnPostPlaceCoupon(CourseOrderDetail courseOrder, string Coupon)
        {
            Course = await _course.GetBy(courseOrder.CourseId);
            SaveCoupon = Coupon;

            CouponResult = await _coupon.PlaceCoupon(courseOrder, Coupon);

            Course.DiscountRate = CouponResult.DiscountRate;
            Course.DiscountAmount = CouponResult.DiscountAmount;
            Course.PayAmount = CouponResult.PayAmount;

            ViewData["CouponMessage"] = CouponResult.Message;
            if (CouponResult.IsSuccess) PlaceOrder = true;
          
            return Page();
        }
    }
}
