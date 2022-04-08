using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Application.Contract.CustomerDiscount
{
    public class DiscountViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string startDate { get; set; }
        public string EndDate { get; set; }
        public string CourseName { get; set; }
        public long CourseId { get; set; }
        public int Status { get; set; }
    }
}
