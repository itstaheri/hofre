using DM.Application.Contract.CustomerDiscount;
using DM.Domain.CustomerDiscount;
using Frameworks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DM.Application
{
    public class DiscountApplication : IDiscountApplication
    {
        private readonly IDiscountRepository _repository;

        public DiscountApplication(IDiscountRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(CreateDiscount commend)
        {
            var discount = new DiscountModel(commend.Title, commend.DiscountRate, commend.CourseId, commend.startDate.ToGeorgianDateTime(), commend.EndDate.ToGeorgianDateTime());
            await _repository.Create(discount);
        }

        public async Task Edit(EditDiscount commend)
        {
            var discount = await _repository.GetBy(commend.Id);
            discount.Edit(commend.Title, commend.DiscountRate, commend.CourseId, commend.startDate.ToGeorgianDateTime(), commend.EndDate.ToGeorgianDateTime());
            await _repository.Save();
        }

        public async Task<List<DiscountViewModel>> GetAll()
        {  
            return await _repository.GetAll();
        }

        public async Task<EditDiscount> GetValueForEdit(long Id)
        {
            var discount = await _repository.GetBy(Id);
            return new EditDiscount
            {
                Id = discount.Id,
                DiscountRate = discount.DiscountRate,
                //EndDate = discount.DateTimeEnd,
                //startDate = discount.DateTimeStart
                CourseId = discount.CourseId,
                Title = discount.Title,

            };
        }

        public async Task Remove(long Id)
        {
           await _repository.Remove(Id);
        }
    }
}
