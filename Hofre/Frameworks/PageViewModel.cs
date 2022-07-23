﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frameworks
{
    public class PageViewModel<T>
    {
        public List<T> Model {get;set;}
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }


    }
}
