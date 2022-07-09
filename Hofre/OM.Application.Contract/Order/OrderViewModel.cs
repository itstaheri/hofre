﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Application.Contract.Order
{
    public class OrderViewModel
    {

        public long Id { get; set; }
        public long UserId { get; set; }
        public double TotalPrice { get; set; }
        public double DiscountAmount { get; set; }
        public double PayAmount { get; set; }
        public long RefId { get; set; }
        public string CreationDate { get; set; }

    }
}
