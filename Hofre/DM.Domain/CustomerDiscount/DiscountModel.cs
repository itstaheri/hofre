using CM.Domain.CourseAgg;
using Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Domain.CustomerDiscount
{
    public class DiscountModel : BaseEntity
    {
        public DiscountModel(string title, int discountRate, long courseId, DateTime dateTimeStart, DateTime dateTimeEnd)
        {
            Title = title;
            DiscountRate = discountRate;
            CourseId = courseId;
            DateTimeStart = dateTimeStart;
            DateTimeEnd = dateTimeEnd;
        }
        public void Edit(string title, int discountRate, long courseId, DateTime dateTimeStart, DateTime dateTimeEnd)
        {
            Title = title;
            DiscountRate = discountRate;
            CourseId = courseId;
            DateTimeStart = dateTimeStart;
            DateTimeEnd = dateTimeEnd;
        }

        public string Title { get; set; }
        public int DiscountRate { get; set; }
        public long CourseId { get; set; }
        public DateTime DateTimeStart { get; set; }
        public DateTime DateTimeEnd { get; set; }
    }
}
