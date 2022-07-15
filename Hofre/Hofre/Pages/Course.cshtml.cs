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

namespace Hofre.Pages
{

    public class CourseModel : PageModel
    {
        private readonly ICourseQueryRepository _repository;
        private readonly IZarinPalFactory _zarinpal;
        private readonly IOrderApplication _order;
        private readonly IAuth _auth;
        private readonly ICourseCommentApplication _comment;

        public CourseModel(ICourseQueryRepository repository, IZarinPalFactory zarinpal, IOrderApplication order, IAuth auth, ICourseCommentApplication comment)
        {
            _repository = repository;
            _zarinpal = zarinpal;
            _order = order;
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
        public async Task<IActionResult> OnPostPay(OrderViewModel order, long CourseId)
        {
            var user = await _auth.CurrentUserInfo();

            if (await (_repository.FreeCourse(CourseId)))
            {
                await _repository.JoinToCourse(CourseId);
                return RedirectToPage();
            }
            else
            {
                var orderId = await _order.PlaceOrder(order);
                var paymentResponse = _zarinpal.CreatePaymentRequest(order.TotalPrice.ToMoney(), user.Number, user.Email, "", orderId);
                return Redirect($"https://{_zarinpal.Prefix}.zarinpal.com/pg/StartPay/{paymentResponse.Authority}");
            }
        }
        public async Task<IActionResult> OnGetCallBack([FromQuery] string authority, string status, [FromQuery] long orderId)
        {
            var amount = await _order.GetAmountBy(orderId);
            var verify = _zarinpal.CreateVerificationRequest(authority, amount.ToString());
            if (status == "OK" && verify.Status == 200)
            {
                var Code = await _order.PaySucceded(verify.RefID, orderId);
                return RedirectToPage("./PaymentResult", "پرداخت با موفقیت انجام شد.", Code);
            }
            else
            {
                return RedirectToPage("./PaymentResult", "پرداخت با مشکل مواجه شد.در صورت کسر وجه از حساب شما مبلغ کسر شده تا 24آینده به حساب شما برگشت داده خواهد شد");
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
