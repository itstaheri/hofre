﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Application.Contract.CourseComment
{
    public class CreateCourseComment
    {
        public string Text { get; set; }
        public string Username { get; set; }
        public long CourseId { get; set; }
    }
}
