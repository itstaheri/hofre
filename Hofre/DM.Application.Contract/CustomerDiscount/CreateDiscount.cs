using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Application.Contract.CustomerDiscount
{
    public class CreateDiscount
    {
        public string Title { get; set; }
        public int DiscountRate { get; set; }
        public string startDate { get; set; }
        public string EndDate { get; set; }
        public long CourseId { get; set; }
    }
}
