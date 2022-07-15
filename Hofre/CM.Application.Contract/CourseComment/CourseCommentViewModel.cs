using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Application.Contract.CourseComment
{
    public class CourseCommentViewModel
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public string Username { get; set; }
        public string CreationDate { get; set; }
        public bool IsActive { get; set; }
        public string CourseSubject { get; set; }
        public long CourseId { get; set; }
    }
}
