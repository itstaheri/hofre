using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Modules.User
{
    public class UserOrderQueryViewModel
    {
        public long OrderId { get; set; }
        public long CourseId { get; set; }
        public string ProductName { get; set; }
        public double PayAmount { get; set; }
        public string CreationDate { get; set; }
        public bool IsFinaly { get; set; }
        public string Code { get; set; }

    }
}
