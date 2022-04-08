using DM.Application.Contract.CustomerDiscount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Domain.CustomerDiscount
{
    public interface IDiscountRepository
    {
        Task Create(DiscountModel commend);
        Task Remove(long Id);
        Task Save();
        Task<List<DiscountViewModel>> GetAll();
        Task<DiscountModel> GetBy(long Id);
    }
}
