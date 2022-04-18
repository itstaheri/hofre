using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Application.Contract.CustomerDiscount
{
    public interface IDiscountApplication
    {
        Task Create(CreateDiscount commend);
        Task Edit(EditDiscount commend);
        Task Remove(long Id);
        Task<List<DiscountViewModel>> GetAll();
        Task<EditDiscount> GetValueForEdit(long Id);

    }
}
