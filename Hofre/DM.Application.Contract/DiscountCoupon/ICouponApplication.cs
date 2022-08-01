using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Application.Contract.DiscountCoupon
{
    public interface ICouponApplication
    {
        Task Create(CreateCoupon commend);
        Task<List<CouponViewModel>> GetAll();
        Task Edit(EditCoupon commend);
        Task<EditCoupon> GetValueForEdit(long Id);
        Task Remove(long Id);

        
    }
}
