using CM.Domain.CourseAgg;
using Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Domain.CourseCommentAgg
{
    public class CourseCommentModel : BaseEntity
    {
        public CourseCommentModel(string text, string username, long courseId)
        {
            Text = text;
            Username = username;
            CourseId = courseId;
        }

        public void Active() => IsActive = true;
        public void DeActive() => IsActive = false;

        public string Text { get; private set; }
        public string Username { get; private set; }
        public bool IsActive { get; private set; }
        public long CourseId { get; private set; }
        public CourseModel course { get; private set; }



    }
}
